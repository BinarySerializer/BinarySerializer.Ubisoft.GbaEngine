namespace BinarySerializer.Onyx.Gba
{
    public class AffineMatrix : BinarySerializable, ISerializerShortLog
    {
        public short Pa { get; set; }
        public short Pb { get; set; }
        public short Pc { get; set; }
        public short Pd { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Pa = s.Serialize<short>(Pa, name: nameof(Pa));
            Pb = s.Serialize<short>(Pb, name: nameof(Pb));
            Pc = s.Serialize<short>(Pc, name: nameof(Pc));
            Pd = s.Serialize<short>(Pd, name: nameof(Pd));
        }

        public string ShortLog => ToString();
        public override string ToString() => $"AffineMatrix({Pa}, {Pb}, {Pc}, {Pd})";
    }
}