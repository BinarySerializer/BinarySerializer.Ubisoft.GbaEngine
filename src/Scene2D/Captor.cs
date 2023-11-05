namespace BinarySerializer.Onyx.Gba
{
    public class Captor : GameObject
    {
        public byte EventsCount { get; set; }
        public bool TriggerOnMainActorDetection { get; set; }
        public bool IsTriggering { get; set; }
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
                TriggerOnMainActorDetection = b.SerializeBits<bool>(TriggerOnMainActorDetection, 1, name: nameof(TriggerOnMainActorDetection));
                IsTriggering = b.SerializeBits<bool>(IsTriggering, 1, name: nameof(IsTriggering));
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