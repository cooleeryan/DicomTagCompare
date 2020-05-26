using System.Text;
using TagCompare.Dict;

namespace TagCompare.Util
{
    public class StringUtils
    {
        private StringUtils(){}

        public static string GetValue(ByteBuffer buffer, int vr, int length)
        {
            if (DicomVr.IsStringValue(vr))
            {
                return buffer.ReadBytesToString(length);
            }

            switch (vr)
            {
                case DicomVr.AT:
                    return GetValueAT(buffer, length);
                case DicomVr.FD:
                    return GetValueFD(buffer, length);
                case DicomVr.FL:
                    return GetValueFL(buffer, length);
                case DicomVr.OB:
                case DicomVr.OW:
                case DicomVr.UN:
                    return GetValueOB(buffer, length);
                case DicomVr.SL:
                    return GetValueSL(buffer, length);
                case DicomVr.SQ:
                    return GetValueSQ(buffer, length);
                case DicomVr.SS:
                    return GetValueSS(buffer, length);
                case DicomVr.UL:
                    return GetValueUL(buffer, length);
                case DicomVr.US:
                    return GetValueUS(buffer, length);
                default:
                    return "GetValue ERROR";
            }
        }


        public static string GetValueAT(ByteBuffer buffer, int length)
        {
            int capacity = length / 4 * 9 - 1;
            if (capacity < 0)
            {
                return string.Empty;
            }

            var strb = new StringBuilder(capacity);
            strb.Append($"{buffer.ReadInt16():X4}");
            strb.Append($"{buffer.ReadInt16():X4}");
            for (int index = length - 4; index >= 4 && strb.Length < length; index -= 4)
            {
                strb.Append('\\');
                strb.Append($"{buffer.ReadInt16():X4}");
                strb.Append($"{buffer.ReadInt16():X4}");
            }

            return strb.ToString();
        }

        public static string GetValueFD(ByteBuffer buffer, int length)
        {
            var num = length / 8;
            if (length < 8)
            {
                return string.Empty;
            }

            var strb = new StringBuilder(length + num -1);
            strb.Append(buffer.ReadDouble());
            if (num >= 2)
            {
                for (int index = 1; index < num; ++index)
                {
                    strb.Append('\\').Append(buffer.ReadDouble());
                }
            }

            return strb.ToString();
        }

        public static string GetValueFL(ByteBuffer buffer, int length)
        {
            var num = length / 4;
            if (length < 4)
            {
                return string.Empty;
            }

            var strb = new StringBuilder(length + num -1);
            strb.Append(buffer.ReadSingle());
            if (num >= 2)
            {
                for (int index = 1; index < num; ++index)
                {
                    strb.Append('\\').Append(buffer.ReadSingle());
                }
            }

            return strb.ToString();
        }

        public static string GetValueOB(ByteBuffer buffer, int length)
        {
            buffer.ReadBytes(length);
            return string.Empty;
        }

        public static string GetValueSL(ByteBuffer buffer, int length)
        {
            var num = length / 4;
            if (length < 4)
            {
                return string.Empty;
            }

            var strb = new StringBuilder(length + num -1);
            strb.Append(buffer.ReadInt32());

            for (int index = 1; index < num; ++index)
            {
                strb.Append('\\').Append(buffer.ReadInt32());
            }

            return strb.ToString();
        }

        public static string GetValueSQ(ByteBuffer buffer, int length)
        {
            if (length != -1)
            {
                buffer.ReadBytes(length);
            }

            return "(Sequence data)";
        }

        public static string GetValueSS(ByteBuffer buffer, int length)
        {
            var num = length / 2;
            if (length < 2)
            {
                return string.Empty;
            }

            var strb = new StringBuilder(length + num -1);
            strb.Append(buffer.ReadInt16());

            for (int index = 1; index < num; ++index)
            {
                strb.Append('\\').Append(buffer.ReadInt16());
            }

            return strb.ToString();
        }

        public static string GetValueUL(ByteBuffer buffer, int length)
        {
            var num = length / 4;
            if (length < 4)
            {
                return string.Empty;
            }

            var strb = new StringBuilder(length + num -1);
            strb.Append(buffer.ReadInt32() & -1);
            if (num >= 2)
            {
                for (int index = 1; index < num; ++index)
                {
                    strb.Append('\\').Append(buffer.ReadInt32() & -1);
                }
            }

            return strb.ToString();
        }

        public static string GetValueUS(ByteBuffer buffer, int length)
        {
            var num = length / 2;
            if (length < 2)
            {
                return string.Empty;
            }

            var strb = new StringBuilder(length + num -1);
            strb.Append(buffer.ReadInt16() & ushort.MaxValue);

            for (int index = 1; index < num; ++index)
            {
                strb.Append('\\').Append(buffer.ReadInt16() & ushort.MaxValue);
            }

            return strb.ToString();
        }
    }
}
