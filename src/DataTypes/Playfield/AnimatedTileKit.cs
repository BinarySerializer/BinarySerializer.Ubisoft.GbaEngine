namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class AnimatedTileKit : Resource
    {
        public byte FramesCount { get; set; }
        public bool Is8Bit { get; set; }
        public byte Speed { get; set; }
        public byte TilesCount { get; set; }
        public byte TilesStep { get; set; }
        public ushort[] Tiles { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            s.DoBits<byte>(b =>
            {
                FramesCount = b.SerializeBits<byte>(FramesCount, 7, name: nameof(FramesCount));
                Is8Bit = b.SerializeBits<bool>(Is8Bit, 1, name: nameof(Is8Bit));
            });
            Speed = s.Serialize<byte>(Speed, name: nameof(Speed));
            TilesCount = s.Serialize<byte>(TilesCount, name: nameof(TilesCount));
            TilesStep = s.Serialize<byte>(TilesStep, name: nameof(TilesStep));
            Tiles = s.SerializeArray<ushort>(Tiles, TilesCount, name: nameof(Tiles));
        }
    }
}