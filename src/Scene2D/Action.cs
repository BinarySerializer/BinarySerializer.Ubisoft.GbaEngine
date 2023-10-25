namespace BinarySerializer.Onyx.Gba
{
    public class Action : BinarySerializable
    {
        public EngineBox Box { get; set; }
        public ushort AnimationIndex { get; set; }
        public ActionFlags Flags { get; set; }
        public byte? Type { get; set; }
        public byte Idx_Data { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Box = s.SerializeObject<EngineBox>(Box, name: nameof(Box));
            AnimationIndex = s.Serialize<byte>((byte)AnimationIndex, name: nameof(AnimationIndex));
            Flags = s.Serialize<ActionFlags>(Flags, name: nameof(Flags));
            Type = s.SerializeNullable<byte>(Type, name: nameof(Type));
            Idx_Data = s.Serialize<byte>(Idx_Data, name: nameof(Idx_Data));
        }
    }
}