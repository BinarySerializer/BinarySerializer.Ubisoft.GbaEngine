namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class GameObject : BinarySerializable
    {
        public Vector2 Pos { get; set; }

        public bool IsEnabled { get; set; }
        public bool IsAwake { get; set; }
        public bool IsAnimatedObjectDynamic { get; set; }
        public bool IsProjectile { get; set; }
        public bool ResurrectsImmediately { get; set; }
        public bool ResurrectsLater { get; set; }
        public bool Flag_6 { get; set; }
        public bool Flag_7 { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Pos = s.SerializeObject<Vector2>(Pos, name: nameof(Pos));
            s.DoBits<byte>(b =>
            {
                IsEnabled = b.SerializeBits<bool>(IsEnabled, 1, name: nameof(IsEnabled));
                IsAwake = b.SerializeBits<bool>(IsAwake, 1, name: nameof(IsAwake));
                IsAnimatedObjectDynamic = b.SerializeBits<bool>(IsAnimatedObjectDynamic, 1, name: nameof(IsAnimatedObjectDynamic));
                IsProjectile = b.SerializeBits<bool>(IsProjectile, 1, name: nameof(IsProjectile));
                ResurrectsImmediately = b.SerializeBits<bool>(ResurrectsImmediately, 1, name: nameof(ResurrectsImmediately));
                ResurrectsLater = b.SerializeBits<bool>(ResurrectsLater, 1, name: nameof(ResurrectsLater));
                Flag_6 = b.SerializeBits<bool>(Flag_6, 1, name: nameof(Flag_6));
                Flag_7 = b.SerializeBits<bool>(Flag_7, 1, name: nameof(Flag_7));
            });
        }
    }
}