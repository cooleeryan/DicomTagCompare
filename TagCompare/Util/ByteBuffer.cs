using System;
using System.IO;
using System.Text;

namespace TagCompare.Util
{
    public class ByteBuffer : MemoryStream
    {
        private ByteOrder _order = ByteOrder.LittleEndian;
        private BinaryReader _reader;
        private BinaryWriter _writer;
        private Encoding _encoding = DcmEncoding.Default; 

        public int Remaining => (int)(Length - Position);

        public Encoding Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

        public ByteBuffer(byte[] buf, ByteOrder byteOrder)
            : base(buf)
        {
            SetOrder(byteOrder);
        }

        public ByteBuffer(byte[] buf, int offset, int size, ByteOrder byteOrder)
            : base(buf, offset, size)
        {
            SetOrder(byteOrder);
        }

        public ByteBuffer(int size, ByteOrder byteOrder)
            : base(size)
        {
            SetOrder(byteOrder);
        }
        
        /// <summary>
        /// Return length as int, o/w, we can use Length (long) directly
        /// </summary>
        /// <returns></returns>
        public int length()
        {
            return (int)Length;
        }

        public ByteOrder GetOrder()
        {
            return _order;
        }

        public ByteBuffer SetOrder(ByteOrder byteOrder)
        {
            _order = byteOrder;

            // Both reader and writer work on the same back store: MemoryStream
            if (byteOrder == ByteOrder.LittleEndian)
            {
                _reader = new BinaryReader(this);
                _writer = new BinaryWriter(this);
            }
            else
            {
                _reader = new BeBinaryReader(this);
                _writer = new BeBinaryWriter(this);
            }
            return this;
        }

        public ByteBuffer Rewind()
        {
            Position = 0;
            return this;
        }

        public ByteBuffer Clear()
        {
            Position = 0;
            SetLength(0);
            return this;
        }

        /// <summary>
        /// Skip bytes
        /// </summary>
        /// <param name="count">How many bytes to skip</param>
        /// <returns>Actual bytes skipped</returns>
        public int Skip(int count)
        {
            var old = (int)Position;
            Position += count;
            if (Position > Length)
                return (int)Length - old;
            return count;
        }

        /// <summary>
        /// Skip one byte
        /// </summary>
        /// <returns>Actual bytes skipped</returns>
        public int Skip()
        {
            return Skip(1);
        }

        public void Append(byte[] buffer, int offset, int count)
        {
            var stream = new MemoryStream(GetBuffer());
            long pos = stream.Position;
            stream.Seek(0, SeekOrigin.End);
            stream.Write(buffer, offset, count);
            stream.Position = pos;
        }

        public uint[] ToUInt32s()
        {
            byte[] bytes = ToArray();
            int count = bytes.Length / 4;
            var dwords = new uint[count];
            for (int i = 0, p = 0; i < count; i++, p += 4)
            {
                dwords[i] = BitConverter.ToUInt32(bytes, p);
            }
            return dwords;
        }

        /// <summary>
        /// ByteBuffer
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual ByteBuffer Write(ByteBuffer data)
        {
            _writer.Write(data.ToArray());
            return this;
        }
        public virtual ByteBuffer ReadBuffer(int len)
        {
            _reader.ReadBytes(len);
            return this;
        }
        public virtual ByteBuffer ReadBuffer(int offset, int len)
        {
            Position = offset;
            _reader.ReadBytes(len);
            return this;
        }

        /// <summary>
        /// Byte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual ByteBuffer Write(byte value)
        {
            _writer.Write(value);
            return this;
        }
        public new virtual byte ReadByte()
        {
            return _reader.ReadByte();
        }
        public virtual ByteBuffer Write(byte value, int off)
        {
            Position = off;
            _writer.Write(value);
            return this;
        }
        public virtual byte ReadByte(int off)
        {
            Position = off;
            return _reader.ReadByte();
        }

        public string ReadBytesToString(int count)
        {
            var bytes = _reader.ReadBytes(count);
            return Encoding.UTF8.GetString(bytes);
        }

        public byte[] ReadBytes(int count)
        {
            return _reader.ReadBytes(count);
        }

        #region byte
        
        public virtual ByteBuffer Write(byte[] value)
        {
            _writer.Write(value);
            return this;
        }

        #endregion
        
        #region short
        
        public virtual ByteBuffer Write(short value)
        {
            _writer.Write(value);
            return this;
        }
        public virtual short ReadInt16()
        {
            return _reader.ReadInt16();
        }
        public virtual ByteBuffer Write(int off, short value)
        {
            Position = off;
            _writer.Write(value);
            return this;
        }
        public virtual short ReadInt16(int off)
        {
            Position = off;
            return _reader.ReadInt16();
        }

        #endregion

        #region ushort
        
        public virtual ByteBuffer Write(ushort value)
        {
            _writer.Write(value);
            return this;
        }
        public virtual ushort ReadUInt16()
        {
            return _reader.ReadUInt16();
        }
        public virtual ByteBuffer Write(int off, ushort value)
        {
            Position = off;
            _writer.Write(value);
            return this;
        }
        public virtual ushort ReadUInt16(int off)
        {
            Position = off;
            return _reader.ReadUInt16();
        }

