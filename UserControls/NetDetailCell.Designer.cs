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
            this.btnObjFilePath = new System.Windows.Forms.Button();
            this.btnYoloFilePath = new System.Windows.Forms.Button();
            this.btnWeigthFolderPath = new System.Windows.Forms.Button();
            this.txtWeightFolderPath = new System.Windows.Forms.TextBox();
            this.btnDataFolderPath = new System.Windows.Forms.Button();
            this.txtDataFolderPath = new System.Windows.Forms.TextBox();
            this.txtTargetXResolution = new System.Windows.Forms.TextBox();
            this.checkedListBoxCollections = new System.Windows.Forms.CheckedListBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(14, 11);
            this.txtTitle.Name = "txtTitle";
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
            this.txtYoloFilePath.Size = new System.Drawing.Size(424, 31);
            this.txtYoloFilePath.TabIndex = 3;
            this.txtYoloFilePath.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // btnObjFilePath
            // 
            this.btnObjFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObjFilePath.Location = new System.Drawing.Point(444, 46);
            this.btnObjFilePath.Name = "btnObjFilePath";
            this.btnObjFilePath.Size = new System.Drawing.Size(34, 34);
            this.btnObjFilePath.TabIndex = 4;
            this.btnObjFilePath.Text = "..";
            this.btnObjFilePath.UseVisualStyleBackColor = true;
            this.btnObjFilePath.Click += new System.EventHandler(this.btnObjFile_Click);
            // 
            // btnYoloFilePath
            // 
            this.btnYoloFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYoloFilePath.Location = new System.Drawing.Point(444, 88);
            this.btnYoloFilePath.Name = "btnYoloFilePath";
            this.btnYoloFilePath.Size = new System.Drawing.Size(34, 34);
            this.btnYoloFilePath.TabIndex = 5;
            this.btnYoloFilePath.Text = "..";
            this.btnYoloFilePath.UseVisualStyleBackColor = true;
            this.btnYoloFilePath.Click += new System.EventHandler(this.btnYoloFilePath_Click);
            // 
            // btnWeigthFolderPath
            // 
            this.btnWeigthFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWeigthFolderPath.Location = new System.Drawing.Point(444, 128);
            this.btnWeigthFolderPath.Name = "btnWeigthFolderPath";
            this.btnWeigthFolderPath.Size = new System.Drawing.Size(34, 34);
            this.btnWeigthFolderPath.TabIndex = 7;
            this.btnWeigthFolderPath.Text = "..";
            this.btnWeigthFolderPath.UseVisualStyleBackColor = true;
            this.btnWeigthFolderPath.Click += new System.EventHandler(this.btnWeigthFolderPath_Click);
            // 
            // txtWeightFolderPath
            // 
            this.txtWeightFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeightFolderPath.Location = new System.Drawing.Point(14, 130);
            this.txtWeightFolderPath.Name = "txtWeightFolderPath";
            this.txtWeightFolderPath.Size = new System.Drawing.Size(424, 31);
            this.txtWeightFolderPath.TabIndex = 6;
            this.txtWeightFolderPath.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // btnDataFolderPath
            // 
            this.btnDataFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataFolderPath.Location = new System.Drawing.Point(444, 168);
            this.btnDataFolderPath.Name = "btnDataFolderPath";
            this.btnDataFolderPath.Size = new System.Drawing.Size(34, 34);
            this.btnDataFolderPath.TabIndex = 9;
            this.btnDataFolderPath.Text = "..";
            this.btnDataFolderPath.UseVisualStyleBackColor = true;
            this.btnDataFolderPath.Click += new System.EventHandler(this.btnDataFolderPath_Click);
            // 
            // txtDataFolderPath
            // 
            this.txtDataFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataFolderPath.Location = new System.Drawing.Point(14, 170);
            this.txtDataFolderPath.Name = "txtDataFolderPath";

            this.txtDataFolderPath.Size = new System.Drawing.Size(424, 31);
            this.txtDataFolderPath.TabIndex = 8;
            this.txtDataFolderPath.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtTargetXResolution
            // 
            this.txtTargetXResolution.Location = new System.Drawing.Point(305, 214);
            this.txtTargetXResolution.Name = "txtTargetXResolution";
            this.txtTargetXResolution.Size = new System.Drawing.Size(173, 31);
            this.txtTargetXResolution.TabIndex = 10;
            this.txtTargetXResolution.Leave += new System.EventHandler(this.txt_Leave);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Target Resolution (Square) im px";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 16;
            this.button1.Text = "Train";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // NetDetailCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.checkedListBoxCollections);
            this.Controls.Add(this.txtTargetXResolution);
            this.Controls.Add(this.btnDataFolderPath);
            this.Controls.Add(this.txtDataFolderPath);
            this.Controls.Add(this.btnWeigthFolderPath);
            this.Controls.Add(this.txtWeightFolderPath);
            this.Controls.Add(this.btnYoloFilePath);
            this.Controls.Add(this.btnObjFilePath);
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
        private System.Windows.Forms.Button btnYoloFilePath;
        private System.Windows.Forms.Button btnWeigthFolderPath;
        private System.Windows.Forms.TextBox txtWeightFolderPath;
        private System.Windows.Forms.Button btnDataFolderPath;
        private System.Windows.Forms.TextBox txtDataFolderPath;
        private System.Windows.Forms.TextBox txtTargetXResolution;
        private System.Windows.Forms.CheckedListBox checkedListBoxCollections;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnObjFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
