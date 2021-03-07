using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using OpenLibraryLabelImg.Model;

namespace OpenLibraryLabelImg
{
    public partial class AnnotationPanel : Panel
    {
        public enum State { Resting, Moving, ResizingNW, ResizingNE, ResizingSE, ResizingSW, ResizingN, ResizingE, ResizingS, ResizingW }
        public delegate void AnnotationClassChanged(AnnotationBox box, string className);
        public delegate void AnnotationChanged(AnnotationBox box, AnnotationPanel panel);
        public AnnotationBox AnnotationBox { get; set; }
        public Point GrappingPointToScreen { get; set; }
        public State CurrentState { get; set; }
        public Point grappingPosition { get; set; }
        public Point GrappedSize { get; set; }
        public string debugInfo { get => $"{Math.Round(AnnotationBox.Width, 2)}x{Math.Round(AnnotationBox.Height,2)}, {Math.Round(AnnotationBox.X,2)},{Math.Round(AnnotationBox.Y,2)}"; }

        private readonly int borderThickness = 8;
        private readonly int hatchingDistance = 15;
        private readonly int hatchingThickness = 2;

        public event AnnotationChanged AnnotationUpdated;

        public event AnnotationClassChanged ClassChanged;

        public AnnotationPanel(AnnotationClass c)
        {
            InitializeComponent();
            AnnotationBox = new AnnotationBox() { Class = c };
            GrappingPointToScreen = Point.Empty;

            MouseDown += mouseDownHandler;
            MouseMove += mouseMoveHandler;
            MouseUp += mouseUpHandler;
            DoubleBuffered = false;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }

        private void mouseDownHandler(object sender, MouseEventArgs e)
        {
            if (GrappingPointToScreen == Point.Empty)
            {
                GrappingPointToScreen = PointToScreen(e.Location);
                grappingPosition = Location;
                GrappedSize = new Point(Size);
            }
        }

        override protected void OnPaintBackground(PaintEventArgs e)
        {
            var brush = new SolidBrush(AnnotationBox.Class.Color);
            var pen = new Pen(brush)
            {
                DashStyle = DashStyle.Dash,
                Width = 5
            };

            e.Graphics.DrawRectangle(pen, 0, 0, Width, Height);
            
            if (AnnotationBox.AnnotaionImage.State == AnnotationState.AutoAnnotated) {
                var hatchingColor = Color.FromArgb(0x7A00_0000 | AnnotationBox.Class.Color.ToArgb());
                var hatchingPen = new Pen(hatchingColor, hatchingThickness);

                List<Point> lines = new List<Point>();

                for (int i = hatchingDistance; i < Math.Max(Width, Height) * 2; i += hatchingDistance)
                {
                    lines.Add(new Point(i, 0));
                    lines.Add(new Point(0, i));
                }
                e.Graphics.DrawLines(hatchingPen, lines.ToArray());
            }

            var label = AnnotationBox.Class.ClassLabel + ", " + debugInfo;
            var labelRectangle = e.Graphics.MeasureString(label, DefaultFont);
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 5, 5, labelRectangle.Width, labelRectangle.Height);
            e.Graphics.DrawString(label, DefaultFont, new SolidBrush(Color.Black), new PointF(5, 5));
        }

        protected override void OnPaint(PaintEventArgs e) {
  
        }

        internal void mouseUpHandler(object sender, MouseEventArgs e)
        {
            GrappingPointToScreen = Point.Empty;
            CurrentState = State.Resting;

            AnnotationUpdated(AnnotationBox, this);
        }

        internal void mouseMoveHandler(object sender, MouseEventArgs e)
        {
            mouseMoveHandler(sender, e, false);
        }