        #endregion

        #region int

        public virtual ByteBuffer Write(int value)
        {
            _writer.Write(value);
            return this;
        }
        public virtual int ReadInt32()
        {
            return _reader.ReadInt32();
        }
        public virtual ByteBuffer Write(int off, int value)
        {
            Position = off;
            _writer.Write(value);
            return this;
        }
        public virtual int ReadInt32(int off)
        {
            Position = off;
            return _reader.ReadInt32();
        }

        #endregion

        #region uint

        public virtual ByteBuffer Write(uint value)
        {
            _writer.Write(value);
            return this;
        }
        public virtual uint ReadUInt32()
        {
            return _reader.ReadUInt32();
        }
        public virtual ByteBuffer Write(int off, uint value)
        {
            Position = off;
            _writer.Write(value);
            return this;
        }
        public virtual uint ReadUInt32(int off)
        {
            Position = off;
            return _reader.ReadUInt32();
        }

        #endregion
        
        #region long

        public virtual ByteBuffer Write(long value)
        {
            _writer.Write(value);
            return this;
        }
        public virtual long ReadInt64()
        {
            return _reader.ReadInt64();
        }
        public virtual ByteBuffer Write(int off, long value)
        {
            Position = off;
            _writer.Write(value);
            return this;
        }
        public virtual long ReadInt64(int off)
        {
            Position = off;
            return _reader.ReadInt64();
        }

        #endregion

        #region ulong

        public virtual ByteBuffer Write(ulong value)
        {
            _writer.Write(value);
            return this;
        }
        public virtual ulong ReadUInt64()
        {
            return _reader.ReadUInt64();
        }
        public virtual ByteBuffer Write(int off, ulong value)
        {
            Position = off;
            _writer.Write(value);
            return this;
        }
        public virtual ulong ReadUInt64(int off)
        {
            Position = off;
            return _reader.ReadUInt64();
        }

        #endregion

        #region float

        public virtual ByteBuffer Write(float value)
        {
            _writer.Write(value);
            return this;
        }
        public virtual float ReadSingle()
        {
            return _reader.ReadSingle();
        }
        public virtual ByteBuffer Write(int off, float value)
        {
            Position = off;
            _writer.Write(value);
            return this;
        }
        public virtual float ReadSingle(int off)
        {
            Position = off;
            return _reader.ReadSingle();
        }

        #endregion

        #region double

        public virtual ByteBuffer Write(double value)
        {
            _writer.Write(value);
            return this;
        }
        public virtual double ReadDouble()
        {
            return _reader.ReadDouble();
        }
        public virtual ByteBuffer Write(int off, double value)
        {
            Position = off;
            _writer.Write(value);
            return this;
        }
        public virtual double ReadDouble(int off)
        {
            Position = off;
            return _reader.ReadDouble();
        }

        #endregion
        
        #region string

        public virtual ByteBuffer Write(string value)
        {
            _writer.Write(_encoding.GetBytes(value));
            return this;
        }

        public virtual ByteBuffer Write(string value, byte pad)
        {
            int count = _encoding.GetByteCount(value);
            if ((count & 1) == 1)
                count++;

            var bytes = new byte[count];
            if (_encoding.GetBytes(value, 0, value.Length, bytes, 0) < count)
                bytes[count - 1] = pad;

            _writer.Write(bytes);
            return this;
        }

        public virtual string ReadString()
        {
            Rewind();
            return ReadString(length());
        }

        public virtual string ReadString(int len)
        {
            var b = new byte[len];
            _reader.Read(b, 0, len);
            while (len > 0 && b[len - 1] == 0)
            {
                --len;
            }

            return _encoding.GetString(b, 0, len).Trim();
        }

        #endregion

        #region bool

        public virtual ByteBuffer Write(bool value)
        {
            _writer.Write(value);
            return this;
        }
        public virtual bool ReadBoolean()
        {
            return _reader.ReadBoolean();
        }

        #endregion

        public override string ToString()
        {
            var buf = new StringBuilder();

            byte[] arr = ToArray();
            foreach (byte b in arr)
            {
                buf.Append($"{b:X2} ");
            }

            return buf.ToString();
        }

        public static ByteBuffer Wrap(byte[] buf)
        {
            return Wrap(buf, ByteOrder.LittleEndian);
        }

        public static ByteBuffer Wrap(byte[] buf, ByteOrder byteOrder)
        {
            return new ByteBuffer(buf, byteOrder);
        }

        public static ByteBuffer Wrap(byte[] buf, int offset, int len)
        {
            return Wrap(buf, offset, len, ByteOrder.LittleEndian);
        }

        public static ByteBuffer Wrap(byte[] buf, int offset, int len, ByteOrder byteOrder)
        {
            return new ByteBuffer(buf, offset, len, byteOrder);
        }
    }
}
