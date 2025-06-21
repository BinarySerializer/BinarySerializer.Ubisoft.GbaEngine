namespace BinarySerializer.Ubisoft.GbaEngine
{
    public readonly struct ChannelBox
    {
        public ChannelBox(sbyte bottom, sbyte top, sbyte left, sbyte right)
        {
            Bottom = bottom;
            Top = top;
            Left = left;
            Right = right;
        }

        public sbyte Bottom { get; }
        public sbyte Top { get; }
        public sbyte Left { get; }
        public sbyte Right { get; }

        public static SerializeInto<ChannelBox> SerializeInto = (s, x) =>
        {
            sbyte bottom = s.Serialize<sbyte>(x.Bottom, name: nameof(Bottom));
            sbyte top = s.Serialize<sbyte>(x.Top, name: nameof(Top));
            sbyte left = s.Serialize<sbyte>(x.Left, name: nameof(Left));
            sbyte right = s.Serialize<sbyte>(x.Right, name: nameof(Right));

            return new ChannelBox(bottom, top, left, right);
        };
    }
}