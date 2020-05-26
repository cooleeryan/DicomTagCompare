using System;
using System.IO;
using System.Net;

namespace TagCompare.Util
{
    public class BeBinaryReader : BinaryReader
    {
        public BeBinaryReader(Stream s) : base(s)
        {

        }

        public override short ReadInt16()
        {
            return IPAddress.NetworkToHostOrder(base.ReadInt16());
        }

        public override ushort ReadUInt16()
        {
            return (ushort)IPAddress.NetworkToHostOrder(base.ReadInt16());
        }

        public override int ReadInt32()
        {
            return IPAddress.NetworkToHostOrder(base.ReadInt32());
        }

        public override uint ReadUInt32()
        {
            return (uint)IPAddress.NetworkToHostOrder(base.ReadInt32());
        }

        public override long ReadInt64()
        {
            return IPAddress.NetworkToHostOrder(base.ReadInt64());
        }

        public override ulong ReadUInt64()
        {
            return (ulong)IPAddress.NetworkToHostOrder(base.ReadInt64());
        }

        public override float ReadSingle()
        {
            var bytes = BitConverter.GetBytes(base.ReadSingle());
            Array.Reverse(bytes);
            return BitConverter.ToSingle(bytes, 0);
        }

        public override double ReadDouble()
        {
            var bytes = BitConverter.GetBytes(base.ReadDouble());
            Array.Reverse(bytes);
            return BitConverter.ToDouble(bytes, 0);
        }
    }
}
