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
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(194, 9);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(237, 26);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(13, 242);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(245, 119);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtObjFilePath
            // 
            this.txtObjFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObjFilePath.Location = new System.Drawing.Point(194, 43);
            this.txtObjFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObjFilePath.Name = "txtObjFilePath";
            this.txtObjFilePath.Size = new System.Drawing.Size(201, 26);
            this.txtObjFilePath.TabIndex = 2;
            this.txtObjFilePath.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtYoloFilePath
            // 
            this.txtYoloFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYoloFilePath.Location = new System.Drawing.Point(194, 77);
            this.txtYoloFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtYoloFilePath.Name = "txtYoloFilePath";
            this.txtYoloFilePath.Size = new System.Drawing.Size(201, 26);
            this.txtYoloFilePath.TabIndex = 3;
            this.txtYoloFilePath.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // btnObjFilePath
            // 
            this.btnObjFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObjFilePath.Location = new System.Drawing.Point(400, 42);
            this.btnObjFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnObjFilePath.Name = "btnObjFilePath";
            this.btnObjFilePath.Size = new System.Drawing.Size(31, 30);
            this.btnObjFilePath.TabIndex = 4;
            this.btnObjFilePath.Text = "..";
            this.btnObjFilePath.UseVisualStyleBackColor = true;
            this.btnObjFilePath.Click += new System.EventHandler(this.btnObjFile_Click);
            // 
            // btnYoloFilePath
            // 
            this.btnYoloFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYoloFilePath.Location = new System.Drawing.Point(400, 75);
            this.btnYoloFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnYoloFilePath.Name = "btnYoloFilePath";
            this.btnYoloFilePath.Size = new System.Drawing.Size(31, 30);
            this.btnYoloFilePath.TabIndex = 5;
            this.btnYoloFilePath.Text = "..";
            this.btnYoloFilePath.UseVisualStyleBackColor = true;
            this.btnYoloFilePath.Click += new System.EventHandler(this.btnYoloFilePath_Click);
            // 
            // btnWeigthFolderPath
            // 
            this.btnWeigthFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWeigthFolderPath.Location = new System.Drawing.Point(400, 109);
            this.btnWeigthFolderPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWeigthFolderPath.Name = "btnWeigthFolderPath";
            this.btnWeigthFolderPath.Size = new System.Drawing.Size(31, 30);
            this.btnWeigthFolderPath.TabIndex = 7;
            this.btnWeigthFolderPath.Text = "..";
            this.btnWeigthFolderPath.UseVisualStyleBackColor = true;
            this.btnWeigthFolderPath.Click += new System.EventHandler(this.btnWeigthFolderPath_Click);
            // 
            // txtWeightFolderPath
            // 
            this.txtWeightFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeightFolderPath.Location = new System.Drawing.Point(194, 111);
            this.txtWeightFolderPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtWeightFolderPath.Name = "txtWeightFolderPath";
            this.txtWeightFolderPath.Size = new System.Drawing.Size(201, 26);
            this.txtWeightFolderPath.TabIndex = 6;
            this.txtWeightFolderPath.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // btnDataFolderPath
            // 
            this.btnDataFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataFolderPath.Location = new System.Drawing.Point(400, 144);
            this.btnDataFolderPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDataFolderPath.Name = "btnDataFolderPath";
            this.btnDataFolderPath.Size = new System.Drawing.Size(31, 30);
            this.btnDataFolderPath.TabIndex = 9;
            this.btnDataFolderPath.Text = "..";
            this.btnDataFolderPath.UseVisualStyleBackColor = true;
            this.btnDataFolderPath.Click += new System.EventHandler(this.btnDataFolderPath_Click);
            // 
            // txtDataFolderPath
            // 
            this.txtDataFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataFolderPath.Location = new System.Drawing.Point(194, 146);
            this.txtDataFolderPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDataFolderPath.Name = "txtDataFolderPath";
            this.txtDataFolderPath.Size = new System.Drawing.Size(201, 26);
            this.txtDataFolderPath.TabIndex = 8;
            this.txtDataFolderPath.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtTargetXResolution
            // 
            this.txtTargetXResolution.Location = new System.Drawing.Point(274, 181);
            this.txtTargetXResolution.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTargetXResolution.Name = "txtTargetXResolution";
            this.txtTargetXResolution.Size = new System.Drawing.Size(156, 26);
            this.txtTargetXResolution.TabIndex = 10;
            this.txtTargetXResolution.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // checkedListBoxCollections
            // 
            this.checkedListBoxCollections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxCollections.FormattingEnabled = true;
            this.checkedListBoxCollections.Location = new System.Drawing.Point(262, 242);
            this.checkedListBoxCollections.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBoxCollections.Name = "checkedListBoxCollections";
            this.checkedListBoxCollections.Size = new System.Drawing.Size(168, 119);
            this.checkedListBoxCollections.TabIndex = 13;
            this.checkedListBoxCollections.Leave += new System.EventHandler(this.txt_Leave);
            this.checkedListBoxCollections.MouseLeave += new System.EventHandler(this.txt_Leave);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(264, 371);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(167, 34);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export Images";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Target Resolution (Square) im px";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(92, 371);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 34);
            this.button2.TabIndex = 17;
            this.button2.Text = "Export Annotations";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Obj-File Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Config-File Path";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Weights-Foler Path";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Data-Folder Path";
            // 
            // NetDetailCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(441, 362);
            this.Name = "NetDetailCell";
            this.Size = new System.Drawing.Size(441, 416);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
