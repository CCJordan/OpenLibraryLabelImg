using CsvHelper;
using CsvHelper.Configuration;
using OpenLibraryLabelImg.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OpenLibraryLabelImg
{
    public static class Helpers
    {
        public static MainWindow window;
        public static readonly List<string> SupportedFileTypes = new List<string>() { ".jpg", ".png", ".gif", ".jpeg", ".bmp" };

        public static void ImportFolder(string folder, AnnotationCollection collection, bool skipExsisting)
        {
            
            if (!folder.EndsWith(Path.DirectorySeparatorChar))
            {
                folder += Path.DirectorySeparatorChar;
            }
            if (!Directory.Exists(folder))
            {
                return;
            }

            string[] files = Directory.GetFiles(folder);
            List<Model.ClassMap> mapping;
            Dictionary<int, int> idMapper = null;
            var idsFromFiles = new List<int>();
            bool needsMapping = false;
            // Scan for txt files, if encountered request classmapping from user
            for (int i = 0; i < files.Length; i++)
            {
                string filePath = files[i];
                if (filePath[filePath.LastIndexOf('.')..] == ".txt")
                {
                    needsMapping = true;
                    idsFromFiles.AddRange(importBoxes(filePath).Select(b => b.ClassId).Distinct().Where(cid => !idsFromFiles.Contains(cid)));
                }
            }

            if (collection.Classes.Count < idsFromFiles.Count) {
                MessageBox.Show($"The folder you are trying to import contains {idsFromFiles.Count} classes, which is more than your collection has. Please add {idsFromFiles.Count - collection.Classes.Count} classes to this collection.");
                return;
            }

            if (needsMapping) {
                mapping = collection.Classes.Select(c => new Model.ClassMap() { AnnotationClass = c, AnnotationClassId = c.Id, MappedId = 0 }).ToList();
                var classMapperDialog = new ClassMapperWindow(mapping);
                if (classMapperDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                mapping = classMapperDialog.Mapping;
                idMapper = mapping.ToDictionary(m => m.MappedId, m => m.AnnotationClassId);
            }

            // Import
            for (int i = 0; i < files.Length; i++)
            {
                string filePath = files[i];
                window.UpdateProgressbar(i, files.Length);
                // Check file extension
                if (!SupportedFileTypes.Contains(filePath[filePath.LastIndexOf('.')..])) {
                    continue;
                }

                var fileName = filePath[folder.Length..];
                var targetFile = collection.BasePath + fileName;
                if (folder != collection.BasePath)
                {
                    if (File.Exists(targetFile))
                    {
                        if (skipExsisting) {
                            continue;
                        }
                        var r = MessageBox.Show(text: $"File {fileName} is already present in the collection. Overwrite it?\nThe previous annotations will be kept.",
                           caption: "Duplicate File",
                           buttons: MessageBoxButtons.YesNoCancel,
                           icon: MessageBoxIcon.Warning,
                           defaultButton: MessageBoxDefaultButton.Button3);
                        if (r == DialogResult.No)
                        {
                            // skip to next file
                            continue;
                        }
                        if (r == DialogResult.Cancel)
                        {
                            // abort import
                            break;
                        }
                    }

                    File.Copy(filePath, targetFile, true);
                }

                var aImg = collection.Images.FirstOrDefault(img => img.FileName == fileName);
                if (skipExsisting && aImg != null) {
                    continue;
                }

                using (var img = Image.FromFile(targetFile))
                {
                    if (aImg == null)
                    {
                        aImg = new AnnotationImage()
                        {
                            FileName = fileName,
                            State = AnnotationState.Unseen,
                        };
                        collection.Images.Add(aImg);
                    }

                    var classFileName = filePath.Remove(filePath.LastIndexOf('.')) + ".txt";
                    if (File.Exists(classFileName))
                    {
                        importBoxes(classFileName).ForEach(b => {
                            b.Class = collection.Classes.First(c => c.Id == idMapper[b.ClassId]);
                            aImg.Boxes.Add(b);
                        });
                        aImg.State = AnnotationState.AutoAnnotated;
                    }
                }
            }
        }

        private static List<AnnotationBox> importBoxes(string classFileName)
        {
            using (TextReader reader = new StreamReader(classFileName))
            {
                var config = new CsvConfiguration(System.Globalization.CultureInfo.GetCultureInfo(1033))
                {
                    Delimiter = " ",
                    HasHeaderRecord = false,
                    NewLine = "\n",
                };

                try
                {
                    using (var csvReader = new CsvReader(reader, config))
                    {
                        csvReader.Context.RegisterClassMap<AnnotationBoxMap>();

                        var result = csvReader.GetRecords<AnnotationBox>().ToList();
                        result.ForEach(b => b.ConvertFromYOLO());
                        return result;
                    }
                }
                catch (Exception ex) {
                    return new List<AnnotationBox>();
                }
            }
        }

        public static void resize(Image image, string outputPath, int size = 350)
        {
            int width, height;
            if (image.Width > image.Height)
            {
                width = size;
                height = Convert.ToInt32(image.Height * size / (double)image.Width);
            }
            else
            {
                width = Convert.ToInt32(image.Width * size / (double)image.Height);
                height = size;
            }

            using (var resized = new Bitmap(width, height))
            {
                using (var graphics = Graphics.FromImage(resized))
                {
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.DrawImage(image, 0, 0, width, height);
                    resized.Save(outputPath);
                }
            }
        }
    }
}
