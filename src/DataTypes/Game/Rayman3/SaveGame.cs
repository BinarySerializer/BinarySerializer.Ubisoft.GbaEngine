namespace BinarySerializer.Ubisoft.GbaEngine.Rayman3
{
    public class SaveGame : BinarySerializable
    {
        public SaveGameSlot[] Slots { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Slots = s.SerializeObjectArray<SaveGameSlot>(Slots, 3, name: nameof(Slots));
        }
    }
}
