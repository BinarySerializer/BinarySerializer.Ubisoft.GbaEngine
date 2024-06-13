namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class SoundEvent : BinarySerializable
    {
        public SoundEventType Type { get; set; }

        public ushort Priority { get; set; } // 0-100
        public ushort ResourceId { get; set; }
        public SoundType SoundType { get; set; } // 0-7, categorizes songs by type, mostly used to give them different volumes
        public bool EnablePan { get; set; } // Calculate pan based on object position - always false in Rayman 3
        public bool EnableRollOff { get; set; } // Calculate roll-off volume based on object position - only used for Boss Machine in Rayman 3

        public short StopEventId { get; set; }
        public short NextEventId { get; set; }
        public ushort FadeOutTime { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Type = s.Serialize<SoundEventType>(Type, name: nameof(Type));
            Priority = s.Serialize<ushort>(Priority, name: nameof(Priority));

            switch (Type)
            {
                case SoundEventType.Play:
                    ResourceId = s.Serialize<ushort>(ResourceId, name: nameof(ResourceId));
                    SoundType = s.Serialize<SoundType>(SoundType, name: nameof(SoundType));
                    s.DoBits<byte>(b =>
                    {
                        EnablePan = b.SerializeBits<bool>(EnablePan, 1, name: nameof(EnablePan));
                        EnableRollOff = b.SerializeBits<bool>(EnableRollOff, 1, name: nameof(EnableRollOff));
                        b.SerializePadding(6, logIfNotNull: true);
                    });
                    break;

                case SoundEventType.Stop:
                    StopEventId = s.Serialize<short>(StopEventId, name: nameof(StopEventId));
                    FadeOutTime = s.Serialize<ushort>(FadeOutTime, name: nameof(FadeOutTime));
                    break;

                case SoundEventType.StopAndGo:
                    NextEventId = s.Serialize<short>(NextEventId, name: nameof(NextEventId));
                    StopEventId = s.Serialize<short>(StopEventId, name: nameof(StopEventId));
                    FadeOutTime = s.Serialize<ushort>(FadeOutTime, name: nameof(FadeOutTime));
                    break;

                default:
                    throw new BinarySerializableException(this, $"Invalid event type {Type}");
            }
        }

        public enum SoundEventType : ushort
        {
            Invalid = 0,
            Play = 1,
            Stop = 2,
            StopAndGo = 3,
        }
    }
}