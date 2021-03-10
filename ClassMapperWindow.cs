using OpenLibraryLabelImg.Model;
using OpenLibraryLabelImg.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenLibraryLabelImg
{
    public partial class ClassMapperWindow : Form
    {
        public int MaxId;
        public List<ClassMap> Mapping;
        public ClassMapperWindow(List<ClassMap> mapping)
        {
            InitializeComponent();
            foreach (var map in mapping)
            {
                ClassMapControl classCtrl = new ClassMapControl(map.AnnotationClass, map.MappedId, mapping.Count);
                flowLayoutPanelClassMap.Controls.Add(classCtrl);
                classCtrl.Width = flowLayoutPanelClassMap.Width - 35;
                classCtrl.Anchor |= AnchorStyles.Right;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Mapping = new List<ClassMap>();
            
            foreach (ClassMapControl mapCtrl in flowLayoutPanelClassMap.Controls)
            {
                Mapping.Add(mapCtrl.Map);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
