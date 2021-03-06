namespace OpenLibraryLabelImg.Forms
{
    partial class AnnotationWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.nOfMLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SelectedClassLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.classMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.classMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nOfMLabel,
            this.SelectedClassLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 788);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1427, 32);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // nOfMLabel
            // 
            this.nOfMLabel.Name = "nOfMLabel";
            this.nOfMLabel.Size = new System.Drawing.Size(55, 25);
            this.nOfMLabel.Text = "n / m";
            // 
            // SelectedClassLabel
            // 
            this.SelectedClassLabel.Name = "SelectedClassLabel";
            this.SelectedClassLabel.Size = new System.Drawing.Size(142, 25);
            this.SelectedClassLabel.Text = "Selected Class, 0";
            // 
            // classMenu
            // 
            this.classMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.classMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6});
            this.classMenu.Name = "classMenu";
            this.classMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.classMenu.Size = new System.Drawing.Size(192, 36);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.toolStripMenuItem6.Size = new System.Drawing.Size(191, 32);
            this.toolStripMenuItem6.Text = "Löschen";
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1427, 788);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // AnnotationWindow
            // 
            this.ClientSize = new System.Drawing.Size(1427, 820);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.statusStrip1);
            this.Name = "AnnotationWindow";
            this.Shown += new System.EventHandler(this.AnnotationWindow_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnnotationWindow_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.classMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel nOfMLabel;
        private System.Windows.Forms.ToolStripStatusLabel SelectedClassLabel;
        private System.Windows.Forms.ContextMenuStrip classMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

