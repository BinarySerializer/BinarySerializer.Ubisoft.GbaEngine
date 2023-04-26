namespace BinarySerializer.Onyx.Gba
{
    public class Cluster : Resource
    {
        public FixedPointVector2 ScrollFactor { get; set; }

        public ushort SizeX { get; set; }
        public ushort SizeY { get; set; }

        public byte Byte_0C { get; set; } // Probably a bool - determines how it moves?
        public bool Stationary { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            ScrollFactor = s.SerializeObject<FixedPointVector2>(ScrollFactor, name: nameof(ScrollFactor));
            SizeX = s.Serialize<ushort>(SizeX, name: nameof(SizeX));
            SizeY = s.Serialize<ushort>(SizeY, name: nameof(SizeY));
            Byte_0C = s.Serialize<byte>(Byte_0C, name: nameof(Byte_0C));
            Stationary = s.Serialize<bool>(Stationary, name: nameof(Stationary));

            s.SerializePadding(2, logIfNotNull: true);
        }
    }
}