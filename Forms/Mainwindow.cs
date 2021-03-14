using OpenLibraryLabelImg.Data;
using System.Windows.Forms.DataVisualization.Charting;
using OpenLibraryLabelImg.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenLibraryLabelImg.UserControls;
using System.Reflection;
using System.Data.Entity;
using AnnotationCollection = OpenLibraryLabelImg.Model.AnnotationCollection;

namespace OpenLibraryLabelImg.Forms
{
    public partial class MainWindow : Form
    {
        private const int scrollBarWidth = 35;
        private readonly AnnotationContext context = new AnnotationContext();
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private AnnotationClass selectedClass;
        private AnnotationCollection selectedCollection;
        private YoloNet selectedNetwork;
        private AnnotationWindow window;
        // TODO: Write Documentation
        // TODO: Write ReadMe File
        // TODO: Internationalisierung
        public MainWindow()
        {
            InitializeComponent();
            Text = "OpenLibraryLabelImg - 0.1";
            Helpers.window = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Logger.Info($"{Assembly.GetExecutingAssembly().GetName()} starting up.");

            var collections = context.Collections.Include(c => c.Classes).Include(c => c.Images).Include("Images.Boxes").Include("Images.Boxes.Class").ToList();
            Logger.Debug($"Loaded {collections.Count} collections");
            foreach (var collection in collections)
            {
                var details = new CollectionDetailCell(collection);
                if (selectedCollection == null) {
                    selectedCollection = collection;
                    details.BackColor = Color.DarkGray;
                    updateCollectionDiagrams();
                }
                details.Click += selectCollection;
                details.CollectionChanged += updateCollections;
                details.DoubleClick += openCollection;
                pnlCollectionDetails.Controls.Add(details);
                details.Width = pnlCollectionDetails.Width - scrollBarWidth;
            }

            var classes = context.Classes.ToList();
            Logger.Debug($"Loaded {classes.Count} classes");
            foreach (var cls in classes)
            {
                var details = new ClassDetailCell(cls, context);
                details.Click += selectClass;
                details.ClassLabelChanged += updateClassLists;
                pnlClasses.Controls.Add(details);
                details.Width = pnlClasses.Width - scrollBarWidth;
            }

            var nets = context.Nets.Include(n => n.Collections).Include(n => n.ClassMapping).ToList();
            Logger.Debug($"Loaded {nets.Count} nets");
            foreach (var net in nets)
            {
                var details = new NetDetailCell(net, context);
                details.Click += selectNet;
                pnlNetworks.Controls.Add(details);
                details.Width = pnlNetworks.Width - scrollBarWidth;
            }
        }

        private void selectCollection(object sender, EventArgs e) {
            foreach (CollectionDetailCell ctrl in pnlCollectionDetails.Controls)
            {
                if (ctrl == sender)
                {
                    ctrl.BackColor = Color.DarkGray;
                    selectedCollection = ctrl.Collection;
                    updateCollectionDiagrams();
                }
                else
                {
                    ctrl.BackColor = Color.FromKnownColor(KnownColor.Control);
                }
            }
        }

        private void selectClass(object sender, EventArgs e)
        {
            foreach (ClassDetailCell ctrl in pnlClasses.Controls)
            {
                if (ctrl == sender)
                {
                    ctrl.BackColor = Color.DarkGray;
                    selectedClass = ctrl.Class;
                }
                else
                {
                    ctrl.BackColor = Color.FromKnownColor(KnownColor.Control);
                }
            }
        }

        private void updateCollectionDiagrams() {
            var collection = context.Collections.Include(c => c.Classes).Include(c => c.Images).Include("Images.Boxes").Include("Images.Boxes.Class").First(c => c.Id == selectedCollection.Id);
            classDistributionChart.Series.Clear();
            var images = collection.Images;
            var classes = collection.Images.SelectMany(img => img.Boxes).Select(b => b.Class);
            int i = 0;
            foreach (var c in collection.Classes)
            {
                var s1 = new Series(c.Title) { Color = c.Color, AxisLabel = c.Title, ChartType = SeriesChartType.Column };
                s1.Points.AddXY(i++, classes.Where(cl => cl.Id == c.Id).Count());
                classDistributionChart.Series.Add(s1);
                classDistributionChart.Legends.Clear();
            }

            chartAnnotationState.Series.Clear();
            i = 0;
            
            var s = new Series("Annotated") { Color = Color.Green, AxisLabel = "Annotated", ChartType = SeriesChartType.Pie };
            s.Points.AddXY(i++, images.Where(img => img.State == AnnotationState.Annotated).Count());
            chartAnnotationState.Series.Add(s);
            s = new Series("AutoAnnotated") { Color = Color.Green, AxisLabel = "AutoAnnotated", ChartType = SeriesChartType.Pie };
            s.Points.AddXY(i++, images.Where(img => img.State == AnnotationState.AutoAnnotated).Count());
            chartAnnotationState.Series.Add(s);
            s = new Series("Unseen") { Color = Color.Green, AxisLabel = "Unseen", ChartType = SeriesChartType.Pie };
            s.Points.AddXY(i++, images.Where(img => img.State == AnnotationState.Unseen).Count());
            chartAnnotationState.Series.Add(s);
            chartAnnotationState.Legends.Clear();
            
        }

        private void selectNet(object sender, EventArgs e)
        {
            foreach (NetDetailCell ctrl in pnlNetworks.Controls)
            {
                if (ctrl == sender)
                {
                    ctrl.BackColor = Color.DarkGray;
                    selectedNetwork= ctrl.Net;
                }
                else
                {
                    ctrl.BackColor = Color.FromKnownColor(KnownColor.Control);
                }
            }
        }

