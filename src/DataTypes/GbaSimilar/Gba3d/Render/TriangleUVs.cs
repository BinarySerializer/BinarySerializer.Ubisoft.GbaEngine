namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class TriangleUVs : BinarySerializable
    {
        public UV[] UVs { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            UVs = s.SerializeObjectArray<UV>(UVs, 3, name: nameof(UVs));
        }
    }
}