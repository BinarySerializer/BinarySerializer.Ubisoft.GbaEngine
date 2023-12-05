namespace BinarySerializer.Onyx.Gba.Rayman3
{
    public class Act : BinarySerializable
    {
        public byte TextBankId { get; set; }
        public byte Byte_01 { get; set; }
        public Rayman3SoundEvent StartMusicSoundEvent { get; set; }
        public Rayman3SoundEvent StopMusicSoundEvent { get; set; }
        public byte[] Bytes_06 { get; set; }
        public byte FramesCount { get; set; }
        public Pointer<ActFrame[]> Frames { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            TextBankId = s.Serialize<byte>(TextBankId, name: nameof(TextBankId));
            Byte_01 = s.Serialize<byte>(Byte_01, name: nameof(Byte_01));
            StartMusicSoundEvent = s.Serialize<Rayman3SoundEvent>(StartMusicSoundEvent, name: nameof(StartMusicSoundEvent));
            StopMusicSoundEvent = s.Serialize<Rayman3SoundEvent>(StopMusicSoundEvent, name: nameof(StopMusicSoundEvent));
            Bytes_06 = s.SerializeArray<byte>(Bytes_06, 2, name: nameof(Bytes_06));
            FramesCount = s.Serialize<byte>(FramesCount, name: nameof(FramesCount));
            s.SerializePadding(3, logIfNotNull: true);
            Frames = s.SerializePointer<ActFrame[]>(Frames, name: nameof(Frames)).
                ResolveObjectArray(s, FramesCount);
        }
    }
}
