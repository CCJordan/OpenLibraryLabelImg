using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using OpenLibraryLabelImg.Model;
using System.IO;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace OpenLibraryLabelImg
{
    public static class Helpers
    {
        public static MainWindow window;
        public static readonly List<string> SupportedFileTypes = new List<string>() { ".jpg", ".png", ".gif", ".jpeg", ".bmp" };

        public static void ImportFolder(string folder, AnnotationCollection collection, bool skipExsisting)
        {
            if (!folder.EndsWith('\\'))
            {
                folder += "\\";
            }
            if (!Directory.Exists(folder))
            {
                return;
            }

            string[] fs = Directory.GetFiles(folder);
            for (int i = 0; i < fs.Length; i++)
            {
                string f = fs[i];
                window.UpdateProgressbar(i, fs.Length);
                // Check file extension
                if (!SupportedFileTypes.Contains(f[f.LastIndexOf('.')..])) {
                    continue;
                }

                var fileName = f[folder.Length..];
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

                    File.Copy(f, targetFile, true);
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
                            ResolutionX = img.Width,
                            ResolutionY = img.Height
                        };
                        collection.Images.Add(aImg);
                    }
                    else
                    {
                        aImg.ResolutionX = img.Width;
                        aImg.ResolutionY = img.Height;
                    }

                    var classFileName = f.Remove(f.LastIndexOf('.')) + ".txt";
                    if (File.Exists(classFileName))
                    {
                        importBoxes(classFileName).ForEach(b => {
                            b.Class = collection.Classes.First(c => c.Id == b.ClassId + 1);
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
                    MissingFieldFound = null,
                    
                };

                using (var csvReader = new CsvReader(reader, config))
                {
                    csvReader.Context.RegisterClassMap<AnnotationBoxMap>();

                    var result = csvReader.GetRecords<AnnotationBox>().ToList();
                    result.ForEach(b => b.ConvertFromYOLO());
                    return result;
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
