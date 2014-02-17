using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeepglintChart
{
    /// <summary>
    /// Sector.xaml 的交互逻辑
    /// </summary>
    public partial class Sector : UserControl
    {

        #region Attribute

        public Point Center { set; get; }

        public int Radius { set; get; }

        public double StartAngle { set; get; }

        public double Angle { set; get; }

        //private DrawingVisual drawingVisual = new DrawingVisual();

        #endregion

        #region Action

        public Sector()
        {
            InitializeComponent();
        }

        public Sector(Point center, int radius, double startAngle, double angle)
        {
            InitializeComponent();

            this.Center = center;
            this.Radius = radius;
            this.StartAngle = startAngle;
            this.Angle = angle;

            InitSector();
        }

        private void InitSector()
        {
            Point point1 = new Point(this.Center.X + this.Radius * Math.Cos(this.StartAngle), this.Center.Y + this.Radius * Math.Sin(this.StartAngle));
            Point point2 = new Point(this.Center.X + this.Radius * Math.Cos(this.StartAngle + this.Angle), this.Center.Y + this.Radius * Math.Sin(this.StartAngle + this.Angle));
            Point point3 = new Point(this.Center.X + this.Radius / 2 * Math.Cos(this.StartAngle + this.Angle), this.Center.Y + this.Radius / 2 * Math.Sin(this.StartAngle + this.Angle));
            Point point4 = new Point(this.Center.X + this.Radius / 2 * Math.Cos(this.StartAngle), this.Center.Y + this.Radius / 2 * Math.Sin(this.StartAngle));

            Path path = new Path();
            path.StrokeThickness = 2;
            path.Stroke = Brushes.Red;
            path.Fill = Brushes.LemonChiffon;

            PathGeometry pathGeometry = new PathGeometry();

            PathFigureCollection pathFigureCollection = new PathFigureCollection();

            PathFigure pathFigure = new PathFigure { IsClosed = true };
            pathFigure.StartPoint = point1;

            PathSegmentCollection pathSegmentCollection = new PathSegmentCollection();
            ArcSegment arcOuter = new ArcSegment { Point = point2, IsLargeArc = this.Angle > Math.PI ? true : false, Size = new Size(this.Radius, this.Radius), SweepDirection = SweepDirection.Clockwise };
            pathSegmentCollection.Add(arcOuter);
            LineSegment line = new LineSegment { Point = point3 };
            pathSegmentCollection.Add(line);
            ArcSegment arcInner = new ArcSegment { Point = point4, IsLargeArc = this.Angle > Math.PI ? true : false, Size = new Size(this.Radius / 2, this.Radius / 2), SweepDirection = SweepDirection.Counterclockwise };
            pathSegmentCollection.Add(arcInner);

            pathFigure.Segments = pathSegmentCollection;

            pathFigureCollection.Add(pathFigure);

            pathGeometry.Figures = pathFigureCollection;

            path.Data = pathGeometry;

            //DrawingContext drawingContext = drawingVisual.RenderOpen();
            //Pen pen = new Pen(Brushes.Black, 2);

            //drawingContext.DrawGeometry(Brushes.Red, pen, pathGeometry);
            //this.AddVisualChild(drawingVisual);

            this.canvas.Children.Add(path);
        }

        //protected override int VisualChildrenCount
        //{
        //    get
        //    {
        //        return 1;
        //    }
        //}

        //protected override Visual GetVisualChild(int index)
        //{
        //    return drawingVisual;
        //}

        #endregion

        #region Event



        #endregion
    }
}
