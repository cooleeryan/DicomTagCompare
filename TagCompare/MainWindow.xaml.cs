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
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
        }

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

        private void TxtLeft_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return)
            {
                return;
            }

            _fileName = TxtLeft.Text.Trim();
            ShowResult(true);
        }

        private void TxtRight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return)
            {
                return;
            }

            _fileName = TxtRight.Text.Trim();
            ShowResult(true);
        }

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

        private void DgLeft_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void DgRight_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

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
                    _dtLeft = _dh.GetTagDataTable();
                    TxtLeft.Text = _fileName;
                    DgLeft.ItemsSource = _dtLeft.DefaultView;
                }
                else
                {
                    _dtRight = _dh.GetTagDataTable();
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
                        var ge_left = _dtLeft.Rows[i]["Group_Element"].ToString();
                        var tagDes = _dtLeft.Rows[i]["TagDes"].ToString();
                        var vr_left = _dtLeft.Rows[i]["VR"].ToString();
                        var length_left = _dtLeft.Rows[i]["Length"].ToString();
                        var value_left = _dtLeft.Rows[i]["Value"].ToString();
                        var ge_right = _dtRight.Rows[j]["Group_Element"].ToString();
                        var vr_right = _dtRight.Rows[j]["VR"].ToString();
                        var length_right = _dtRight.Rows[j]["Length"].ToString();
                        var value_right = _dtRight.Rows[j]["Value"].ToString();

                        if (ge_left == ge_right && (vr_left != vr_right || length_left != length_right || value_left != value_right))
                        {
                            var row = dataTable.NewRow();
                            row["Group_Element"] = ge_left;
                            row["TagDes"] = tagDes;
                            row["VR_Left"] = vr_left;
                            row["VR_Right"] = vr_right;
                            row["Length_Left"] = length_left;
                            row["Length_Right"] = length_right;
                            row["Value_Left"] = value_left;
                            row["Value_Right"] = value_right;
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
