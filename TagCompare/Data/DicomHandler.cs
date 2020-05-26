using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows;
using TagCompare.Dict;
using TagCompare.Util;

namespace TagCompare.Data
{
    public class DicomHandler
    {
        private readonly ByteBuffer _buffer;
        private readonly DataTable _dt;
        private uint _tag;
        private int _vr;
        private string _strTag;
        private string _strVr;
        private int _length;
        private string _strValue;
        private bool _isExplicitVr = true;
        private bool _isLittleEndian = true;

        public bool IsByteBufferNull => _buffer == null;

        /// <summary>
        /// 初始化DataTable
        /// </summary>
        /// <param name="filePath"></param>
        public DicomHandler(string filePath)
        {
            try
            {
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var array = new byte[fileStream.Length];
                fileStream.Read(array, 0, array.Length);
                fileStream.Close();
                fileStream.Dispose();
                _buffer = new ByteBuffer(array, ByteOrder.LittleEndian);
                _dt = new DataTable("Show Tags");
                _dt.Columns.Add("Group_Element", typeof(string));
                _dt.Columns.Add("TagDes", typeof(string));
                _dt.Columns.Add("VR", typeof(string));
                _dt.Columns.Add("Length", typeof(string));
                _dt.Columns.Add("Value", typeof(string));
            }
            catch (IOException ex)
            {
                MessageBox.Show("请输入正确的文件路径！", "警告", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Console.WriteLine(ex.StackTrace);
                _buffer?.Close();
            }
        }
        
        /// <summary>
        /// 核心方法，读取Tag值
        /// </summary>
        /// <returns></returns>
        private DataTable ReadTags()
        {
            try
            {
                if (IsDicom() == false)
                {
                    return null;
                }

                while (IsGroup0002())
                {
                    var dataRow = _dt.NewRow();
                    _strVr = GetVR();
                    _length = GetLength0002();
                    _strValue = GetValue();
                    dataRow["Group_Element"] = _strTag;
                    dataRow["TagDes"] = GetTagDes();
                    dataRow["VR"] = _strVr;
                    dataRow["Length"] = _length;
                    dataRow["Value"] = _strValue;
                }

                while (_strTag != "(7FE0,0010)")
                {
                    var dataRow = _dt.NewRow();
                    if (_dt.Rows.Count > 400)
                    {
                        MessageBox.Show("Tag 读取超过了 400 行，读取有误！", "警告", MessageBoxButton.OK,
                            MessageBoxImage.Exclamation);
                        return null;
                    }

                    if (_isExplicitVr && _isLittleEndian)
                    {
                        _strTag = GetGE();
                        if (_strTag.Substring(1, 4).Equals("FFFE"))
                        {
                            HandleGroupFFFE(dataRow);
                            continue;
                        }

                        _strVr = GetVR();
                        _length = GetLength();
                        _strValue = GetValue();
                    }
                    else if (_isExplicitVr == false && _isLittleEndian)
                    {
                        _strTag = GetGE();
                        if (_strTag == "(7FE0,0010)")
                        {
                            _strVr = DicomVr.ToString(DicomVr.GetVR(_tag));
                            _vr = DicomVr.GetVR(_tag);
                            _length = _buffer.ReadInt32();
                            _strValue = GetValue();
                        }
                        else
                        {
                            if (_strTag.Substring(1, 4).Equals("FFFE"))
                            {
                                HandleGroupFFFE(dataRow);
                                continue;
                            }

                            _strVr = DicomVr.ToString(DicomVr.GetVR(_tag));
                            _vr = DicomVr.GetVR(_tag);
                            _length = GetLength();
                            _strValue = GetValue();
                        }
                    }
                    else if (_isExplicitVr && _isLittleEndian == false)
                    {
                        _buffer.SetOrder(ByteOrder.BigEndian);
                        _strTag = GetGE();
                        if (_strTag.Substring(1, 4).Equals("FFFE"))
                        {
                            HandleGroupFFFE(dataRow);
                            continue;
                        }

                        _strVr = GetVR();
                        _buffer.SetOrder(ByteOrder.LittleEndian);
                        _length = GetLength();
                        _strValue = GetValue();
                    }

                    dataRow["Group_Element"] = _strTag;
                    dataRow["TagDes"] = GetTagDes();
                    dataRow["VR"] = _strVr;
                    dataRow["Length"] = _length;
                    if (_strTag == "(7FE0,0010)" && _strVr == "OB" && _length == -1)
                    {
                        _strValue = "This Pixel Data Contains Frame(s)";
                    }

                    dataRow["Value"] = _strValue;
                    _dt.Rows.Add(dataRow);

                    if (_isExplicitVr && _strVr == "SQ" && _length == -1)
                    {
                        var dataRow2 = _dt.NewRow();
                        dataRow2["Group_Element"] = "(FFFE,E0DD)";
                        dataRow2["TagDes"] = "Sequence Delimitation Item";
                        dataRow2["VR"] = string.Empty;
                        dataRow2["Length"] = string.Empty;
                        dataRow2["Value"] = string.Empty;
                        _dt.Rows.Add(dataRow2);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(_strTag + " is wrong!");
            }
            finally
            {
                _buffer?.Close();
            }

            return _dt;
        }

        /// <summary>
        /// (FFFE,E000)文件夹开始标签，(FFFE,E00D)和(FFFE,E0DD)是文件夹结束标签，内部是嵌套的tag，需要单独拿出来
        /// </summary>
        /// <returns></returns>
        private Hashtable GetRemoveIndex()
        {
            var dataTable = ReadTags();
            var hashTable = new Hashtable(20);
            int num1 = 0, startFlag = 0, endFlag = 0;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int num4 = num1;
                if (dataTable.Rows[i]["VR"].ToString().Equals("SQ")
                    || dataTable.Rows[i]["Group_Element"].ToString().Equals("(FFFE,E000)"))
                {
                    num1++;
                }
                else if (dataTable.Rows[i]["Group_Element"].ToString().Equals("(FFFE,E00D)")
                         || dataTable.Rows[i]["Group_Element"].ToString().Equals("(FFFE,E0DD)"))
                {
                    num1--;
                }

                if (num4 == 0 && num1 == 1)
                {
                    startFlag = i;
                }
                else if (num4 == 1 && num1 == 0)
                {
                    endFlag = i;
                }

                if (startFlag != 0 && endFlag != 0)
                {
                    hashTable.Add(startFlag, endFlag);
                    startFlag = 0;
                    endFlag = 0;
                }
            }

            return hashTable;
        }

        public DataTable GetTagDataTable()
        {
            if (_isExplicitVr)
            {
                var htRemoveIndex = GetRemoveIndex();
                var arrarList = new ArrayList(htRemoveIndex.Keys);
                arrarList.Sort();
                arrarList.Reverse();

                foreach (var item in arrarList)
                {
                    var num = int.Parse(item.ToString());
                    var num2 = int.Parse(htRemoveIndex[item].ToString());
                    for (int j = num2; j > num; j--)
                    {
                        _dt.Rows.RemoveAt(j);
                    }
                }
            }

            return _dt;
        }

        /// <summary>
        /// 判断是否为Dicom文件
        /// </summary>
        /// <returns></returns>
        private bool IsDicom()
        {
            try
            {
                _buffer.Seek(128L, SeekOrigin.Begin);
                if (_buffer.ReadBytesToString(4) != "DICM")
                {
                    Console.WriteLine(@"没有DICM前缀，文件格式错误！");
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                _buffer.Close();
                return false;
            }
        }

        private bool IsGroup0002()
        {
            try
            {
                _strTag = GetGE();
                if (_strTag.Substring(1,4).Equals("0002"))
                {
                    return true;
                }

                _buffer.Skip(-4);
                return false;
            }
            catch (Exception)
            {
                _buffer.Close();
            }

            return false;
        }

        private void HandleGroupFFFE( DataRow dr)
        {
            try
            {
                _buffer.ReadInt32();
                dr["Group_Element"] = _strTag;
                dr["TagDes"] = GetTagDes();
                dr["VR"] = string.Empty;
                dr["Length"] = string.Empty;
                dr["Value"] = string.Empty;
                _dt.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                _buffer.Close();
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void SetTransferSyntax(string transferSyntaxUid)
        {
            if (string.IsNullOrEmpty(transferSyntaxUid))
            {
                return;
            }

            if (transferSyntaxUid == "1.2.840.10008.1.2.1\0" == false)
            {
                if (transferSyntaxUid == "1.2.840.10008.1.2\0" == false)
                {
                    if (transferSyntaxUid == "1.2.840.10008.1.2.2\0")
                    {
                        _isExplicitVr = true;
                        _isLittleEndian = false;
                    }
                }
                else
                {
                    _isExplicitVr = false;
                    _isLittleEndian = true;
                }
            }
            else
            {
                _isExplicitVr = true;
                _isLittleEndian = true;
            }
        }

        private string GetGE()
        {
            try
            {
                _tag = DicomTag.ValueOf(_buffer.ReadUInt16(), _buffer.ReadUInt16());
                _strTag = DicomTag.ToHexString(_tag);
                return _strTag;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _buffer.Close();
                return _strTag + " GetGE ERROR";
            }
        }

        private string GetTagDes()
        {
            try
            {
                if (DicomTag.IsPrivate(_tag))
                {
                    return "Private Tag";
                }

                return DicomTag.GetName(_tag);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "GetTagDes ERROR";
            }
        }

        private string GetVR()
        {
            try
            {
                _buffer.SetOrder(ByteOrder.BigEndian);
                _vr = _buffer.ReadUInt16();
                _strVr = DicomVr.ToString(_vr);
                _buffer.SetOrder(ByteOrder.LittleEndian);
                return _strVr;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _buffer.Close();
                return _strVr + " GetVR ERROR";
            }
        }

        private int GetLength()
        {
            try
            {
                if (_isExplicitVr)
                {
                    if (DicomVr.IsLengthField16Bit(_vr))
                    {
                        return _buffer.ReadUInt16();
                    }

                    _buffer.ReadUInt16();
                    return _buffer.ReadInt32();
                }

                return _buffer.ReadInt32();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _buffer.Close();
                return -1;
            }
        }

        private int GetLength0002()
        {
            try
            {
                if (DicomVr.IsLengthField16Bit(_vr))
                {
                    return _buffer.ReadUInt16();
                }

                _buffer.ReadUInt16();
                return _buffer.ReadInt32();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _buffer.Close();
                return -1;
            }
        }

        private string GetValue()
        {
            try
            {
                _strValue = StringUtils.GetValue(_buffer, _vr, _length);
                SetTransferSyntax(_strValue.Trim());
                var text = _strValue;
                var trimChars = new char[1];
                return text.Trim(trimChars);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _buffer.Close();
                return _strValue + " GetValue ERROR";
            }
        }

    }
}
