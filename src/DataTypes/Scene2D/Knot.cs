namespace BinarySerializer.Onyx.Gba
{
    public class Knot : BinarySerializable
    {
        public byte Size { get; set; }
        public byte ActorsCount { get; set; }
        public byte CaptorsCount { get; set; }

        public byte[] ActorIds { get; set; }
        public byte[] CaptorIds { get; set; }
        public ushort[] ActorVramAddresses { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Size = s.Serialize<byte>(Size, name: nameof(Size));
            ActorsCount = s.Serialize<byte>(ActorsCount, name: nameof(ActorsCount));
            CaptorsCount = s.Serialize<byte>(CaptorsCount, name: nameof(CaptorsCount));

            ActorIds = s.SerializeArray<byte>(ActorIds, ActorsCount, name: nameof(ActorIds));
            CaptorIds = s.SerializeArray<byte>(CaptorIds, CaptorsCount, name: nameof(CaptorIds));

            s.Align(2);

            ActorVramAddresses = s.SerializeArray<ushort>(ActorVramAddresses, (Size - (s.CurrentPointer - Offset)) / 2, name: nameof(ActorVramAddresses));
        }
    }
}