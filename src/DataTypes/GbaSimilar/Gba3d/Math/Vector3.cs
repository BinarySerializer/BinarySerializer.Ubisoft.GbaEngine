namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class Vector3 : BinarySerializable
    {
        public Q16_16 X { get; set; }
        public Q16_16 Y { get; set; }
        public Q16_16 Z { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            X = s.SerializeInto<Q16_16>(X, Q16_16.SerializeInto, name: nameof(X));
            Y = s.SerializeInto<Q16_16>(Y, Q16_16.SerializeInto, name: nameof(Y));
            Z = s.SerializeInto<Q16_16>(Z, Q16_16.SerializeInto, name: nameof(Z));
        }
    }
}