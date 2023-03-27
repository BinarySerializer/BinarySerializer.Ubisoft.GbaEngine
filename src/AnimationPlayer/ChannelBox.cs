namespace BinarySerializer.Onyx.Gba
{
    public class ChannelBox : BinarySerializable
    {
        public sbyte MinY { get; set; }
        public sbyte MaxY { get; set; }
        public sbyte MinX { get; set; }
        public sbyte MaxX { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            MinY = s.Serialize<sbyte>(MinY, name: nameof(MinY));
            MaxY = s.Serialize<sbyte>(MaxY, name: nameof(MaxY));
            MinX = s.Serialize<sbyte>(MinX, name: nameof(MinX));
            MaxX = s.Serialize<sbyte>(MaxX, name: nameof(MaxX));
        }
    }
}