namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class CaptorEvent : BinarySerializable
    {
        public ushort MessageId { get; set; }
        public ushort Param { get; set; }
        public short Delay { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            MessageId = s.Serialize<ushort>(MessageId, name: nameof(MessageId));
            Param = s.Serialize<ushort>(Param, name: nameof(Param));
            Delay = s.Serialize<short>(Delay, name: nameof(Delay));
        }
    }
}