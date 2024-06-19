namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class Vector2 : BinarySerializable
    {
        public short X { get; set; }
        public short Y { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            X = s.Serialize<short>(X, name: nameof(X));
            Y = s.Serialize<short>(Y, name: nameof(Y));
        }
    }
}