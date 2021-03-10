using OpenLibraryLabelImg.Model;
using System.Collections.Generic;
using System.Drawing;

namespace OpenLibraryLabelImg.Model
{
    public class AnnotationImage
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public ICollection<AnnotationBox> Boxes { get; set; }
        public AnnotationState State { get; set; }
        public bool Excluded { get; set; }

        public AnnotationImage() {
            State = AnnotationState.Unseen;
            Boxes = new List<AnnotationBox>();
        }
    }
}