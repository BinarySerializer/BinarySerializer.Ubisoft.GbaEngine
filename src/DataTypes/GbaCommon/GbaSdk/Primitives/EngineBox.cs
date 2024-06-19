namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class EngineBox : BinarySerializable
    {
        public sbyte MinY { get; set; }
        public sbyte MinX { get; set; }
        public sbyte MaxY { get; set; }
        public sbyte MaxX { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            MinY = s.Serialize<sbyte>(MinY, name: nameof(MinY));
            MinX = s.Serialize<sbyte>(MinX, name: nameof(MinX));
            MaxY = s.Serialize<sbyte>(MaxY, name: nameof(MaxY));
            MaxX = s.Serialize<sbyte>(MaxX, name: nameof(MaxX));
        }
    }
}