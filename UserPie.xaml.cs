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
    /// UserPie.xaml 的交互逻辑
    /// </summary>
    public partial class UserPie : UserControl
    {

        #region Attribute

        //public double PieWidth
        //{
        //    set { SetValue(WidthProperty, value); }
        //    get { return (double)GetValue(WidthProperty); }
        //}

        //public static DependencyProperty PieWidthProperty = DependencyProperty.Register("PieWidth", typeof(double), typeof(UserPie));

        //public double PieHeight { set; get; }

        public List<KeyValuePair<string, int>> ValueList { set; get; }

        #endregion

        #region Action

        public UserPie(List<KeyValuePair<string, int>> valueList, double width, double height)
        {
            InitializeComponent();

            this.ValueList = valueList;

            InitPieChart();
        }

        private void InitPieChart()
        {

        }

        #endregion

        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //MessageBox.Show(this.canvas.RenderSize.ToString());
        }

        #region Event

        #endregion
    }
}
