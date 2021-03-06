using OpenLibraryLabelImg.Data;
using OpenLibraryLabelImg.Model;
using OpenLibraryLabelImg.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OpenLibraryLabelImg.Forms
{
    public partial class AnnotationWindow : Form
    {
        public AnnotationCollection Collection { get; private set; }
        private readonly string workingDirectory;
        private AnnotationPanel unfinishedPnl;
        private readonly List<AnnotationPanel> annotationPanels = new List<AnnotationPanel>();
        private readonly List<AnnotationImage> images;
        private readonly AnnotationContext context = new AnnotationContext();
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly List<AnnotationClass> annotationClasses;

        private int currentClass;
        private int CurrentClass
        {
            get => currentClass;
            set
            {
                currentClass = value;
                if (annotationClasses != null)
                {
                    SelectedClassLabel.Text = $"{annotationClasses[CurrentClass].Title}, {CurrentClass}";
                }
            }
        }

        private int currentIndex;
        private int CurrentIndex
        {
            get => currentIndex;
            set
            {
                currentIndex = value;
                updateImage();
            }
        }

        private void SetCurrentIndex(int value)
        {
            CurrentIndex = value;
            updateImage();
        }

        private AnnotationImage currentImage;

        private Size imageSize;
        private Point imageOffset;

        public AnnotationWindow(AnnotationCollection collection)
        {
            InitializeComponent();
            AllowTransparency = true;
            DoubleBuffered = false;
            Collection = context.Collections
                                        .Include("Classes")
                                        .Include("Images")
                                        .Include("Images.Boxes")
                                    .Where(c => c.Id == collection.Id)
                                    .FirstOrDefault();
            if (Collection == null)
            {
                throw new Exception("Collection could not be found.");
            }

            Logger.Info($"Starting Collection window.");

            Text = $"OpenLibraryLabelImg Annotator - {Collection.Title}";

            workingDirectory = Collection?.BasePath;
            openFolder(workingDirectory);
            annotationClasses = Collection.Classes.ToList();
            images = Collection.Images.ToList();
            Logger.Info($"Details loaded.");

            Disposed += dispose;
        }

        private void dispose(object sender, EventArgs e)
        {
            pictureBox.Image.Dispose();
        }

        private void AnnotationWindow_Shown(object sender, EventArgs e)
        {
            if (images.Count > 0)
            {
                CurrentClass = 0;
                SetCurrentIndex(0);
            }

            pictureBox.Invalidate(true);
            pictureBox.Update();

            Helpers.window.UpdateProgressbar(-1, 100);
        }

        private void openFolder(string folder)
        {
            Logger.Debug($"Importing folder {folder}");
            Helpers.ImportFolder(folder, Collection, true);

            context.SaveChanges();
        }

        private void updateImage()
        {
            Logger.Info($"Updating image. Loading image id {images[CurrentIndex].Id}");

            if (pictureBox.Image != null) {
                pictureBox.Image.Dispose();
            }

            while (pictureBox.Controls.Count > 0)
            {
                pictureBox.Controls[0].Dispose();
            }

            currentImage = images[CurrentIndex];
            pictureBox.Image = Image.FromFile(workingDirectory + currentImage.FileName);
            nOfMLabel.Text = $"{CurrentIndex + 1} / {images.Count}";

            recalculateImage();

            if (currentImage.Boxes.Count > 0)
            {
                Logger.Debug($"Adding {currentImage.Boxes?.Count} boxes");
                foreach (AnnotationBox b in currentImage.Boxes)
                {
                    var panel = new AnnotationPanel(b.Class) { AnnotationBox = b };
                    panel.Visible = false;
                    pictureBox.Controls.Add(panel);

                    panel.AnnotationUpdated += updateAnnotation;
                    panel.ContextMenuStrip = new ContextMenuStrip();

                    int i = 0;
                    foreach (AnnotationClass c in annotationClasses)
                    {
                        panel.ContextMenuStrip.Items.Insert(i++, new ToolStripMenuItem(c.Title) { Checked = c.Id == b.ClassId } );
                    }
                    panel.ContextMenuStrip.Items.Insert(i, new ToolStripMenuItem("Delete"));
                    panel.ContextMenuStrip.ItemClicked += ContextMenuStrip_ItemClicked;
                }

                pictureBox_SizeChanged(null, null);
                Logger.Info($"Redrew picturebox.");
            }
        }

        private void recalculateImage()
        {
            // breite > höhe
            double aspectRatioPictureBox = (double)pictureBox.Width / pictureBox.Height;
            double aspectRatioImage = (double)pictureBox.Image.Width / pictureBox.Image.Height;

            if (aspectRatioImage < aspectRatioPictureBox)
            {
                double height = pictureBox.Image.Height * (double)pictureBox.Height / pictureBox.Image.Height;
                imageSize = new Size((int)(height * aspectRatioImage), (int)height);

                imageOffset = new Point((pictureBox.Width - imageSize.Width) / 2, 0);
            }
            else
            {
                double width = pictureBox.Image.Width * (double)pictureBox.Width / pictureBox.Image.Width;
                imageSize = new Size((int)width, (int)(width / aspectRatioImage));
                imageOffset = new Point(0, (pictureBox.Height - imageSize.Height) / 2);
            }
        }

        private void updateAnnotation(AnnotationBox box, AnnotationPanel panel)
        {
            panel.AnnotationBox.Width = (double)panel.Width / imageSize.Width;
            panel.AnnotationBox.Height = (double)panel.Height / imageSize.Height;
            panel.AnnotationBox.X = ((double)panel.Location.X - imageOffset.X) / imageSize.Width;
            panel.AnnotationBox.Y = ((double)panel.Location.Y - imageOffset.Y) / imageSize.Height;
            currentImage.State = AnnotationState.Annotated;
            context.SaveChanges();
        }

        private void AnnotationWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    SetCurrentIndex((CurrentIndex + 1) % images.Count);
                    break;
                case Keys.A:
                    SetCurrentIndex(CurrentIndex == 0 ? images.Count - 1 : --CurrentIndex);
                    break;

                case Keys.W:
                    CurrentClass = (currentClass + 1) % annotationClasses.Count;
                    break;
                case Keys.S:
                    CurrentClass = currentClass == 0 ? annotationClasses.Count - 1 : --currentClass;
                    break;

                case Keys.Space:
                    if (currentImage.State != AnnotationState.Annotated) {
                        currentImage.State = AnnotationState.Annotated;
                        context.SaveChanges();
                        pictureBox_SizeChanged(null, null);
                    }
                    break;
                default:
                    break;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var o = sender as PictureBox;
                var pnl = new AnnotationPanel(annotationClasses[currentClass]);
                currentImage.Boxes.Add(pnl.AnnotationBox);
                pnl.AnnotationBox.AnnotaionImage = currentImage;
                pictureBox.Controls.Add(pnl);

                pnl.GrappingPointToScreen = o.PointToScreen(e.Location);
                pnl.CurrentState = AnnotationPanel.State.ResizingSE;
                pnl.grappingPosition = e.Location;
                pnl.GrappedSize = new Point(15, 15);
                pnl.SetBounds(e.X, e.Y, 15, 15);
                pnl.AnnotationUpdated += updateAnnotation;
                pnl.ContextMenuStrip = new ContextMenuStrip();
                int i = 0;
                foreach (AnnotationClass c in annotationClasses)
                {
                    pnl.ContextMenuStrip.Items.Insert(i++, new ToolStripMenuItem(c.Title) { Checked = c.Id == currentClass });
                }
                pnl.ContextMenuStrip.Items.Insert(i, new ToolStripMenuItem("Delete"));
                pnl.ContextMenuStrip.ItemClicked += ContextMenuStrip_ItemClicked;
                
                unfinishedPnl = pnl;
            }
        }

        private void ContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var p = (ContextMenuStrip)sender;

            AnnotationPanel parent = ((AnnotationPanel)p.SourceControl);
            

            if (e.ClickedItem.Text == "Delete")
            {
                AnnotationBox annotationBox = parent.AnnotationBox;
                Logger.Debug($"Deleting Annotation {annotationBox.Id} with class id {annotationBox.Class.Id}");
                pictureBox.Controls.Remove(p.SourceControl);
                
                var img = annotationBox.AnnotaionImage;
                img.Boxes.Remove(annotationBox);
                context.Boxes.Remove(annotationBox);
                p.SourceControl.Dispose();
            }
            else
            {
                Logger.Debug($"Changing Annotation {parent.AnnotationBox.Id} with class id {parent.AnnotationBox.Class.Id} to class {e.ClickedItem.Text}");
                parent.AnnotationBox.Class = context.Classes.Where(c => c.Title == e.ClickedItem.Text).First();
                foreach (ToolStripMenuItem item in parent.ContextMenuStrip.Items) {
                    item.Checked = item.Text == parent.AnnotationBox.Class.Title;
                }
            }
            currentImage.State = AnnotationState.Annotated;
            context.SaveChanges();
            pictureBox_SizeChanged(null, null);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (unfinishedPnl != null)
            {
                unfinishedPnl.mouseMoveHandler(unfinishedPnl, e, true);
            }
        }

        private async void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (unfinishedPnl != null)
            {
                unfinishedPnl.mouseUpHandler(unfinishedPnl, e);
                annotationPanels.Add(unfinishedPnl);
                unfinishedPnl = null;
                currentImage.State = AnnotationState.Annotated;
                await context.SaveChangesAsync();
            }
        }

        private void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            if (pictureBox.Image == null) {
                return;
            }

            recalculateImage();
            var panelList = new List<AnnotationPanel>();
            foreach (AnnotationPanel item in pictureBox.Controls) {
                var index = panelList.FindIndex(b => b.AnnotationBox.Area < item.AnnotationBox.Area);
                if (index == -1) {
                    panelList.Add(item);
                } else {
                    panelList.Insert(index + 1, item);
                }
            }

            var i = 0;
            foreach (AnnotationPanel item in panelList)
            {
                pictureBox.Controls.SetChildIndex(item, i++);
                item.Width = (int)(imageSize.Width * item.AnnotationBox.Width);
                item.Height = (int)(imageSize.Height * item.AnnotationBox.Height);
                item.Location = new Point((int)(item.AnnotationBox.X * imageSize.Width + imageOffset.X), (int)(item.AnnotationBox.Y * imageSize.Height + imageOffset.Y));
                item.Visible = true;
            }

            pictureBox.Invalidate(true);
            pictureBox.Update();
        }
    }
}
