using OpenLibraryLabelImg.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenLibraryLabelImg.UserControls
{
    public partial class ClassMapControl : UserControl
    {
        public int MaxId { get; set; }
        public ClassMap Map { get; set; }
        public ClassMapControl() {
            InitializeComponent();
        }

        public ClassMapControl(AnnotationClass mappedClass, int mappedId, int maxId) {
            InitializeComponent();
            MaxId = maxId;
            Map = new ClassMap() { AnnotationClassId = mappedClass.Id, AnnotationClass = mappedClass, MappedId = mappedId };
            lblClassLabel.Text = Map.AnnotationClass.ClassLabel;
            cmbxMapId.Text = Map.MappedId.ToString();
            for (int i = 0; i < maxId; i++)
            {
                cmbxMapId.Items.Add(i);
            }
        }

        public ClassMapControl(ClassMap map, int maxId)
        {
            InitializeComponent();
            MaxId = maxId;
            Map = map;
            lblClassLabel.Text = Map.AnnotationClass.ClassLabel;
            cmbxMapId.Text = Map.MappedId.ToString();
            for (int i = 0; i <= maxId; i++)
            {
                cmbxMapId.Items.Add(i);
            }
            cmbxMapId.SelectedIndex = cmbxMapId.Items.IndexOf(Map.MappedId);
        }

        private void cmbxMapId_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(cmbxMapId.Text, out int mappedId))
            {
                Map.MappedId = mappedId;
            }
            else
            {
                MessageBox.Show($"Your input for the class {Map.AnnotationClass.ClassLabel} could not be parsed.");
            }
        }
    }
}
