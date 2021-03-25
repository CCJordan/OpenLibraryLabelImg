using OpenLibraryLabelImg.Data;
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
    public partial class ClassDetailCell : UserControl
    {
        public event Action ClassLabelChanged;
        private readonly AnnotationClass cls;
        private readonly AnnotationContext context;

        public AnnotationClass Class { get => cls; }

        public ClassDetailCell()
        {
            InitializeComponent();
        }

        public ClassDetailCell(AnnotationClass cls, AnnotationContext ctx)
        {
            InitializeComponent();

            this.cls = cls;
            context = ctx;
            btnColor.BackColor = cls.Color;
            txtClassLabel.Text = cls.Title;
            txtDescription.Text = cls.Description;
        }

        private async void txtClassLabel_Leave(object sender, EventArgs e)
        {
            cls.Title = txtClassLabel.Text;
            await context.SaveChangesAsync();
            ClassLabelChanged();
        }

        private async void btnColor_Click(object sender, EventArgs e)
        {
            var colorPicker = new ColorDialog
            {
                Color = cls.Color
            };
            if (colorPicker.ShowDialog() == DialogResult.OK) {
                cls.Color = colorPicker.Color;
                btnColor.BackColor = cls.Color;
                await context.SaveChangesAsync();
            }
        }

        private async void txtDescription_Leave(object sender, EventArgs e)
        {
            cls.Description = txtDescription.Text;
            await context.SaveChangesAsync();
        }
    }
}
