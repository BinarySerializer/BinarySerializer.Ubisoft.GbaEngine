namespace BinarySerializer.Ubisoft.GbaEngine
{
    public readonly struct AffineMatrix : ISerializerShortLog
    {
        public AffineMatrix(Q8_8 pa, Q8_8 pb, Q8_8 pc, Q8_8 pd)
        {
            Pa = pa;
            Pb = pb;
            Pc = pc;
            Pd = pd;
        }

        public Q8_8 Pa { get; }
        public Q8_8 Pb { get; }
        public Q8_8 Pc { get; }
        public Q8_8 Pd { get; }

        public static SerializeInto<AffineMatrix> SerializeInto = (s, x) =>
        {
            Q8_8 pa = s.SerializeInto<Q8_8>(x.Pa, Q8_8.SerializeInto, name: nameof(Pa));
            Q8_8 pb = s.SerializeInto<Q8_8>(x.Pb, Q8_8.SerializeInto, name: nameof(Pb));
            Q8_8 pc = s.SerializeInto<Q8_8>(x.Pc, Q8_8.SerializeInto, name: nameof(Pc));
            Q8_8 pd = s.SerializeInto<Q8_8>(x.Pd, Q8_8.SerializeInto, name: nameof(Pd));

            return new AffineMatrix(pa, pb, pc, pd);
        };

        public string ShortLog => ToString();
        public override string ToString() => $"AffineMatrix({Pa}, {Pb}, {Pc}, {Pd})";
    }
}