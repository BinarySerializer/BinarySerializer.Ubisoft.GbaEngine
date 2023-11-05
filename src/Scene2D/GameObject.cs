namespace BinarySerializer.Onyx.Gba
{
    public class GameObject : BinarySerializable
    {
        public Vector2 Pos { get; set; }

        // TODO: What are these flags for?
        public bool IsEnabled { get; set; }
        public bool Flag_1 { get; set; }
        public bool IsAnimatedObjectDynamic { get; set; }
        public bool Flag_3 { get; set; }
        public bool ResurrectsImmediately { get; set; }
        public bool ResurrectsInKnot { get; set; }
        public bool Flag_6 { get; set; }
        public bool Flag_7 { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Pos = s.SerializeObject<Vector2>(Pos, name: nameof(Pos));
            s.DoBits<byte>(b =>
            {
                IsEnabled = b.SerializeBits<bool>(IsEnabled, 1, name: nameof(IsEnabled));
                Flag_1 = b.SerializeBits<bool>(Flag_1, 1, name: nameof(Flag_1));
                IsAnimatedObjectDynamic = b.SerializeBits<bool>(IsAnimatedObjectDynamic, 1, name: nameof(IsAnimatedObjectDynamic));
                Flag_3 = b.SerializeBits<bool>(Flag_3, 1, name: nameof(Flag_3));
                ResurrectsImmediately = b.SerializeBits<bool>(ResurrectsImmediately, 1, name: nameof(ResurrectsImmediately));
                ResurrectsInKnot = b.SerializeBits<bool>(ResurrectsInKnot, 1, name: nameof(ResurrectsInKnot));
                Flag_6 = b.SerializeBits<bool>(Flag_6, 1, name: nameof(Flag_6));
                Flag_7 = b.SerializeBits<bool>(Flag_7, 1, name: nameof(Flag_7));
            });
        }
    }
}