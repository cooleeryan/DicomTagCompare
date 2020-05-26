using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TagCompare
{
    /// <summary>
    /// CompareResult.xaml 的交互逻辑
    /// </summary>
    public partial class CompareResult : Window
    {
        public CompareResult()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 对比窗口行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgResult_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
