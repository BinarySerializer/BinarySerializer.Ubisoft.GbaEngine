namespace BinarySerializer.Ubisoft.GbaEngine.Rayman3
{
    public class SaveGame : BinarySerializable
    {
        public SavegameEeprom<SaveGameSlot>[] Slots { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Slots = s.SerializeObjectArray<SavegameEeprom<SaveGameSlot>>(Slots, 3, x => x.Pre_Size = 0x90, name: nameof(Slots));
        }
    }
}
