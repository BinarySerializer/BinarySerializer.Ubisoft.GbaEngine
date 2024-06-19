namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class Triangle : BinarySerializable
    {
        public ushort[] Vertices { get; set; }
        public ushort UVsOffset { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Vertices = s.SerializeArray<ushort>(Vertices, 3, name: nameof(Vertices));
            UVsOffset = s.Serialize<ushort>(UVsOffset, name: nameof(UVsOffset));
        }
    }
}