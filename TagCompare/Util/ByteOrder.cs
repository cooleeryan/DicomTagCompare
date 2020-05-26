namespace TagCompare.Util
{
    public class ByteOrder
    {
        private readonly string _name;

        private ByteOrder(string name)
        {
            this._name = name;
        }

        public static readonly ByteOrder BigEndian = new ByteOrder("BIG_ENDIAN");
        public static readonly ByteOrder LittleEndian = new ByteOrder("LITTLE_ENDIAN");

        public override string ToString()
        {
            return _name;
        }
    }
}
