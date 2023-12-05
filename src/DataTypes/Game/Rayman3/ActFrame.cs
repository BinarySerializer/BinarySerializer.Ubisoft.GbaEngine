namespace BinarySerializer.Onyx.Gba.Rayman3
{
    public class ActFrame : BinarySerializable
    {
        public Pointer<ActBitmap> Bitmap { get; set; }
        public short TextId { get; set; }
        public Pointer<RGB555Color[]> Palette { get; set; }
        public Rayman3SoundEvent MusicSongEvent { get; set; }
        public Rayman3SoundEvent UnusedMusicSongEvent { get; set; } // Unused

        public override void SerializeImpl(SerializerObject s)
        {
            Bitmap = s.SerializePointer<ActBitmap>(Bitmap, name: nameof(Bitmap)).
                ResolveObject(s);
            TextId = s.Serialize<short>(TextId, name: nameof(TextId));
            s.SerializePadding(2, logIfNotNull: true);
            Palette = s.SerializePointer<RGB555Color[]>(Palette, name: nameof(Palette)).
                ResolveObjectArray(s, 256);
            MusicSongEvent = s.Serialize<Rayman3SoundEvent>(MusicSongEvent, name: nameof(MusicSongEvent));
            UnusedMusicSongEvent = s.Serialize<Rayman3SoundEvent>(UnusedMusicSongEvent, name: nameof(UnusedMusicSongEvent));
        }
    }
}