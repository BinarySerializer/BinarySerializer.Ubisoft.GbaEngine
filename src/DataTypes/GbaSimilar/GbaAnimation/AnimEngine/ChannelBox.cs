namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class ChannelBox : BinarySerializable
    {
        public sbyte Bottom { get; set; }
        public sbyte Top { get; set; }
        public sbyte Left { get; set; }
        public sbyte Right { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Bottom = s.Serialize<sbyte>(Bottom, name: nameof(Bottom));
            Top = s.Serialize<sbyte>(Top, name: nameof(Top));
            Left = s.Serialize<sbyte>(Left, name: nameof(Left));
            Right = s.Serialize<sbyte>(Right, name: nameof(Right));
        }
    }
}