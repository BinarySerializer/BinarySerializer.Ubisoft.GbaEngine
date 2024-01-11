namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class CaptorEvent : BinarySerializable
    {
        public ushort MessageId { get; set; }
        public ushort Param { get; set; }
        public short TriggersCount { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            MessageId = s.Serialize<ushort>(MessageId, name: nameof(MessageId));
            Param = s.Serialize<ushort>(Param, name: nameof(Param));
            TriggersCount = s.Serialize<short>(TriggersCount, name: nameof(TriggersCount));
        }
    }
}