        private void openCollection(object sender, EventArgs e) {
            if (context.Classes.Count() == 0)
            {
                MessageBox.Show("There are no classes yet. Please create at least one to continue.");
                Logger.Debug($"User tried to open a collection without classes.");
                return;
            }

            var details = sender as CollectionDetailCell;
            Logger.Debug($"Opening collection {details.Collection.Id} ");
            if (window != null) {
                window.Dispose();
            }

            window = new AnnotationWindow(details.Collection);
            window.Show();
            window.FormClosed += annotationWindowClosed;
            Logger.Debug($"Opened collection \"{details.Collection.Title}\" containing {details.Collection.Images.Count} and {details.Collection.Classes.Count} classes.");
        }

        private void annotationWindowClosed(object sender, EventArgs e) {
            Logger.Debug($"Annotation Window closed");
            updateCollections();
            window.Dispose();
            Logger.Debug($"Annotation Window closed, window disposed, data saved");
        }

        private void btnAddCollection_Click(object sender, EventArgs e)
        {
            Logger.Debug($"Adding collection.");
            var details = new CollectionDetailCell();
            details.CollectionChanged += updateCollections;
            details.Click += selectCollection;
            details.DoubleClick += openCollection;
            pnlCollectionDetails.Controls.Add(details);
            Logger.Debug($"Added collection.");
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            Logger.Debug("Adding class");
            var Class = new AnnotationClass();
            context.Classes.Add(Class);

            var details = new ClassDetailCell(Class, context);
            details.Click += selectClass;
            details.ClassLabelChanged += updateClassLists;
            pnlClasses.Controls.Add(details);
            details.Width = pnlClasses.Width;
            Logger.Debug("Added class");
        }

        private async void btnRemoveClass_Click(object sender, EventArgs e)
        {
            if (selectedClass == null)
            {
                return;
            }

            Logger.Debug($"Removing class {selectedClass.Id}, requesting confirmation.");
            if (MessageBox.Show($"Do you want to delete {selectedClass.Title}?","Delete Class", MessageBoxButtons.YesNo) != DialogResult.Yes) {
                Logger.Debug($"Not confirmed, leaving.");
                return;
            }

            Logger.Debug($"Confirmed.");
            foreach (ClassDetailCell ctrl in pnlClasses.Controls)
            {
                if (ctrl.Class == selectedClass)
                {
                    pnlClasses.Controls.Remove(ctrl);
                    Logger.Debug($"Removed ClassDetailCell.");
                    break;
                }
            }

            context.Classes.Remove(selectedClass);
            selectedClass = null;
            await context.SaveChangesAsync();
            Logger.Debug($"Saved Changes.");

            updateClassLists();
            Logger.Debug($"Classlists updated.");
        }

        public void UpdateProgressbar(int value, int max) {
            Logger.Debug($"Updating Progressbar {value} / {max}");
            if (value != -1)
            {
                toolStripProgressBar.Maximum = max;
                toolStripProgressBar.Value = value;
                toolStripStatusLabel.Text = $"{value} / {max}";
                toolStripStatusLabel.Visible = true;
                toolStripProgressBar.Visible = true;
            }
            else 
            {
                toolStripStatusLabel.Visible = false;
                toolStripProgressBar.Visible = false;
            }
        }

        private void updateClassLists() {
            foreach (CollectionDetailCell ctrl in pnlCollectionDetails.Controls)
            {
                ctrl.RefreshClasses();
            }
        }

        private void updateCollections() {
            foreach (NetDetailCell ctrl in pnlNetworks.Controls)
            {
                ctrl.RefreshCollections();
            }
        }

        private async void btnRemoveCollection_Click(object sender, EventArgs e)
        {
            if (selectedCollection == null)
            {
                return;
            }
            Logger.Debug($"Removing collection {selectedCollection.Id}, requesting confirmation.");
            if (MessageBox.Show($"Do you want to delete {selectedCollection.Title}?", "Delete Collection", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                Logger.Debug($"Not confirmed, leaving.");
                return;
            }

            Logger.Debug($"Confirmed.");
            foreach (CollectionDetailCell ctrl in pnlCollectionDetails.Controls)
            {
                if (ctrl.Collection.Id == selectedCollection.Id)
                {
                    pnlCollectionDetails.Controls.Remove(ctrl);
                    Logger.Debug($"Removed CollectionDetailCell.");
                    break;
                }
            }

            context.Collections.Remove(context.Collections.Find(selectedCollection.Id));
            selectedCollection = null;
            await context.SaveChangesAsync();
            Logger.Debug($"Saved Changes.");

            updateCollections();
            Logger.Debug($"Collections updated.");

        }

        private void btnAddNetwork_Click(object sender, EventArgs e)
        {
            Logger.Debug($"Adding Net");
            var net = new YoloNet();
            context.Nets.Add(net);

            var details = new NetDetailCell(net, context);
            details.Click += selectNet;
            pnlNetworks.Controls.Add(details);
            details.Width = pnlNetworks.Width ;
        }

        private async void btnRemoveNetwork_Click(object sender, EventArgs e)
        {
            if (selectedNetwork == null)
            {
                return;
            }
            Logger.Debug($"Removing net {selectedNetwork.Id}, requesting confirmation.");

            if (MessageBox.Show($"Do you want to delete {selectedNetwork.Title}?", "Delete Network", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            foreach (NetDetailCell ctrl in pnlNetworks.Controls)
            {
                if (ctrl.Net == selectedNetwork)
                {
                    pnlNetworks.Controls.Remove(ctrl);
                    Logger.Debug($"Removed NetDetailCell.");
                    break;
                }
            }

            context.Nets.Remove(selectedNetwork);
            selectedNetwork = null;
            await context.SaveChangesAsync();
            Logger.Debug($"Saved Changes.");
        }
    }
}
