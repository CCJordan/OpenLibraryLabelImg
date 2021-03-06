using OpenLibraryLabelImg.Model;
using CsvHelper.Configuration;

namespace OpenLibraryLabelImg
{
    public class AnnotationBoxMap : ClassMap<AnnotationBox> {
        public AnnotationBoxMap() {
            Map(a => a.ClassId).Index(0);
            Map(a => a.X).Index(1);
            Map(a => a.Y).Index(2);
            Map(a => a.Width).Index(3);
            Map(a => a.Height).Index(4);
            Map(a => a.Id).Ignore();
        }
    }
}
