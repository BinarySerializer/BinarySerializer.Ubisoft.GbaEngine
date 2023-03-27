namespace BinarySerializer.Onyx.Gba
{
    public class AffineMatrices : Resource
    {
        public AffineMatrix[] Matrices { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            Matrices = s.SerializeObjectArray<AffineMatrix>(Matrices, Size / 8, name: nameof(Matrices));
        }
    }
}