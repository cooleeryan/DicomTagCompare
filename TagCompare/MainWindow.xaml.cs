using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using TagCompare.Data;

namespace TagCompare
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private DicomHandler _dh;
        private DataTable _dtLeft;
        private DataTable _dtRight;
        private string _fileName;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 左侧打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenLeft_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Title = "选择Dicom文件 - 左侧",
                Filter = "Dicom文件|*.dcm|ima文件|*.ima|所有文件|*.*",
                FilterIndex = 0,
                FileName = string.Empty
            };
            dlg.ShowDialog();
            _fileName = dlg.FileName;
            ShowResult(true);
        }

        /// <summary>
        /// 右侧打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenRight_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Title = "选择Dicom文件 - 右侧",
                Filter = "Dicom文件|*.dcm|ima文件|*.ima|所有文件|*.*",
                FilterIndex = 0,
                FileName = string.Empty
            };
            dlg.ShowDialog();
            _fileName = dlg.FileName;
            ShowResult(false);
        }

        /// <summary>
        /// 左侧路径回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtLeft_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return)
            {
                return;
            }

            _fileName = TxtLeft.Text.Trim();
            ShowResult(true);
        }

        /// <summary>
        /// 右侧路径回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtRight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return)
            {
                return;
            }

            _fileName = TxtRight.Text.Trim();
            ShowResult(false);
        }

        /// <summary>
        /// 比较两个文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCompare_Click(object sender, RoutedEventArgs e)
        {
            if (_dtLeft == null || _dtRight == null)
            {
                MessageBox.Show("请先载入两个Dicom文件！", "警告", MessageBoxButton.OK);
            }
            else
            {
                var compareResult = new CompareResult {DgResult = {ItemsSource = CompareResult().DefaultView}};
                compareResult.ShowDialog();
            }
        }

        /// <summary>
        /// 左侧拖拽文件到Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgLeft_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is Array data)
            {
                _fileName = data.GetValue(0).ToString();
                if (string.IsNullOrEmpty(_fileName) == false)
                {
                    ShowResult(true);
                }
            }
        }

        /// <summary>
        /// 右侧拖拽文件到Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgRight_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is Array data)
            {
                _fileName = data.GetValue(0).ToString();
                if (string.IsNullOrEmpty(_fileName) == false)
                {
                    ShowResult(false);
                }
            }
        }

        /// <summary>
        /// 左侧行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgLeft_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        /// <summary>
        /// 右侧行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgRight_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        /// <summary>
        /// 显示Tag信息
        /// </summary>
        /// <param name="isLeft"></param>
        private void ShowResult(bool isLeft)
        {
            try
            {
                if (string.IsNullOrEmpty(_fileName.Trim()))
                {
                    return;
                }

                if (Directory.Exists(_fileName))
                {
                    MessageBox.Show("请不要拖拽文件夹！", "警告", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }

                _dh = new DicomHandler(_fileName);
                if (_dh.IsByteBufferNull)
                {
                    return;
                }

                if (isLeft)
                {
                    _dtLeft = _dh.GenerateTagDataTable();
                    TxtLeft.Text = _fileName;
                    DgLeft.ItemsSource = _dtLeft.DefaultView;
                }
                else
                {
                    _dtRight = _dh.GenerateTagDataTable();
                    TxtRight.Text = _fileName;
                    DgRight.ItemsSource = _dtRight.DefaultView;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("该文件不是Dicom文件，请重新选择！", "警告", MessageBoxButton.OK);
            }
            catch (IOException)
            {
                MessageBox.Show("判断文件夹失败！", "警告", MessageBoxButton.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("导入失败！", "警告", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// 比较Tag差异
        /// </summary>
        /// <returns></returns>
        private DataTable CompareResult()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Group_Element", typeof(string));
            dataTable.Columns.Add("TagDes", typeof(string));
            dataTable.Columns.Add("VR_Left", typeof(string));
            dataTable.Columns.Add("VR_Right", typeof(string));
            dataTable.Columns.Add("Length_Left", typeof(string));
            dataTable.Columns.Add("Length_Right", typeof(string));
            dataTable.Columns.Add("Value_Left", typeof(string));
            dataTable.Columns.Add("Value_Right", typeof(string));

            try
            {
                for (int i = 0; i < _dtLeft.Rows.Count; i++)
                {
                    for (int j = 0; j < _dtRight.Rows.Count; j++)
                    {
                        var geLeft = _dtLeft.Rows[i]["Group_Element"].ToString();
                        var tagDes = _dtLeft.Rows[i]["TagDes"].ToString();
                        var vrLeft = _dtLeft.Rows[i]["VR"].ToString();
                        var lengthLeft = _dtLeft.Rows[i]["Length"].ToString();
                        var valueLeft = _dtLeft.Rows[i]["Value"].ToString();
                        var geRight = _dtRight.Rows[j]["Group_Element"].ToString();
                        var vrRight = _dtRight.Rows[j]["VR"].ToString();
                        var lengthRight = _dtRight.Rows[j]["Length"].ToString();
                        var valueRight = _dtRight.Rows[j]["Value"].ToString();

                        if (geLeft == geRight && (vrLeft != vrRight || lengthLeft != lengthRight || valueLeft != valueRight))
                        {
                            var row = dataTable.NewRow();
                            row["Group_Element"] = geLeft;
                            row["TagDes"] = tagDes;
                            row["VR_Left"] = vrLeft;
                            row["VR_Right"] = vrRight;
                            row["Length_Left"] = lengthLeft;
                            row["Length_Right"] = lengthRight;
                            row["Value_Left"] = valueLeft;
                            row["Value_Right"] = valueRight;
                            dataTable.Rows.Add(row);
                        }
                    }
                }

                return dataTable;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
