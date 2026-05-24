namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class AffineMatrices : Resource
    {
        public AffineMatrix[] Matrices { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            Matrices = s.SerializeIntoArray<AffineMatrix>(Matrices, Size / 8, AffineMatrix.SerializeInto, name: nameof(Matrices));
        }
    }
}