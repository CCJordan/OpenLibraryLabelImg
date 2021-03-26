using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpenLibraryLabelImg.Model
{
    public class AnnotationBox
    {
        public int Id { get; set; }
        
        public double Width { get; set; }
        
        public double Height { get; set; }
        
        public double X { get; set; }
        
        public double Y { get; set; }

        public int ClassId { get; set; }

        public virtual AnnotationClass Class { get; set; }

        public int AnnotaionImageId { get; set; }

        public AnnotationImage AnnotaionImage { get; set; }

        [NotMapped]
        public double Area { get => Width * Height; }

        public AnnotationBox ExportAsYOLO() {
            var r = new AnnotationBox
            {
                Class = Class,
                ClassId = ClassId,
                Width = Width,
                Height = Height
            };
            r.X = X + Width / 2;
            r.Y = Y + Height / 2;
            return r;
        }
        public void ConvertFromYOLO() {
            X -= Width / 2;
            Y -= Height / 2;
        }
    }
}
