
using OpenLibraryLabelImg.Data;
using OpenLibraryLabelImg.Forms;
using OpenLibraryLabelImg.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OpenLibraryLabelImg.UserControls
{
    public partial class NetDetailCell : UserControl
    {
        private readonly AnnotationContext context;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public YoloNet Net { get; private set; }
        public NetDetailCell()
        {
            InitializeComponent();
        }

        public NetDetailCell(YoloNet net, AnnotationContext ctx)
        {
            InitializeComponent();
            Net = net;
            context = ctx;

            txtTitle.Text = Net.Title;
            txtDescription.Text = Net.Description;
            txtObjFilePath.Text = Net.ObjFilePath;
            txtYoloFilePath.Text = Net.YoloFilePath;
            txtWeightFolderPath.Text = Net.WeightFolderPath;
            txtDataFolderPath.Text = Net.DataFolderPath;
            txtTargetXResolution.Text = Net.TargetResolution.ToString();

            RefreshCollections();
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            Net.Title = txtTitle.Text;
            Net.Description = txtDescription.Text;
            Net.ObjFilePath = txtObjFilePath.Text;
            Net.YoloFilePath = txtYoloFilePath.Text;
            Net.WeightFolderPath = txtWeightFolderPath.Text;
            Net.DataFolderPath = txtDataFolderPath.Text;
            Net.TargetResolution = int.Parse(txtTargetXResolution.Text);

            if (!Net.DataFolderPath.EndsWith("" + Path.DirectorySeparatorChar))
            {
                Net.DataFolderPath += Path.DirectorySeparatorChar;
            }
            if (!Net.WeightFolderPath.EndsWith("" + Path.DirectorySeparatorChar))
            {
                Net.WeightFolderPath += Path.DirectorySeparatorChar;
            }

            var foundIDs = new List<int>();

            foreach (string item in checkedListBoxCollections.CheckedItems)
            {
                var id = int.Parse(item.Split(',')[0]);
                var coll = context.Collections.Find(id);
                foundIDs.Add(id);
                if (!Net.Collections.Contains(coll)) {
                    Net.Collections.Add(coll);
                }
            }

            var toDelete = Net.Collections.Where(c => !foundIDs.Contains(c.Id)).ToList();
            toDelete.ForEach( i => Net.Collections.Remove(i) );

            context.SaveChanges();
        }

        internal void RefreshCollections()
        {
            checkedListBoxCollections.Items.Clear();
            checkedListBoxCollections.Items.AddRange(context.Collections.AsNoTracking()
                                                                .ToArray()
                                                                .Select(c => $"{c.Id}, {c.Title}")
                                                                .ToArray());

            for (int i = 0; i < checkedListBoxCollections.Items.Count; i++)
            {
                var item = checkedListBoxCollections.Items[i] as string;
                var id = int.Parse(item.Split(',')[0]);
                checkedListBoxCollections.SetItemChecked(i, Net.Collections.Any(c => c.Id == id));
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var collections = context.Nets
            .First(n => n.Id == Net.Id)
            .Collections
            .ToList();
            Logger.Info($"Starting export for collections {string.Join(", ", collections.Select(c => c.Id))}");

            // Test every class which is in a collection is in classMapping
            bool mapComplete = Net.Collections
                .SelectMany(c => c.Classes)
                .Distinct()
                .All(c => Net.ClassMapping.Any(m => m.AnnotationClass == c));

            Logger.Debug($"mapComplete: {mapComplete}");

            if (!mapComplete) {
                Net.ClassMapping = Net.Collections
                .SelectMany(c => c.Classes)
                .Distinct()
                .Select(c => new ClassMap() { AnnotationClass = c, AnnotationClassId = c.Id, MappedId = 0 })
                .ToList();

                ClassMapperWindow classMapperDialog = new ClassMapperWindow(Net.ClassMapping.ToList());

                if (classMapperDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                Net.ClassMapping.Clear();
                context.SaveChanges();
                Net.ClassMapping = classMapperDialog.Mapping;
                context.SaveChanges();
            }
           
            var idMapper = Net.ClassMapping.ToDictionary(m => m.AnnotationClassId, m => m.MappedId);

            var classes = Net.Collections.SelectMany(c => c.Classes).Distinct();

            var mappedIds = idMapper.Keys.ToList();
            mappedIds.Sort();

            File.WriteAllText(Net.DataFolderPath + "classes.txt", string.Join("", mappedIds.Select(id => classes.First(c => c.Id == id).Title + "\n")) );

            Logger.Debug($"Exporting: {collections.Count} collection with {collections.SelectMany(c => c.Images).Count()} images and {collections.SelectMany(c => c.Images).SelectMany(i => i.Boxes).Count()} annotations");

            var exportedImages = new List<string>();

            collections
            .AsParallel()
            .ForAll(c =>
            {
                Application.DoEvents();
                c.Images
                .Where(i => i.State == AnnotationState.Annotated && i.Boxes.Count > 0)
                .ToList()
                .AsParallel()
                .ForAll(i => {
                    using (var img = Image.FromFile(c.BasePath + i.FileName)) {
                        var yoloFilePath = Net.DataFolderPath + i.FileName.Remove(i.FileName.LastIndexOf('.')) + ".txt";
                        File.WriteAllText(yoloFilePath,
                            string.Join("", 
                                i.Boxes.Select(b => b.ExportAsYOLO())
                                .Select(b => $"{idMapper[b.ClassId]} {b.X} {b.Y} {b.Width} {b.Height}\n")
                            )
                        );
                        Helpers.resize(img, Net.DataFolderPath + i.FileName, Net.TargetResolution);
                        exportedImages.Add(i.FileName);
                    }
                });
            });
            Logger.Debug($"Export done");
        }

        private void btnObjFile_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog
            {
                Multiselect = false,
                Filter = ".obj-File|*.obj",
                Title = "Select obj File",
                FileName = Net.ObjFilePath
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtObjFilePath.Text = ofd.FileName;
                    txt_Leave(null, null);
                }
            }
        }

        private void btnYoloFilePath_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog
            {
                Multiselect = false,
                Filter = ".yolo-File|*.yolo",
                Title = "Select yolo File",
                FileName = Net.YoloFilePath
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtYoloFilePath.Text = ofd.FileName;
                    txt_Leave(null, null);
                }

            }
        }

        private void btnWeigthFolderPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog
            {
                SelectedPath = txtWeightFolderPath.Text,
                RootFolder = Environment.SpecialFolder.MyComputer
            })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtWeightFolderPath.Text = fbd.SelectedPath;
                    txt_Leave(null, null);
                }
            }
        }

        private void btnDataFolderPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog
            {
                SelectedPath = txtDataFolderPath.Text,
                RootFolder = Environment.SpecialFolder.MyComputer
            })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtDataFolderPath.Text = fbd.SelectedPath;
                    txt_Leave(null, null);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var collections = context.Nets
                .Include("Collections")
                .Include("Collections.Images")
                .Include("Collections.Images.Boxes")
                .Include("Collections.Classes")
                .First(n => n.Id == Net.Id)
                .Collections
                .ToList();
            Logger.Info($"Starting annotation export for collections {string.Join(", ", collections.Select(c => c.Id))}");

            // Test every class which is in a collection is in classMapping
            bool mapComplete = Net.Collections
                .SelectMany(c => c.Classes)
                .Distinct()
                .All(c => Net.ClassMapping.Any(m => m.AnnotationClass == c));

            Logger.Debug($"mapComplete: {mapComplete}");

            if (!mapComplete)
            {
                Net.ClassMapping = Net.Collections
                .SelectMany(c => c.Classes)
                .Distinct()
                .Select(c => new ClassMap() { AnnotationClass = c, AnnotationClassId = c.Id, MappedId = 0 })
                .ToList();

                ClassMapperWindow classMapperDialog = new ClassMapperWindow(Net.ClassMapping.ToList());

                if (classMapperDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                Net.ClassMapping.Clear();
                context.SaveChanges();
                Net.ClassMapping = classMapperDialog.Mapping;
                context.SaveChanges();
            }

            var idMapper = Net.ClassMapping.ToDictionary(m => m.AnnotationClassId, m => m.MappedId);

            var classes = Net.Collections.SelectMany(c => c.Classes).Distinct();

            var mappedIds = idMapper.Keys.ToList();
            mappedIds.Sort();

            File.WriteAllText(Net.DataFolderPath + "classes.txt", string.Join("", mappedIds.Select(id => classes.First(c => c.Id == id).Title + "\n")));

            Logger.Debug($"Exporting: {collections.Count} collection with {collections.SelectMany(c => c.Images).Count()} images and {collections.SelectMany(c => c.Images).SelectMany(i => i.Boxes).Count()} annotations");

            collections
            .AsParallel()
            .ForAll(c =>
            {
                c.Images
                .Where(i => i.State == AnnotationState.Annotated)
                .ToList()
                .AsParallel()
                .ForAll(i => {
                    using (var img = Image.FromFile(c.BasePath + i.FileName))
                    {
                        var yoloFilePath = Net.DataFolderPath + i.FileName.Remove(i.FileName.LastIndexOf('.')) + ".txt";
                        File.WriteAllText(yoloFilePath,
                            string.Join("",
                                i.Boxes.Select(b => b.ExportAsYOLO())
                                .Select(b => $"{idMapper[b.ClassId]} {b.X} {b.Y} {b.Width} {b.Height}\n")
                            )
                        );
                    }
                });
            });
            Logger.Debug($"Export done");
        }
    }
}
