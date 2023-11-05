namespace BinarySerializer.Onyx.Gba
{
    public class Captor : GameObject
    {
        public byte EventsCount { get; set; }
        public bool CaptorFlag_0 { get; set; }
        public bool CaptorFlag_1 { get; set; }
        public bool CaptorFlag_2 { get; set; }
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
                CaptorFlag_0 = b.SerializeBits<bool>(CaptorFlag_0, 1, name: nameof(CaptorFlag_0));
                CaptorFlag_1 = b.SerializeBits<bool>(CaptorFlag_1, 1, name: nameof(CaptorFlag_1));
                CaptorFlag_2 = b.SerializeBits<bool>(CaptorFlag_2, 1, name: nameof(CaptorFlag_2));
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