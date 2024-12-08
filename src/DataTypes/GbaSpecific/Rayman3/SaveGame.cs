namespace BinarySerializer.Ubisoft.GbaEngine.Rayman3
{
    public class SaveGame : BinarySerializable
    {
        public bool[] ValidSlots { get; set; }
        public SaveGameSlot[] Slots { get; set; }
        public int MusicVolume { get; set; }
        public int SfxVolume { get; set; }
        public int Language { get; set; }
        public string MultiplayerName { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            GbaEngineSettings settings = s.GetRequiredSettings<GbaEngineSettings>();

            if (settings.Platform == Platform.NGage)
            {
                s.SerializeMagic<uint>(0xDEADBEEF);
                ValidSlots = s.SerializeArray<bool>(ValidSlots, 3, name: nameof(ValidSlots));
            }

            Slots = s.SerializeObjectArray<SaveGameSlot>(Slots, 3, name: nameof(Slots));

            if (settings.Platform == Platform.NGage)
            {
                MusicVolume = s.Serialize<int>(MusicVolume, name: nameof(MusicVolume));
                SfxVolume = s.Serialize<int>(SfxVolume, name: nameof(SfxVolume));
                MultiplayerName = s.SerializeString(MultiplayerName, length: 64, name: nameof(MultiplayerName));
            }
        }
    }
}
