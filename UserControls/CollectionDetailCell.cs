using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using OpenLibraryLabelImg.Data;
using OpenLibraryLabelImg.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLibraryLabelImg.UserControls
{
    public partial class CollectionDetailCell : UserControl
    {
        public AnnotationCollection Collection { get; set; }
        private readonly AnnotationContext context = new AnnotationContext();
        public event Action CollectionChanged;
        public CollectionDetailCell() {
            InitializeComponent();
            Collection = new AnnotationCollection();
            if (!DesignMode) {
                context.Collections.Add(Collection);
            }
            updateNOfMLabel();

            RefreshClasses();
        }

        public CollectionDetailCell(AnnotationCollection collection)
        {
            InitializeComponent();
            Collection = context.Collections
                    .Include(c => c.Classes)
                    .Include(c => c.Images)
                    .FirstOrDefault(c => c.Id == collection.Id);

            txtName.Text = Collection.Title;
            txtPath.Text = Collection.BasePath;
            txtDescription.Text = Collection.Description;

            updateNOfMLabel();

            RefreshClasses();
        }

        private void updateNOfMLabel()
        {
            int annotated = Collection.Images.Count(i => i.State != AnnotationState.Unseen);
            lblNOfM.Text = $"{annotated} / {Collection.Images.Count} images annotated";
            pbImages.Maximum = Collection.Images.Count;
            pbImages.Value = annotated;
        }

        public void RefreshClasses()
        {
            // Refresh data
            var col = context.Collections.Include(c => c.Classes).Include(c => c.Images).FirstOrDefault(c => c.Id == Collection.Id);
            lblClasses.Text = Collection.Classes?.Count + " classes";

            checkedListBoxClasses.Items.Clear();

            checkedListBoxClasses.Items.AddRange(context.Classes.AsNoTracking().Select(c => c.ClassLabel).ToArray());
            if (col == null) {
                return;
            }
            for (int i = 0; i < checkedListBoxClasses.Items.Count; i++)
            {
                var item = checkedListBoxClasses.Items[i] as string;
                checkedListBoxClasses.SetItemChecked(i, col.Classes.Any(c => c.ClassLabel == item));
            }
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            Collection.Description = txtDescription.Text;
            context.SaveChanges();
        }

        private void txtPath_Leave(object sender, EventArgs e)
        {
            if (!txtPath.Text.EndsWith(Path.DirectorySeparatorChar)) {
                txtPath.Text += Path.DirectorySeparatorChar;
            }
            Collection.BasePath = txtPath.Text;
            if (!Directory.Exists(Collection.BasePath))
            {
                txtPath.ForeColor = Color.Red;
            }
            else 
            {
                txtPath.ForeColor = Color.Black;
                context.SaveChanges();
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            Collection.Title = txtName.Text;
            context.SaveChanges();

            CollectionChanged();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (Directory.Exists(Collection.BasePath)) {
                fbd.SelectedPath = Collection.BasePath;
            }
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK) {
                Collection.BasePath = fbd.SelectedPath;
                txtPath.Text = Collection.BasePath;
                txtPath_Leave(null, null);
            }
        }

        private void checkedListBoxClasses_Leave(object sender, EventArgs e)
        {
            Collection.Classes.Clear();
            foreach (string item in checkedListBoxClasses.CheckedItems)
            {
                var cls = context.Classes.Where(c => c.ClassLabel == item).FirstOrDefault();
                Collection.Classes.Add(cls);
            }
            context.SaveChanges();

            lblClasses.Text = Collection.Classes?.Count + " classes";

        }

        private async void btnImportPictures_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK) {
                await openFolder(fbd.SelectedPath);
                updateNOfMLabel();
                Helpers.window.UpdateProgressbar(-1, 100);
            }
        }

        private async Task openFolder(string folder)
        {
            Helpers.ImportFolder(folder, Collection, false);

            await context.SaveChangesAsync();
        }       
    }
}
