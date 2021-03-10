using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLibraryLabelImg.Model
{
    public class YoloNet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ObjFilePath { get; set; }
        public string YoloFilePath { get; set; }
        public string WeightFolderPath { get; set; }
        public string DataFolderPath { get; set; }
        public int TargetResolution { get; set; }
        public ICollection<AnnotationCollection> Collections { get; set; }
        public ICollection<ClassMap> ClassMapping { get; set; }

        public YoloNet() {
        }
    }
}
