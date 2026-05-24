namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class AffineMatrix : BinarySerializable, ISerializerShortLog
    {
        public Q8_8 Pa { get; set; }
        public Q8_8 Pb { get; set; }
        public Q8_8 Pc { get; set; }
        public Q8_8 Pd { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Pa = s.SerializeInto<Q8_8>(Pa, Q8_8.SerializeInto, name: nameof(Pa));
            Pb = s.SerializeInto<Q8_8>(Pb, Q8_8.SerializeInto, name: nameof(Pb));
            Pc = s.SerializeInto<Q8_8>(Pc, Q8_8.SerializeInto, name: nameof(Pc));
            Pd = s.SerializeInto<Q8_8>(Pd, Q8_8.SerializeInto, name: nameof(Pd));
        }

        public string ShortLog => ToString();
        public override string ToString() => $"AffineMatrix({Pa}, {Pb}, {Pc}, {Pd})";
    }
}