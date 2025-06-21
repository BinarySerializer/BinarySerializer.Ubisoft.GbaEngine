namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class Action : BinarySerializable
    {
        public EngineBox Box { get; set; }
        public ushort AnimationIndex { get; set; }
        public ActionFlags Flags { get; set; }

        public byte? MechModelType { get; set; }
        public byte Idx_MechModel { get; set; }

        // Dependencies
        public MechModel MechModel { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Box = s.SerializeInto<EngineBox>(Box, EngineBox.SerializeInto, name: nameof(Box));
            AnimationIndex = s.Serialize<byte>((byte)AnimationIndex, name: nameof(AnimationIndex));
            Flags = s.Serialize<ActionFlags>(Flags, name: nameof(Flags));
            MechModelType = s.SerializeNullable<byte>(MechModelType, name: nameof(MechModelType));
            Idx_MechModel = s.Serialize<byte>(Idx_MechModel, name: nameof(Idx_MechModel));
        }
    }
}