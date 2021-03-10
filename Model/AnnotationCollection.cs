using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace OpenLibraryLabelImg.Model
{
    public class AnnotationCollection
    {
        public int Id { get; set; }
        [DefaultValue("")]
        public string Title { get; set; }
        public ICollection<AnnotationImage> Images { get; set; }
        public ICollection<AnnotationClass> Classes { get; set; }
        public ICollection<YoloNet> Nets{ get; set; }
        [DefaultValue("")]
        public string Description { get; set; }
        [DefaultValue("")]
        public string BasePath { get; set; }

        public AnnotationCollection() {
        }
    }
}
