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
    /// UserSpline.xaml 的交互逻辑
    /// </summary>
    public partial class UserSpline : UserControl
    {
        #region Attribute

        public double SplineWidth { set; get; }

        public double SplineHeight { set; get; }

        public List<KeyValuePair<string, int>> ValueList { set; get; }

        #endregion

        #region Action

        public UserSpline()
        {
            InitializeComponent();
        }

        public UserSpline(List<KeyValuePair<string, int>> valueList, double width, double height)
        {
            InitializeComponent();

            this.SplineWidth = width;
            this.SplineHeight = height;
            this.ValueList = valueList;

            InitSpline();
        }

        private void InitSpline()
        {
            this.userControl.Width = this.SplineWidth;
            this.userControl.Height = this.SplineHeight;

            this.userControl.Background = Brushes.Beige;

            InitCoordinate();
        }

        private void InitCoordinate()
        {
            Point startPointX, endPointX, startPointY, endPointY;

            double minValue = Int16.MaxValue, maxValue = 0;
            GetMinMaxValue(this.ValueList, ref minValue, ref maxValue);
            for (int i = 0; i <= 10; i++)
            {
                startPointX = new Point(0, this.SplineHeight * i / 11);
                endPointX = new Point(this.SplineWidth * 9 / 10, this.SplineHeight * i / 11);
                DrawLine(startPointX, endPointX);

                Tape tape = new Tape();
                tape.textBlock.Text = ((maxValue - minValue) * i / 10 + minValue).ToString();
                Canvas.SetLeft(tape, -this.SplineWidth / 10);
                Canvas.SetTop(tape, this.SplineHeight * (10 - i) / 11);
                this.canvas.Children.Add(tape);

            }

            Path path = new Path();

            PathGeometry pathGeometry = new PathGeometry();

            PathFigureCollection pathFigureCollection = new PathFigureCollection();

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(0,  this.SplineHeight * 10 / 11);

            PathSegmentCollection pathSegmentCollection = new PathSegmentCollection();


            for (int i = 0; i < this.ValueList.Count; i++ )
            {
                startPointY = new Point(this.SplineWidth * i / 10, this.SplineHeight * 10 / 11);
                endPointY = new Point(this.SplineWidth * i / 10, 0);
                DrawLine(startPointY, endPointY);

                Tape tape = new Tape();
                tape.textBlock.Text = this.ValueList[i].Key.ToString();
                Canvas.SetLeft(tape, this.SplineWidth * i / 10);
                Canvas.SetTop(tape, this.SplineHeight * 10 / 11);
                this.canvas.Children.Add(tape);

                LineSegment lineSegment = new LineSegment
                {
                    Point = new Point(this.SplineWidth * i / 10,
                        this.SplineHeight * 10 / 11 - (this.ValueList[i].Value - minValue) * this.SplineHeight * 10 / ((maxValue - minValue) * 11))
                };
                pathSegmentCollection.Add(lineSegment);
              
            }

            pathFigure.Segments = pathSegmentCollection;
            pathFigureCollection.Add(pathFigure);
            pathGeometry.Figures = pathFigureCollection;
            path.Data = pathGeometry;
            path.StrokeThickness = 2;
            path.Stroke = Brushes.Black;

            this.canvas.Children.Add(path);
        }

        private void GetMinMaxValue(List<KeyValuePair<string, int>> list, ref double minValue, ref double maxValue)
        {
            foreach (KeyValuePair<string, int> value in list)
            {
                if (value.Value < minValue)
                    minValue = value.Value;
                if (value.Value > maxValue)
                    maxValue = value.Value;
            }
        }

        private void DrawLine(Point startPoint, Point endPoint)
        {
            LineGeometry lineGeometry = new LineGeometry();
            lineGeometry.StartPoint = startPoint;
            lineGeometry.EndPoint = endPoint;

            Path path = new Path();
            path.Stroke = Brushes.Red;
            path.StrokeThickness = 3;
            path.Data = lineGeometry;

            this.canvas.Children.Add(path);
        }

        #endregion
    }
}
