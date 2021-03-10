using OpenLibraryLabelImg.Data;
using OpenLibraryLabelImg.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using OpenLibraryLabelImg.UserControls;

namespace OpenLibraryLabelImg
{
    public partial class MainWindow : Form
    {
        private readonly AnnotationContext context = new AnnotationContext();
        private AnnotationClass selectedClass;
        private AnnotationCollection selectedCollection;
        private YoloNet selectedNetwork;
        private AnnotationWindow window;

        public MainWindow()
        {
            InitializeComponent();
            Text = "OpenLibraryLabelImg - 0.1";
            Helpers.window = this;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            context.Database.EnsureCreated();
            //if (context.Database.GetPendingMigrations().Count() > 0) {
            //    context.Database.Migrate();
            //}

            foreach (var collection in await context.Collections.Include(c => c.Images).Include(c => c.Classes).ToListAsync())
            {
                var details = new CollectionDetailCell(collection);
                details.Click += selectCollection;
                details.CollectionChanged += updateCollections;
                details.DoubleClick += openCollection;
                pnlCollectionDetails.Controls.Add(details);
            }

            foreach (var cls in await context.Classes.ToListAsync())
            {
                var details = new ClassDetailCell(cls, context);
                details.Click += selectClass;
                details.ClassLabelChanged += updateClassLists;
                pnlClasses.Controls.Add(details);
                details.Width = pnlClasses.Width - 35;
            }

            foreach (var net in await context.Nets.Include(n => n.Collections).ToListAsync())
            {
                var details = new NetDetailCell(net, context);
                details.Click += selectNet;
                pnlNetworks.Controls.Add(details);
                details.Width = pnlNetworks.Width - 35;
            }
        }

        private void selectCollection(object sender, EventArgs e) {
            foreach (CollectionDetailCell ctrl in pnlCollectionDetails.Controls)
            {
                if (ctrl == sender)
                {
                    ctrl.BackColor = Color.DarkGray;
                    selectedCollection = ctrl.Collection;
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
            }

            var details = sender as CollectionDetailCell;
            if (window != null) {
                window.Dispose();
            }

            window = new AnnotationWindow(details.Collection);
            window.Show();
            window.FormClosed += annotationWindowClosed;
        }

        private void annotationWindowClosed(object sender, EventArgs e) {
            updateCollections();
            window.Dispose();
        }

        private void btnAddCollection_Click(object sender, EventArgs e)
        {
            var details = new CollectionDetailCell();
            details.CollectionChanged += updateCollections;
            details.Click += selectCollection;
            details.DoubleClick += openCollection;
            pnlCollectionDetails.Controls.Add(details);
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            var Class = new AnnotationClass();
            context.Classes.Add(Class);

            var details = new ClassDetailCell(Class, context);
            details.Click += selectClass;
            details.ClassLabelChanged += updateClassLists;
            pnlClasses.Controls.Add(details);
            details.Width = pnlClasses.Width;
        }

        private async void btnRemoveClass_Click(object sender, EventArgs e)
        {
            if (selectedClass == null)
            {
                return;
            }

            if (MessageBox.Show($"Do you want to delete {selectedClass.ClassLabel}?","Delete Class", MessageBoxButtons.YesNo) != DialogResult.Yes) {
                return;
            }

            foreach (ClassDetailCell ctrl in pnlClasses.Controls)
            {
                if (ctrl.Class == selectedClass)
                {
                    pnlClasses.Controls.Remove(ctrl);
                    break;
                }
            }

            context.Classes.Remove(selectedClass);
            selectedClass = null;
            await context.SaveChangesAsync();

            updateClassLists();
        }

        public void UpdateProgressbar(int value, int max) {
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
            if (MessageBox.Show($"Do you want to delete {selectedCollection.Title}?", "Delete Collection", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            foreach (CollectionDetailCell ctrl in pnlCollectionDetails.Controls)
            {
                if (ctrl.Collection.Id == selectedCollection.Id)
                {
                    pnlCollectionDetails.Controls.Remove(ctrl);
                    break;
                }
            }

            context.Collections.Remove(context.Collections.Find(selectedCollection.Id));
            selectedCollection = null;
            await context.SaveChangesAsync();
            updateCollections();
        }

        private void btnAddNetwork_Click(object sender, EventArgs e)
        {
            var net = new YoloNet();
            context.Nets.Add(net);

            var details = new NetDetailCell(net, context);
            details.Click += selectNet;
            pnlNetworks.Controls.Add(details);
            details.Width = pnlNetworks.Width;
        }

        private async void btnRemoveNetwork_Click(object sender, EventArgs e)
        {
            if (selectedNetwork == null)
            {
                return;
            }
            if (MessageBox.Show($"Do you want to delete {selectedNetwork.Title}?", "Delete Network", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            foreach (NetDetailCell ctrl in pnlNetworks.Controls)
            {
                if (ctrl.Net == selectedNetwork)
                {
                    pnlNetworks.Controls.Remove(ctrl);
                    break;
                }
            }

            context.Nets.Remove(selectedNetwork);
            selectedNetwork = null;
            await context.SaveChangesAsync();
        }
    }
}
