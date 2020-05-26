using System;
using System.IO;
using System.Net;

namespace TagCompare.Util
{
    public class BeBinaryWriter :BinaryWriter
    {
        public BeBinaryWriter(Stream s) : base(s)
        {

        }

        public override void Write(short value)
        {
            base.Write(IPAddress.HostToNetworkOrder(value));
        }

        public override void Write(int value)
        {
            base.Write(IPAddress.HostToNetworkOrder(value));
        }

        public override void Write(long value)
        {
            base.Write(IPAddress.HostToNetworkOrder(value));
        }

        public override void Write(float value)
        {
            var bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            base.Write(BitConverter.ToSingle(bytes, 0));
        }

        public override void Write(double value)
        {
            var bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            base.Write(BitConverter.ToDouble(bytes, 0));
        }
    }
}
