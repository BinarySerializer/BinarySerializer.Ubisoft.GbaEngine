namespace BinarySerializer.Ubisoft.GbaEngine.Rayman3
{
    public class NGageSaveGame : BinarySerializable
    {
        public bool[] ValidSlots { get; set; }
        public SaveGameSlot[] Slots { get; set; }
        public int MusicVolume { get; set; }
        public int SfxVolume { get; set; }
        public int Language { get; set; }
        public string MultiplayerName { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            s.SerializeMagic<uint>(0xDEADBEEF);
            ValidSlots = s.SerializeArray<bool>(ValidSlots, 3, name: nameof(ValidSlots));
            Slots = s.SerializeObjectArray<SaveGameSlot>(Slots, 3, name: nameof(Slots));
            MusicVolume = s.Serialize<int>(MusicVolume, name: nameof(MusicVolume));
            SfxVolume = s.Serialize<int>(SfxVolume, name: nameof(SfxVolume));
            Language = s.Serialize<int>(Language, name: nameof(Language));
            MultiplayerName = s.SerializeString(MultiplayerName, length: 64, name: nameof(MultiplayerName));
        }
    }
}