namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class AffineMatrix : BinarySerializable, ISerializerShortLog
    {
        public FixedPointInt16 Pa { get; set; }
        public FixedPointInt16 Pb { get; set; }
        public FixedPointInt16 Pc { get; set; }
        public FixedPointInt16 Pd { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Pa = s.SerializeObject<FixedPointInt16>(Pa, x => x.Pre_PointPosition = 8, name: nameof(Pa));
            Pb = s.SerializeObject<FixedPointInt16>(Pb, x => x.Pre_PointPosition = 8, name: nameof(Pb));
            Pc = s.SerializeObject<FixedPointInt16>(Pc, x => x.Pre_PointPosition = 8, name: nameof(Pc));
            Pd = s.SerializeObject<FixedPointInt16>(Pd, x => x.Pre_PointPosition = 8, name: nameof(Pd));
        }

        public string ShortLog => ToString();
        public override string ToString() => $"AffineMatrix({Pa}, {Pb}, {Pc}, {Pd})";
    }
}