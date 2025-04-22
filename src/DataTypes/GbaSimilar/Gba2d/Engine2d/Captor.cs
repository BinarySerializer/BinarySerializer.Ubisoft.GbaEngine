namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class Captor : GameObject
    {
        public byte EventsCount { get; set; }
        public bool TriggerOnMainActorDetection { get; set; }
        public bool IsDetected { get; set; }
        public bool CaptorFlag_2 { get; set; } // Unused
        public byte Idx_Events { get; set; }
        public byte Byte_07 { get; set; } // Unused
        public short BoxTop { get; set; }
        public short BoxLeft { get; set; }
        public short BoxBottom { get; set; }
        public short BoxRight { get; set; }

        // Dependencies
        public CaptorEvents Events { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            base.SerializeImpl(s);

            s.DoBits<byte>(b =>
            {
                EventsCount = b.SerializeBits<byte>(EventsCount, 5, name: nameof(EventsCount));
                TriggerOnMainActorDetection = b.SerializeBits<bool>(TriggerOnMainActorDetection, 1, name: nameof(TriggerOnMainActorDetection));
                IsDetected = b.SerializeBits<bool>(IsDetected, 1, name: nameof(IsDetected));
                CaptorFlag_2 = b.SerializeBits<bool>(CaptorFlag_2, 1, name: nameof(CaptorFlag_2));
            });
            Idx_Events = s.Serialize<byte>(Idx_Events, name: nameof(Idx_Events));
            Byte_07 = s.Serialize<byte>(Byte_07, name: nameof(Byte_07));
            BoxTop = s.Serialize<short>(BoxTop, name: nameof(BoxTop));
            BoxLeft = s.Serialize<short>(BoxLeft, name: nameof(BoxLeft));
            BoxBottom = s.Serialize<short>(BoxBottom, name: nameof(BoxBottom));
            BoxRight = s.Serialize<short>(BoxRight, name: nameof(BoxRight));
        }
    }
}