        internal void mouseMoveHandler(object sender, MouseEventArgs e, bool offsetLocation = false)
        {
            var o = sender as AnnotationPanel;
            o.BringToFront();
            var newPoint = e.Location;
            var newPointScreen = o.PointToScreen(e.Location);
            if (offsetLocation)
            {
                newPointScreen.Offset(-o.Location.X, -o.Location.Y);
            }
            var delta = new Point(newPointScreen.X - GrappingPointToScreen.X, newPointScreen.Y - GrappingPointToScreen.Y);

            if (newPoint.X < borderThickness && newPoint.Y < borderThickness
            || o.Height - newPoint.Y < borderThickness && o.Width - newPoint.X < borderThickness)
            {
                o.Cursor = Cursors.SizeNWSE;
                if (e.Button == MouseButtons.Left && CurrentState == State.Resting)
                {
                    CurrentState = newPoint.Y < borderThickness ? State.ResizingNW : State.ResizingSE;
                }
            }
            else if (newPoint.X < borderThickness && o.Height - newPoint.Y < borderThickness
            || newPoint.Y < borderThickness && o.Width - newPoint.X < borderThickness)
            {
                o.Cursor = Cursors.SizeNESW;
                if (e.Button == MouseButtons.Left && CurrentState == State.Resting)
                {
                    CurrentState = newPoint.Y < borderThickness ? State.ResizingNE : State.ResizingSW;
                }
            }
            else if (newPoint.X < borderThickness || o.Width - newPoint.X < borderThickness)
            { // West
                o.Cursor = Cursors.SizeWE;
                if (e.Button == MouseButtons.Left && CurrentState == State.Resting)
                {
                    CurrentState = newPoint.X < borderThickness ? State.ResizingW : State.ResizingE;
                }
            }
            else if (newPoint.Y < borderThickness || o.Height - newPoint.Y < borderThickness)
            { // North
                o.Cursor = Cursors.SizeNS;
                if (e.Button == MouseButtons.Left && CurrentState == State.Resting)
                {
                    CurrentState = newPoint.Y < borderThickness ? State.ResizingN : State.ResizingS;
                }
            }
            else
            {
                o.Cursor = Cursors.SizeAll;

                if (e.Button == MouseButtons.Left &&
                (CurrentState == State.Resting || CurrentState == State.Moving))
                {
                    CurrentState = State.Moving;
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                switch (CurrentState)
                {
                    case State.Moving:
                        o.SetBounds(grappingPosition.X + delta.X, grappingPosition.Y + delta.Y, o.Width, o.Height);
                        break;
                    case State.ResizingNW:
                        o.SetBounds(grappingPosition.X + delta.X, grappingPosition.Y + delta.Y, GrappedSize.X - delta.X, GrappedSize.Y - delta.Y);
                        break;
                    case State.ResizingNE:
                        o.SetBounds(grappingPosition.X, grappingPosition.Y + delta.Y, GrappedSize.X + delta.X, GrappedSize.Y - delta.Y);
                        break;
                    case State.ResizingSE:
                        o.SetBounds(grappingPosition.X, grappingPosition.Y, GrappedSize.X + delta.X, GrappedSize.Y + delta.Y);
                        break;
                    case State.ResizingSW:
                        o.SetBounds(grappingPosition.X + delta.X, grappingPosition.Y, GrappedSize.X - delta.X, GrappedSize.Y + delta.Y);
                        break;
                    case State.ResizingN:
                        o.SetBounds(grappingPosition.X, grappingPosition.Y + delta.Y, GrappedSize.X, GrappedSize.Y - delta.Y);
                        break;
                    case State.ResizingE:
                        o.SetBounds(grappingPosition.X, grappingPosition.Y, GrappedSize.X + delta.X, GrappedSize.Y);
                        break;
                    case State.ResizingS:
                        o.SetBounds(grappingPosition.X, grappingPosition.Y, GrappedSize.X, GrappedSize.Y + delta.Y);
                        break;
                    case State.ResizingW:
                        o.SetBounds(grappingPosition.X + delta.X, grappingPosition.Y, GrappedSize.X - delta.X, GrappedSize.Y);
                        break;
                    default:
                        return;
                }
                Parent.Invalidate(true);
            }
        }
    }
}
