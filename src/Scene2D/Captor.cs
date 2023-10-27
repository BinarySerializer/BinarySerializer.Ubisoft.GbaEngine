namespace BinarySerializer.Onyx.Gba
{
    public class Captor : GameObject
    {
        public byte EventsCount { get; set; }
        public byte Flags { get; set; }
        public byte Idx_Events { get; set; }
        public byte Byte_07 { get; set; } // Unused
        public short BoxMinY { get; set; }
        public short BoxMinX { get; set; }
        public short BoxMaxY { get; set; }
        public short BoxMaxX { get; set; }

        // Dependencies
        public CaptorEvents Events { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            base.SerializeImpl(s);

            s.DoBits<byte>(b =>
            {
                EventsCount = b.SerializeBits<byte>(EventsCount, 5, name: nameof(EventsCount));
                Flags = b.SerializeBits<byte>(Flags, 3, name: nameof(Flags));
            });
            Idx_Events = s.Serialize<byte>(Idx_Events, name: nameof(Idx_Events));
            Byte_07 = s.Serialize<byte>(Byte_07, name: nameof(Byte_07));
            BoxMinY = s.Serialize<short>(BoxMinY, name: nameof(BoxMinY));
            BoxMinX = s.Serialize<short>(BoxMinX, name: nameof(BoxMinX));
            BoxMaxY = s.Serialize<short>(BoxMaxY, name: nameof(BoxMaxY));
            BoxMaxX = s.Serialize<short>(BoxMaxX, name: nameof(BoxMaxX));
        }
    }
}