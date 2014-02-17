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
using Microsoft.Windows.Controls;

namespace DeepglintChart
{
    /// <summary>
    /// Pie.xaml 的交互逻辑
    /// </summary>
    public partial class Pie : UserControl
    {

        #region Attribute
        public List<KeyValuePair<string, int>> KeyValueList { set; get; }
        #endregion

        #region Action

        public Pie()
        {
            this.KeyValueList = new List<KeyValuePair<string, int>>();

            InitializeComponent();

            InitPie();
        }

        private void InitPie()
        {
            this.KeyValueList.Add(new KeyValuePair<string, int>("a", 1));
            this.KeyValueList.Add(new KeyValuePair<string, int>("b", 2));
            this.KeyValueList.Add(new KeyValuePair<string, int>("c", 3));
            this.KeyValueList.Add(new KeyValuePair<string, int>("d", 4));
            lineSeries.DataContext = this.KeyValueList;
        }

        #endregion

        #region Event

        #endregion
    }
}
