using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenLibraryLabelImg.Model
{
    public class YoloNet
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(255)]
        public string ObjFilePath { get; set; }
        [StringLength(255)]
        public string YoloFilePath { get; set; }
        [StringLength(255)]
        public string WeightFolderPath { get; set; }
        [StringLength(255)]
        public string DataFolderPath { get; set; }
        public int TargetResolution { get; set; }
        public ICollection<AnnotationCollection> Collections { get; set; }
        public ICollection<ClassMap> ClassMapping { get; set; }

        public YoloNet() {
            Collections = new List<AnnotationCollection>();
        }
    }
}
