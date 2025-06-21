namespace BinarySerializer.Ubisoft.GbaEngine
{
    public readonly struct Vector2
    {
        public Vector2(short x, short y)
        {
            X = x;
            Y = y;
        }

        public short X { get; }
        public short Y { get; }

        public static SerializeInto<Vector2> SerializeInto = (s, x) =>
        {
            short xx = s.Serialize<short>(x.X, name: nameof(X));
            short yy = s.Serialize<short>(x.Y, name: nameof(Y));
            
            return new Vector2(xx, yy);
        };
    }
}