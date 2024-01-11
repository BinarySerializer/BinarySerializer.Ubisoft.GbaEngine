namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class SoundEvent : BinarySerializable
    {
        public SoundEventType Type { get; set; }

        public ushort Priority { get; set; } // 0-100
        public ushort ResourceId { get; set; }
        public byte SoundType { get; set; } // 0-7, categorizes songs, used to give them different volumes
        public bool Type1_Flag0 { get; set; } // Always false in Rayman 3
        public bool Type1_Flag1 { get; set; } // Only true for one event in Rayman 3

        public ushort StopEventId { get; set; }
        public ushort NextEventId { get; set; }
        public ushort FadeOutTime { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Type = s.Serialize<SoundEventType>(Type, name: nameof(Type));
            Priority = s.Serialize<ushort>(Priority, name: nameof(Priority));

            switch (Type)
            {
                case SoundEventType.PlaySong:
                    ResourceId = s.Serialize<ushort>(ResourceId, name: nameof(ResourceId));
                    SoundType = s.Serialize<byte>(SoundType, name: nameof(SoundType));
                    s.DoBits<byte>(b =>
                    {
                        Type1_Flag0 = b.SerializeBits<bool>(Type1_Flag0, 1, name: nameof(Type1_Flag0));
                        Type1_Flag1 = b.SerializeBits<bool>(Type1_Flag1, 1, name: nameof(Type1_Flag1));
                        b.SerializePadding(6, logIfNotNull: true);
                    });
                    break;

                case SoundEventType.StopSong:
                    StopEventId = s.Serialize<ushort>(StopEventId, name: nameof(StopEventId));
                    FadeOutTime = s.Serialize<ushort>(FadeOutTime, name: nameof(FadeOutTime));
                    break;

                case SoundEventType.StopAndSetNext:
                    NextEventId = s.Serialize<ushort>(NextEventId, name: nameof(NextEventId));
                    StopEventId = s.Serialize<ushort>(StopEventId, name: nameof(StopEventId));
                    FadeOutTime = s.Serialize<ushort>(FadeOutTime, name: nameof(FadeOutTime));
                    break;

                default:
                    throw new BinarySerializableException(this, $"Invalid event type {Type}");
            }
        }

        public enum SoundEventType : ushort
        {
            PlaySong = 1,
            StopSong = 2,
            StopAndSetNext = 3,
        }
    }
}