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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitChart();
        }

        private void InitChart()
        {
            //Pie pie = new Pie();
            //pie.Width = this.grid.Width;
            //pie.Height = this.grid.Height;
            //this.grid.Children.Add(pie);

            //Spline line = new Spline();
            //line.Width = this.grid.Width;
            //line.Height = this.grid.Height;
            //this.grid.Children.Add(line);

            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
            valueList.Add(new KeyValuePair<string, int>("a", 1));
            valueList.Add(new KeyValuePair<string, int>("b", 2));
            valueList.Add(new KeyValuePair<string, int>("c", 3));
            valueList.Add(new KeyValuePair<string, int>("d", 2));

            //MessageBox.Show((int)this.window.Width + "==" + (int)this.window.Height);
            UserPie userPie = new UserPie(valueList, (double)this.window.Width, (double)this.window.Height);
            //this.grid.Children.Add(userPie);

            
            Point center = new Point(100, 100);
            Sector sector = new Sector(center, 80, Math.PI / 4, Math.PI / 4);
            //this.grid.Children.Add(sector);

            double width = this.window.Width;
            double height = this.window.Height;
            UserSpline userSpline = new UserSpline(valueList, width, height);
            this.grid.Children.Add(userSpline);
        }
    }
}
