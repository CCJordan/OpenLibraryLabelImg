using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenLibraryLabelImg.Model
{
    public class AnnotationCollection
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        public ICollection<AnnotationImage> Images { get; set; }
        public ICollection<AnnotationClass> Classes { get; set; }
        public ICollection<YoloNet> Nets{ get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(255)]
        public string BasePath { get; set; }

        public AnnotationCollection() {
        }
    }
}
