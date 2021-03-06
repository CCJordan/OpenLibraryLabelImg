
namespace OpenLibraryLabelImg.UserControls
{
    partial class NetDetailCell
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtObjFilePath = new System.Windows.Forms.TextBox();
            this.txtYoloFilePath = new System.Windows.Forms.TextBox();
            this.btnObjFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtWeightFolderPath = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtDataFolderPath = new System.Windows.Forms.TextBox();
            this.txtTargetXResolution = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTargetYResolution = new System.Windows.Forms.TextBox();
            this.checkedListBoxCollections = new System.Windows.Forms.CheckedListBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(14, 11);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PlaceholderText = "Title";
            this.txtTitle.Size = new System.Drawing.Size(464, 31);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(14, 259);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "Description";
            this.txtDescription.Size = new System.Drawing.Size(272, 144);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtObjFilePath
            // 
            this.txtObjFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObjFilePath.Location = new System.Drawing.Point(14, 48);
            this.txtObjFilePath.Name = "txtObjFilePath";
            this.txtObjFilePath.PlaceholderText = "obj-File Path";
            this.txtObjFilePath.Size = new System.Drawing.Size(424, 31);
            this.txtObjFilePath.TabIndex = 2;
            this.txtObjFilePath.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtYoloFilePath
            // 
            this.txtYoloFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYoloFilePath.Location = new System.Drawing.Point(14, 90);
            this.txtYoloFilePath.Name = "txtYoloFilePath";
            this.txtYoloFilePath.PlaceholderText = "yolo-File Path";
            this.txtYoloFilePath.Size = new System.Drawing.Size(424, 31);
            this.txtYoloFilePath.TabIndex = 3;
            this.txtYoloFilePath.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // btnObjFile
            // 
            this.btnObjFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObjFile.Location = new System.Drawing.Point(444, 46);
            this.btnObjFile.Name = "btnObjFile";
            this.btnObjFile.Size = new System.Drawing.Size(34, 34);
            this.btnObjFile.TabIndex = 4;
            this.btnObjFile.Text = "..";
            this.btnObjFile.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(444, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "..";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(444, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 34);
            this.button2.TabIndex = 7;
            this.button2.Text = "..";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtWeightFolderPath
            // 
            this.txtWeightFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeightFolderPath.Location = new System.Drawing.Point(14, 130);
            this.txtWeightFolderPath.Name = "txtWeightFolderPath";
            this.txtWeightFolderPath.PlaceholderText = "weight-Folder Path";
            this.txtWeightFolderPath.Size = new System.Drawing.Size(424, 31);
            this.txtWeightFolderPath.TabIndex = 6;
            this.txtWeightFolderPath.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(444, 168);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 34);
            this.button3.TabIndex = 9;
            this.button3.Text = "..";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txtDataFolderPath
            // 
            this.txtDataFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataFolderPath.Location = new System.Drawing.Point(14, 170);
            this.txtDataFolderPath.Name = "txtDataFolderPath";
            this.txtDataFolderPath.PlaceholderText = "data-Folder Path";
            this.txtDataFolderPath.Size = new System.Drawing.Size(424, 31);
            this.txtDataFolderPath.TabIndex = 8;
            this.txtDataFolderPath.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtTargetXResolution
            // 
            this.txtTargetXResolution.Location = new System.Drawing.Point(14, 216);
            this.txtTargetXResolution.Name = "txtTargetXResolution";
            this.txtTargetXResolution.PlaceholderText = "Width";
            this.txtTargetXResolution.Size = new System.Drawing.Size(81, 31);
            this.txtTargetXResolution.TabIndex = 10;
            this.txtTargetXResolution.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "x";
            // 
            // txtTargetYResolution
            // 
            this.txtTargetYResolution.Location = new System.Drawing.Point(127, 216);
            this.txtTargetYResolution.Name = "txtTargetYResolution";
            this.txtTargetYResolution.PlaceholderText = "Height";
            this.txtTargetYResolution.Size = new System.Drawing.Size(81, 31);
            this.txtTargetYResolution.TabIndex = 12;
            this.txtTargetYResolution.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // checkedListBoxCollections
            // 
            this.checkedListBoxCollections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxCollections.FormattingEnabled = true;
            this.checkedListBoxCollections.Location = new System.Drawing.Point(292, 259);
            this.checkedListBoxCollections.Name = "checkedListBoxCollections";
            this.checkedListBoxCollections.Size = new System.Drawing.Size(186, 144);
            this.checkedListBoxCollections.TabIndex = 13;
            this.checkedListBoxCollections.Leave += new System.EventHandler(this.txt_Leave);
            this.checkedListBoxCollections.MouseLeave += new System.EventHandler(this.txt_Leave);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(366, 409);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(112, 34);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // NetDetailCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.checkedListBoxCollections);
            this.Controls.Add(this.txtTargetYResolution);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTargetXResolution);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtDataFolderPath);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtWeightFolderPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnObjFile);
            this.Controls.Add(this.txtYoloFilePath);
            this.Controls.Add(this.txtObjFilePath);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTitle);
            this.MinimumSize = new System.Drawing.Size(490, 452);
            this.Name = "NetDetailCell";
            this.Size = new System.Drawing.Size(490, 452);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtObjFilePath;
        private System.Windows.Forms.TextBox txtYoloFilePath;
        private System.Windows.Forms.Button btnObjFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtWeightFolderPath;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtDataFolderPath;
        private System.Windows.Forms.TextBox txtTargetXResolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTargetYResolution;
        private System.Windows.Forms.CheckedListBox checkedListBoxCollections;
        private System.Windows.Forms.Button btnExport;
    }
}
