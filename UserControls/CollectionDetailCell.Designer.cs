
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
            this.SuspendLayout();
            // 
            // checkedListBoxClasses
            // 
            this.checkedListBoxClasses.FormattingEnabled = true;
            this.checkedListBoxClasses.Location = new System.Drawing.Point(464, 158);
            this.checkedListBoxClasses.Name = "checkedListBoxClasses";
            this.checkedListBoxClasses.Size = new System.Drawing.Size(180, 116);
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
            this.txtDescription.Location = new System.Drawing.Point(6, 160);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "Description";
            this.txtDescription.Size = new System.Drawing.Size(452, 114);
            this.txtDescription.TabIndex = 14;
            this.txtDescription.Leave += new System.EventHandler(this.txtDescription_Leave);
            // 
            // lblClasses
            // 
            this.lblClasses.AutoSize = true;
            this.lblClasses.Location = new System.Drawing.Point(526, 28);
            this.lblClasses.Name = "lblClasses";
            this.lblClasses.Size = new System.Drawing.Size(81, 25);
            this.lblClasses.TabIndex = 13;
            this.lblClasses.Text = "n classes";
            // 
            // pbImages
            // 
            this.pbImages.Location = new System.Drawing.Point(297, 62);
            this.pbImages.Name = "pbImages";
            this.pbImages.Size = new System.Drawing.Size(310, 31);
            this.pbImages.TabIndex = 12;
            // 
            // lblNOfM
            // 
            this.lblNOfM.AutoSize = true;
            this.lblNOfM.Location = new System.Drawing.Point(297, 28);
            this.lblNOfM.Name = "lblNOfM";
            this.lblNOfM.Size = new System.Drawing.Size(141, 25);
            this.lblNOfM.TabIndex = 11;
            this.lblNOfM.Text = "n / m annotated";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "..";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(6, 62);
            this.txtPath.Name = "txtPath";
            this.txtPath.PlaceholderText = "Path";
            this.txtPath.Size = new System.Drawing.Size(192, 31);
            this.txtPath.TabIndex = 9;
            this.txtPath.Leave += new System.EventHandler(this.txtPath_Leave);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 25);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "Collectionname";
            this.txtName.Size = new System.Drawing.Size(242, 31);
            this.txtName.TabIndex = 8;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // btnImportPictures
            // 
            this.btnImportPictures.Location = new System.Drawing.Point(6, 109);
            this.btnImportPictures.Name = "btnImportPictures";
            this.btnImportPictures.Size = new System.Drawing.Size(173, 34);
            this.btnImportPictures.TabIndex = 16;
            this.btnImportPictures.Text = "Import Pictures";
            this.btnImportPictures.UseVisualStyleBackColor = true;
            this.btnImportPictures.Click += new System.EventHandler(this.btnImportPictures_Click);
            // 
            // CollectionDetailCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnImportPictures);
            this.Controls.Add(this.checkedListBoxClasses);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblClasses);
            this.Controls.Add(this.pbImages);
            this.Controls.Add(this.lblNOfM);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtName);
            this.MaximumSize = new System.Drawing.Size(650, 300);
            this.Name = "CollectionDetailCell";
            this.Size = new System.Drawing.Size(650, 299);
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
    }
}
