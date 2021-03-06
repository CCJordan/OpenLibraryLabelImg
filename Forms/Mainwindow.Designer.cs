namespace OpenLibraryLabelImg.Forms
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddCollection
            // 
            this.btnAddCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddCollection.Location = new System.Drawing.Point(599, 779);
            this.btnAddCollection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddCollection.Name = "btnAddCollection";
            this.btnAddCollection.Size = new System.Drawing.Size(31, 39);
            this.btnAddCollection.TabIndex = 1;
            this.btnAddCollection.Text = "+";
            this.btnAddCollection.UseVisualStyleBackColor = true;
            this.btnAddCollection.Click += new System.EventHandler(this.btnAddCollection_Click);
            // 
            // btnRemoveCollection
            // 
            this.btnRemoveCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveCollection.Location = new System.Drawing.Point(563, 779);
            this.btnRemoveCollection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveCollection.Name = "btnRemoveCollection";
            this.btnRemoveCollection.Size = new System.Drawing.Size(31, 39);
            this.btnRemoveCollection.TabIndex = 2;
            this.btnRemoveCollection.Text = "-";
            this.btnRemoveCollection.UseVisualStyleBackColor = true;
            this.btnRemoveCollection.Click += new System.EventHandler(this.btnRemoveCollection_Click);
            // 
            // pnlCollectionDetails
            // 
            this.pnlCollectionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlCollectionDetails.AutoScroll = true;
            this.pnlCollectionDetails.Location = new System.Drawing.Point(11, 24);
            this.pnlCollectionDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCollectionDetails.Name = "pnlCollectionDetails";
            this.pnlCollectionDetails.Size = new System.Drawing.Size(619, 751);
            this.pnlCollectionDetails.TabIndex = 3;
            // 
            // btnAddClass
            // 
            this.btnAddClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddClass.Location = new System.Drawing.Point(458, 740);
            this.btnAddClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(31, 39);
            this.btnAddClass.TabIndex = 5;
            this.btnAddClass.Text = "+";
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // btnRemoveClass
            // 
            this.btnRemoveClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveClass.Location = new System.Drawing.Point(422, 740);
            this.btnRemoveClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveClass.Name = "btnRemoveClass";
            this.btnRemoveClass.Size = new System.Drawing.Size(31, 39);
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
            this.pnlClasses.AutoScroll = true;
            this.pnlClasses.Location = new System.Drawing.Point(-4, 0);
            this.pnlClasses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlClasses.Name = "pnlClasses";
            this.pnlClasses.Size = new System.Drawing.Size(495, 736);
            this.pnlClasses.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1416, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(499, 823);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnRemoveClass);
            this.tabPage1.Controls.Add(this.pnlClasses);
            this.tabPage1.Controls.Add(this.btnAddClass);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(491, 790);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Classes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRemoveNetwork);
            this.tabPage2.Controls.Add(this.pnlNetworks);
            this.tabPage2.Controls.Add(this.btnAddNetwork);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(491, 790);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Yolo Nets";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRemoveNetwork
            // 
            this.btnRemoveNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveNetwork.Location = new System.Drawing.Point(418, 701);
            this.btnRemoveNetwork.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveNetwork.Name = "btnRemoveNetwork";
            this.btnRemoveNetwork.Size = new System.Drawing.Size(31, 39);
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
            this.pnlNetworks.AutoScroll = true;
            this.pnlNetworks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlNetworks.Location = new System.Drawing.Point(5, 5);
            this.pnlNetworks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlNetworks.Name = "pnlNetworks";
            this.pnlNetworks.Size = new System.Drawing.Size(480, 692);
            this.pnlNetworks.TabIndex = 10;
            this.pnlNetworks.WrapContents = false;
            // 
            // btnAddNetwork
            // 
            this.btnAddNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddNetwork.Location = new System.Drawing.Point(454, 701);
            this.btnAddNetwork.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddNetwork.Name = "btnAddNetwork";
            this.btnAddNetwork.Size = new System.Drawing.Size(31, 39);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 825);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1925, 32);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripProgressBar.Size = new System.Drawing.Size(90, 24);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(179, 25);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(636, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(778, 808);
            this.splitContainer1.SplitterDistance = 417;
            this.splitContainer1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Here be diagrams.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Here be diagrams.";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1925, 857);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlCollectionDetails);
            this.Controls.Add(this.btnRemoveCollection);
            this.Controls.Add(this.btnAddCollection);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}