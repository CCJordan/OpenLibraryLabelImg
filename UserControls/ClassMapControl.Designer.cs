
namespace OpenLibraryLabelImg.UserControls
{
    partial class ClassMapControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblClassLabel = new System.Windows.Forms.Label();
            this.cmbxMapId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblClassLabel
            // 
            this.lblClassLabel.AutoSize = true;
            this.lblClassLabel.Location = new System.Drawing.Point(15, 18);
            this.lblClassLabel.Name = "lblClassLabel";
            this.lblClassLabel.Size = new System.Drawing.Size(99, 25);
            this.lblClassLabel.TabIndex = 0;
            this.lblClassLabel.Text = "ClassName";
            // 
            // cmbxMapId
            // 
            this.cmbxMapId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxMapId.FormattingEnabled = true;
            this.cmbxMapId.Location = new System.Drawing.Point(285, 15);
            this.cmbxMapId.Name = "cmbxMapId";
            this.cmbxMapId.Size = new System.Drawing.Size(104, 33);
            this.cmbxMapId.TabIndex = 1;
            this.cmbxMapId.Leave += new System.EventHandler(this.cmbxMapId_Leave);
            // 
            // ClassMapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbxMapId);
            this.Controls.Add(this.lblClassLabel);
            this.Name = "ClassMapControl";
            this.Size = new System.Drawing.Size(408, 64);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClassLabel;
        private System.Windows.Forms.ComboBox cmbxMapId;
    }
}
