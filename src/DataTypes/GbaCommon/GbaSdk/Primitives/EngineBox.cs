namespace BinarySerializer.Ubisoft.GbaEngine
{
    public readonly struct EngineBox
    {
        public EngineBox(sbyte top, sbyte left, sbyte bottom, sbyte right)
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
        }

        public sbyte Top { get; }
        public sbyte Left { get; }
        public sbyte Bottom { get; }
        public sbyte Right { get; }

        public static SerializeInto<EngineBox> SerializeInto = (s, x) =>
        {
            sbyte top = s.Serialize<sbyte>(x.Top, name: nameof(Top));
            sbyte left = s.Serialize<sbyte>(x.Left, name: nameof(Left));
            sbyte bottom = s.Serialize<sbyte>(x.Bottom, name: nameof(Bottom));
            sbyte right = s.Serialize<sbyte>(x.Right, name: nameof(Right));

            return new EngineBox(top, left, bottom, right);
        };
    }
}