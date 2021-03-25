using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;

namespace OpenLibraryLabelImg.Model
{
    public class AnnotationClass
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
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

        [StringLength(500)]
        public string Description { get; set; }

        public ICollection<AnnotationCollection> Collections { get; set; }


        [NotMapped]
        public Color Color { get; set; }

        public bool Equals(AnnotationClass c1, AnnotationClass c2) {
            return c1.Id == c2.Id;
        }

        public int GetHashCode(AnnotationClass c1)
        {
            return c1.GetHashCode();
        }
    }
}
