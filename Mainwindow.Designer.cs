namespace OpenLibraryLabelImg
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddCollection = new System.Windows.Forms.Button();
            this.btnRemoveCollection = new System.Windows.Forms.Button();
            this.pnlCollectionDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.btnRemoveClass = new System.Windows.Forms.Button();
            this.pnlClasses = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRemoveNetwork = new System.Windows.Forms.Button();
            this.pnlNetworks = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddNetwork = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddCollection
            // 
            this.btnAddCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddCollection.Location = new System.Drawing.Point(666, 951);
            this.btnAddCollection.Name = "btnAddCollection";
            this.btnAddCollection.Size = new System.Drawing.Size(34, 34);
            this.btnAddCollection.TabIndex = 1;
            this.btnAddCollection.Text = "+";
            this.btnAddCollection.UseVisualStyleBackColor = true;
            this.btnAddCollection.Click += new System.EventHandler(this.btnAddCollection_Click);
            // 
            // btnRemoveCollection
            // 
            this.btnRemoveCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveCollection.Location = new System.Drawing.Point(626, 951);
            this.btnRemoveCollection.Name = "btnRemoveCollection";
            this.btnRemoveCollection.Size = new System.Drawing.Size(34, 34);
            this.btnRemoveCollection.TabIndex = 2;
            this.btnRemoveCollection.Text = "-";
            this.btnRemoveCollection.UseVisualStyleBackColor = true;
            this.btnRemoveCollection.Click += new System.EventHandler(this.btnRemoveCollection_Click);
            // 
            // pnlCollectionDetails
            // 
            this.pnlCollectionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlCollectionDetails.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlCollectionDetails.Location = new System.Drawing.Point(12, 30);
            this.pnlCollectionDetails.Name = "pnlCollectionDetails";
            this.pnlCollectionDetails.Size = new System.Drawing.Size(688, 915);
            this.pnlCollectionDetails.TabIndex = 3;
            // 
            // btnAddClass
            // 
            this.btnAddClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddClass.Location = new System.Drawing.Point(509, 914);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(34, 34);
            this.btnAddClass.TabIndex = 5;
            this.btnAddClass.Text = "+";
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // btnRemoveClass
            // 
            this.btnRemoveClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveClass.Location = new System.Drawing.Point(469, 914);
            this.btnRemoveClass.Name = "btnRemoveClass";
            this.btnRemoveClass.Size = new System.Drawing.Size(34, 34);
            this.btnRemoveClass.TabIndex = 6;
            this.btnRemoveClass.Text = "-";
            this.btnRemoveClass.UseVisualStyleBackColor = true;
            this.btnRemoveClass.Click += new System.EventHandler(this.btnRemoveClass_Click);
            // 
            // pnlClasses
            // 
            this.pnlClasses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlClasses.Location = new System.Drawing.Point(-4, 0);
            this.pnlClasses.Name = "pnlClasses";
            this.pnlClasses.Size = new System.Drawing.Size(550, 908);
            this.pnlClasses.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1609, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(554, 999);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnRemoveClass);
            this.tabPage1.Controls.Add(this.pnlClasses);
            this.tabPage1.Controls.Add(this.btnAddClass);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(546, 961);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Classes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRemoveNetwork);
            this.tabPage2.Controls.Add(this.pnlNetworks);
            this.tabPage2.Controls.Add(this.btnAddNetwork);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(546, 961);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Yolo Nets";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRemoveNetwork
            // 
            this.btnRemoveNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveNetwork.Location = new System.Drawing.Point(471, 920);
            this.btnRemoveNetwork.Name = "btnRemoveNetwork";
            this.btnRemoveNetwork.Size = new System.Drawing.Size(34, 34);
            this.btnRemoveNetwork.TabIndex = 9;
            this.btnRemoveNetwork.Text = "-";
            this.btnRemoveNetwork.UseVisualStyleBackColor = true;
            this.btnRemoveNetwork.Click += new System.EventHandler(this.btnRemoveNetwork_Click);
            // 
            // pnlNetworks
            // 
            this.pnlNetworks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNetworks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlNetworks.Location = new System.Drawing.Point(6, 6);
            this.pnlNetworks.Name = "pnlNetworks";
            this.pnlNetworks.Size = new System.Drawing.Size(527, 908);
            this.pnlNetworks.TabIndex = 10;
            this.pnlNetworks.WrapContents = false;
            // 
            // btnAddNetwork
            // 
            this.btnAddNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddNetwork.Location = new System.Drawing.Point(511, 920);
            this.btnAddNetwork.Name = "btnAddNetwork";
            this.btnAddNetwork.Size = new System.Drawing.Size(34, 34);
            this.btnAddNetwork.TabIndex = 8;
            this.btnAddNetwork.Text = "+";
            this.btnAddNetwork.UseVisualStyleBackColor = true;
            this.btnAddNetwork.Click += new System.EventHandler(this.btnAddNetwork_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1001);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(2175, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 24);
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(179, 25);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2175, 1023);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlCollectionDetails);
            this.Controls.Add(this.btnRemoveCollection);
            this.Controls.Add(this.btnAddCollection);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddCollection;
        private System.Windows.Forms.Button btnRemoveCollection;
        private System.Windows.Forms.FlowLayoutPanel pnlCollectionDetails;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.Button btnRemoveClass;
        private System.Windows.Forms.FlowLayoutPanel pnlClasses;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnRemoveNetwork;
        private System.Windows.Forms.FlowLayoutPanel pnlNetworks;
        private System.Windows.Forms.Button btnAddNetwork;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}