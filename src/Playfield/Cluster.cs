namespace BinarySerializer.Onyx.Gba
{
    public class Cluster : Resource
    {
        public FixedPointVector2 Scroll { get; set; }

        public ushort SizeX { get; set; }
        public ushort SizeY { get; set; }

        public byte Byte_0C { get; set; } // Probably a bool - determines how it moves?
        public bool CanMove { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            Scroll = s.SerializeObject<FixedPointVector2>(Scroll, name: nameof(Scroll));
            SizeX = s.Serialize<ushort>(SizeX, name: nameof(SizeX));
            SizeY = s.Serialize<ushort>(SizeY, name: nameof(SizeY));
            Byte_0C = s.Serialize<byte>(Byte_0C, name: nameof(Byte_0C));
            CanMove = s.Serialize<bool>(CanMove, name: nameof(CanMove));

            s.SerializePadding(2, logIfNotNull: true);
        }
    }
}