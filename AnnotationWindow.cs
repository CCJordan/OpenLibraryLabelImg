using Microsoft.EntityFrameworkCore;
using OpenLibraryLabelImg.Data;
using OpenLibraryLabelImg.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLibraryLabelImg
{
    public partial class AnnotationWindow : Form
    {
        public AnnotationCollection Collection { get; private set; }
        private readonly string workingDirectory;
        private AnnotationPanel unfinishedPnl;
        private readonly List<AnnotationPanel> annotationPanels = new List<AnnotationPanel>();
        private readonly List<AnnotationImage> images;
        private AnnotationPanel selectedPanel;
        private readonly AnnotationContext context = new AnnotationContext();

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
                    SelectedClassLabel.Text = $"{annotationClasses[CurrentClass].ClassLabel}, {CurrentClass}";
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

        Size imageSize;
        private Point imageOffset;

        public AnnotationWindow(AnnotationCollection collection)
        {
            InitializeComponent();
            AllowTransparency = true;
            DoubleBuffered = false;
            Collection = context.Collections
                                    .Include(c => c.Classes)
                                    .Include(c => c.Images)
                                        .ThenInclude(i => i.Boxes)
                                    .Where(c => c.Id == collection.Id)
                                    .FirstOrDefault();
            if (Collection == null)
            {
                throw new Exception("Collection could not be found.");
            }

            Text = $"OpenLibraryLabelImg Annotator - {Collection.Title}";

            workingDirectory = Collection?.BasePath;
            openFolder(workingDirectory);
            annotationClasses = Collection.Classes.ToList();
            images = Collection.Images.ToList();
        }

        private void AnnotationWindow_Shown(object sender, EventArgs e)
        {
            if (images.Count > 0)
            {
                CurrentClass = 0;
                SetCurrentIndex(0);
            }

            int i = 0;
            foreach (AnnotationClass c in annotationClasses)
            {
                classMenu.Items.Insert(i++, new ToolStripMenuItem(c.ClassLabel));
            }
            classMenu.ItemClicked += ContextMenuStrip_ItemClicked;
            pictureBox.Invalidate(true);
            pictureBox.Update();

            Helpers.window.UpdateProgressbar(-1, 100);
        }

        private void openFolder(string folder)
        {
            Helpers.ImportFolder(folder, Collection, true);

            context.SaveChanges();
        }

        private void updateImage()
        {
            pictureBox.Image.Dispose();
            currentImage = images[CurrentIndex];
            pictureBox.Image = Image.FromFile(workingDirectory + currentImage.FileName);
            nOfMLabel.Text = $"{CurrentIndex + 1} / {images.Count}";

            while (pictureBox.Controls.Count > 0)
            {
                pictureBox.Controls[0].Dispose();
            }

            recalculateImage();

            if (currentImage.Boxes?.Count > 0)
            {
                foreach (AnnotationBox b in currentImage.Boxes)
                {
                    var panel = new AnnotationPanel(b.Class) { AnnotationBox = b };
                    panel.Visible = false;
                    pictureBox.Controls.Add(panel);
                    panel.AnnotationUpdated += updateAnnotation;
                    panel.ContextMenuStrip = classMenu;
                    panel.MouseClick += annotationPanelSelected;
                }

                pictureBox_SizeChanged(null, null);
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

        private async void AnnotationWindow_KeyDown(object sender, KeyEventArgs e)
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
                        await context.SaveChangesAsync();
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
                pnl.ContextMenuStrip = classMenu;
                // pnl.ContextMenuStrip.Click += ContextMenuStrip_ItemClicked;
                pnl.MouseMove += annotationPanelSelected;
                unfinishedPnl = pnl;
            }
        }

        private void annotationPanelSelected(object sender, EventArgs e) {
            selectedPanel = (AnnotationPanel)sender;
        }

        private void ContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Löschen")
            {
                pictureBox.Controls.Remove(selectedPanel);
                selectedPanel.Dispose();
            }
            else
            {
                selectedPanel.AnnotationBox.Class = context.Classes.Where(c => c.ClassLabel == e.ClickedItem.Text).First();
                currentImage.State = AnnotationState.Annotated;
                context.SaveChanges();
            }
            pictureBox.Invalidate();
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
            recalculateImage();
            foreach (AnnotationPanel item in pictureBox.Controls)
            {
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
