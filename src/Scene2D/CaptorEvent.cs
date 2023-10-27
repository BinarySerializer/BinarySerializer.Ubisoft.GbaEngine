namespace BinarySerializer.Onyx.Gba
{
    public class CaptorEvent : BinarySerializable
    {
        public ushort MessageId { get; set; }
        public byte Param1 { get; set; }
        public byte Param2 { get; set; }
        public short TriggersCount { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            MessageId = s.Serialize<ushort>(MessageId, name: nameof(MessageId));
            Param1 = s.Serialize<byte>(Param1, name: nameof(Param1));
            Param2 = s.Serialize<byte>(Param2, name: nameof(Param2));
            TriggersCount = s.Serialize<short>(TriggersCount, name: nameof(TriggersCount));
        }
    }
}