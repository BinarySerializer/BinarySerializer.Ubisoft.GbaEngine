namespace BinarySerializer.Ubisoft.GbaEngine
{
    public readonly struct CaptorEvent
    {
        public CaptorEvent(ushort messageId, ushort param, short delay)
        {
            MessageId = messageId;
            Param = param;
            Delay = delay;
        }

        public ushort MessageId { get;}
        public ushort Param { get; }
        public short Delay { get; }

        public static readonly SerializeInto<CaptorEvent> SerializeInto = (s, x) =>
        {
            ushort messageId = s.Serialize<ushort>(x.MessageId, name: nameof(MessageId));
            ushort param = s.Serialize<ushort>(x.Param, name: nameof(Param));
            short delay = s.Serialize<short>(x.Delay, name: nameof(Delay));

            return new CaptorEvent(messageId, param, delay);
        };
    }
}