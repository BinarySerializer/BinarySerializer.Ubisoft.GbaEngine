namespace BinarySerializer.Ubisoft.GbaEngine.Rayman3
{
    public class GameCubeMapInfo : BinarySerializable
    {
        public byte CagesCount { get; set; }
        public byte LumsCount { get; set; }

        public Rayman3SoundEvent StartMusicSoundEvent { get; set; }

        public Rayman3SoundEvent StartSpecialMusicSoundEvent { get; set; }

        public bool HasBlueLum { get; set; }

        public string Name { get; set; }
        public int FileSize { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            CagesCount = s.Serialize<byte>(CagesCount, name: nameof(CagesCount));
            LumsCount = s.Serialize<byte>(LumsCount, name: nameof(LumsCount));

            StartMusicSoundEvent = s.Serialize<Rayman3SoundEvent>(StartMusicSoundEvent, name: nameof(StartMusicSoundEvent));
            StartSpecialMusicSoundEvent = s.Serialize<Rayman3SoundEvent>(StartSpecialMusicSoundEvent, name: nameof(StartSpecialMusicSoundEvent));

            HasBlueLum = s.Serialize<bool>(HasBlueLum, name: nameof(HasBlueLum));
            s.SerializePadding(1, logIfNotNull: true);

            Name = s.SerializeString(Name, 32, name: nameof(Name));
            FileSize = s.Serialize<int>(FileSize, name: nameof(FileSize));
        }
    }
}
