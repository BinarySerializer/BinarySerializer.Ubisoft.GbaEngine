namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class NGageSoundEvent : BinarySerializable
    {
        public bool IsValid { get; set; }

        public int SoundResourceId { get; set; }
        public int InstrumentsResourceId { get; set; } // Only set if music
        public int Volume { get; set; }

        public bool Loop { get; set; }
        public bool PlaySong { get; set; } // True = Play, False = Stop
        public bool IsMusic { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            s.DoBits<int>(b =>
            {
                IsValid = b.SerializeBits<int>(IsValid ? 0 : -1, 32, name: nameof(IsValid)) != -1;

                if (!IsValid)
                    return;

                b.Position = 0;

                SoundResourceId = b.SerializeBits<int>(SoundResourceId, 10, name: nameof(SoundResourceId));
                InstrumentsResourceId = b.SerializeBits<int>(InstrumentsResourceId, 10, name: nameof(InstrumentsResourceId));
                b.SerializePadding(2, logIfNotNull: true);
                Volume = b.SerializeBits<int>(Volume, 3, name: nameof(Volume));
                b.SerializePadding(4, logIfNotNull: true);
                Loop = b.SerializeBits<bool>(Loop, 1, name: nameof(Loop));
                PlaySong = b.SerializeBits<bool>(PlaySong, 1, name: nameof(PlaySong));
                IsMusic = b.SerializeBits<bool>(IsMusic, 1, name: nameof(IsMusic));
            });
        }
    }
}