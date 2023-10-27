namespace BinarySerializer.Onyx.Gba
{
    public class GameObject : BinarySerializable
    {
        public Vector2 Pos { get; set; }

        // TODO: What are these flags for?
        public bool IsActive { get; set; }
        public bool Flag_1 { get; set; }
        public bool IsAnimatedObjectDynamic { get; set; }
        public bool Flag_3 { get; set; }
        public bool ResurrectsImmediately { get; set; }
        public bool Flag_5 { get; set; }
        public bool Flag_6 { get; set; }
        public bool Flag_7 { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Pos = s.SerializeObject<Vector2>(Pos, name: nameof(Pos));
            s.DoBits<byte>(b =>
            {
                IsActive = b.SerializeBits<bool>(IsActive, 1, name: nameof(IsActive));
                Flag_1 = b.SerializeBits<bool>(Flag_1, 1, name: nameof(Flag_1));
                IsAnimatedObjectDynamic = b.SerializeBits<bool>(IsAnimatedObjectDynamic, 1, name: nameof(IsAnimatedObjectDynamic));
                Flag_3 = b.SerializeBits<bool>(Flag_3, 1, name: nameof(Flag_3));
                ResurrectsImmediately = b.SerializeBits<bool>(ResurrectsImmediately, 1, name: nameof(ResurrectsImmediately));
                Flag_5 = b.SerializeBits<bool>(Flag_5, 1, name: nameof(Flag_5));
                Flag_6 = b.SerializeBits<bool>(Flag_6, 1, name: nameof(Flag_6));
                Flag_7 = b.SerializeBits<bool>(Flag_7, 1, name: nameof(Flag_7));
            });
        }
    }
}