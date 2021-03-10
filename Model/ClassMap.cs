using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLibraryLabelImg.Model
{
    public class ClassMap
    {
        public int AnnotationClassId { get; set; }
        public AnnotationClass AnnotationClass { get; set; }
        public int MappedId { get; set; }
    }
}
