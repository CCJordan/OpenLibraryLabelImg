using OpenLibraryLabelImg.Model;
using OpenLibraryLabelImg.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenLibraryLabelImg.Forms
{
    public partial class ClassMapperWindow : Form
    {
        public int MaxId;
        public List<ClassMap> Mapping;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public ClassMapperWindow(List<ClassMap> mapping)
        {
            Logger.Info($"Opening ClassMapper with {mapping.Count} classes.");
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

            Logger.Info($"Closing ClassMapper with result OK.");
            Logger.Debug($"Result: {string.Join("", Mapping.Select(m => $"{m.AnnotationClassId} => {m.MappedId}\n").ToArray())}");

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Logger.Info($"Closing ClassMapper with result Cancel.");

            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
