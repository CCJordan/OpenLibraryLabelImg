using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;

namespace OpenLibraryLabelImg.Model
{
    public class AnnotationClass
    {
        public int Id { get; set; }

        public string ClassLabel { get; set; }
        public Int32 ColorArgb
        {
            get
            {
                return Color.ToArgb();
            }
            set
            {
                Color = Color.FromArgb(value);
            }
        }

        public string Description { get; set; }

        public ICollection<AnnotationCollection> Collections { get; set; }


        [NotMapped]
        public Color Color { get; set; }
    }
}
