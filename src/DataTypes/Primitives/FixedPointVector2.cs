namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class FixedPointVector2 : BinarySerializable
    {
        public FixedPointInt32 X { get; set; }
        public FixedPointInt32 Y { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            X = s.SerializeObject<FixedPointInt32>(X, x => x.Pre_PointPosition = 16, name: nameof(X));
            Y = s.SerializeObject<FixedPointInt32>(Y, x => x.Pre_PointPosition = 16, name: nameof(Y));
        }
    }
}