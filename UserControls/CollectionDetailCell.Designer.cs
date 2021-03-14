
namespace OpenLibraryLabelImg.UserControls
{
    partial class CollectionDetailCell
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
            this.checkedListBoxClasses = new System.Windows.Forms.CheckedListBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblClasses = new System.Windows.Forms.Label();
            this.pbImages = new System.Windows.Forms.ProgressBar();
            this.lblNOfM = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnImportPictures = new System.Windows.Forms.Button();
            this.btnImportAnnotations = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxClasses
            // 
            this.checkedListBoxClasses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxClasses.FormattingEnabled = true;
            this.checkedListBoxClasses.Location = new System.Drawing.Point(393, 128);
            this.checkedListBoxClasses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBoxClasses.Name = "checkedListBoxClasses";
            this.checkedListBoxClasses.Size = new System.Drawing.Size(178, 96);
            this.checkedListBoxClasses.TabIndex = 15;
            this.checkedListBoxClasses.Leave += new System.EventHandler(this.checkedListBoxClasses_Leave);
            this.checkedListBoxClasses.MouseLeave += new System.EventHandler(this.checkedListBoxClasses_Leave);
            // 
            // txtDescription
            // 
            this.txtDescription.AcceptsReturn = true;
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(5, 128);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(382, 97);
            this.txtDescription.TabIndex = 14;
            this.txtDescription.Leave += new System.EventHandler(this.txtDescription_Leave);
            // 
            // lblClasses
            // 
            this.lblClasses.AutoSize = true;
            this.lblClasses.Location = new System.Drawing.Point(473, 22);
            this.lblClasses.Name = "lblClasses";
            this.lblClasses.Size = new System.Drawing.Size(75, 20);
            this.lblClasses.TabIndex = 13;
            this.lblClasses.Text = "n classes";
            // 
            // pbImages
            // 
            this.pbImages.Location = new System.Drawing.Point(267, 50);
            this.pbImages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbImages.Name = "pbImages";
            this.pbImages.Size = new System.Drawing.Size(279, 26);
            this.pbImages.TabIndex = 12;
            // 
            // lblNOfM
            // 
            this.lblNOfM.AutoSize = true;
            this.lblNOfM.Location = new System.Drawing.Point(267, 22);
            this.lblNOfM.Name = "lblNOfM";
            this.lblNOfM.Size = new System.Drawing.Size(120, 20);
            this.lblNOfM.TabIndex = 11;
            this.lblNOfM.Text = "n / m annotated";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 35);
            this.button1.TabIndex = 10;
            this.button1.Text = "..";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(5, 50);
            this.txtPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(173, 26);
            this.txtPath.TabIndex = 9;
            this.txtPath.Leave += new System.EventHandler(this.txtPath_Leave);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(5, 20);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(218, 26);
            this.txtName.TabIndex = 8;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // btnImportPictures
            // 
            this.btnImportPictures.Location = new System.Drawing.Point(5, 87);
            this.btnImportPictures.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImportPictures.Name = "btnImportPictures";
            this.btnImportPictures.Size = new System.Drawing.Size(156, 27);
            this.btnImportPictures.TabIndex = 16;
            this.btnImportPictures.Text = "Import Pictures";
            this.btnImportPictures.UseVisualStyleBackColor = true;
            this.btnImportPictures.Click += new System.EventHandler(this.btnImportPictures_Click);
            // 
            // btnImportAnnotations
            // 
            this.btnImportAnnotations.Location = new System.Drawing.Point(166, 87);
            this.btnImportAnnotations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImportAnnotations.Name = "btnImportAnnotations";
            this.btnImportAnnotations.Size = new System.Drawing.Size(156, 27);
            this.btnImportAnnotations.TabIndex = 17;
            this.btnImportAnnotations.Text = "Import Annotations";
            this.btnImportAnnotations.UseVisualStyleBackColor = true;
            this.btnImportAnnotations.Click += new System.EventHandler(this.btnImportAnnotations_Click);
            // 
            // CollectionDetailCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnImportAnnotations);
            this.Controls.Add(this.btnImportPictures);
            this.Controls.Add(this.checkedListBoxClasses);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblClasses);
            this.Controls.Add(this.pbImages);
            this.Controls.Add(this.lblNOfM);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(585, 99999);
            this.Name = "CollectionDetailCell";
            this.Size = new System.Drawing.Size(585, 244);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxClasses;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblClasses;
        private System.Windows.Forms.ProgressBar pbImages;
        private System.Windows.Forms.Label lblNOfM;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnImportPictures;
        private System.Windows.Forms.Button btnImportAnnotations;
    }
}
