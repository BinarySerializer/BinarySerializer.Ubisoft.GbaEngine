namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class EngineBox : BinarySerializable
    {
        public sbyte Top { get; set; }
        public sbyte Left { get; set; }
        public sbyte Bottom { get; set; }
        public sbyte Right { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Top = s.Serialize<sbyte>(Top, name: nameof(Top));
            Left = s.Serialize<sbyte>(Left, name: nameof(Left));
            Bottom = s.Serialize<sbyte>(Bottom, name: nameof(Bottom));
            Right = s.Serialize<sbyte>(Right, name: nameof(Right));
        }
    }
}