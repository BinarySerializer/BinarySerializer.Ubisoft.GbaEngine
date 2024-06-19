using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Ubisoft.GbaEngine.Rayman3
{
    public class ActFrame : BinarySerializable
    {
        public Pointer BitmapPointer { get; set; }
        public ushort BitmapResourceId { get; set; }
        public short TextId { get; set; }
        public Pointer PalettePointer { get; set; }
        public ushort PaletteResourceId { get; set; }
        public Rayman3SoundEvent MusicSongEvent { get; set; }
        public Rayman3SoundEvent UnusedMusicSongEvent { get; set; } // Unused

        // Serialized from pointers
        public Bitmap Bitmap { get; set; }
        public Palette256 Palette { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            GbaEngineSettings settings = s.GetRequiredSettings<GbaEngineSettings>();

            if (settings.Platform == Platform.GBA)
            {
                BitmapPointer = s.SerializePointer(BitmapPointer, name: nameof(BitmapPointer));
                TextId = s.Serialize<short>(TextId, name: nameof(TextId));
                s.SerializePadding(2, logIfNotNull: true);
                PalettePointer = s.SerializePointer(PalettePointer, name: nameof(PalettePointer));
                MusicSongEvent = s.Serialize<Rayman3SoundEvent>(MusicSongEvent, name: nameof(MusicSongEvent));
                UnusedMusicSongEvent = s.Serialize<Rayman3SoundEvent>(UnusedMusicSongEvent, name: nameof(UnusedMusicSongEvent));

                s.DoAt(BitmapPointer, () => Bitmap = s.SerializeObject<Bitmap>(Bitmap, name: nameof(Bitmap)));
                s.DoAt(PalettePointer, () => Palette = s.SerializeObject<Palette256>(Palette, name: nameof(Palette)));
            }
            else if (settings.Platform == Platform.NGage)
            {
                BitmapResourceId = s.Serialize<ushort>(BitmapResourceId, name: nameof(BitmapResourceId));
                TextId = s.Serialize<short>(TextId, name: nameof(TextId));
                PaletteResourceId = s.Serialize<ushort>(PaletteResourceId, name: nameof(PaletteResourceId));
                MusicSongEvent = s.Serialize<Rayman3SoundEvent>(MusicSongEvent, name: nameof(MusicSongEvent));
                UnusedMusicSongEvent = s.Serialize<Rayman3SoundEvent>(UnusedMusicSongEvent, name: nameof(UnusedMusicSongEvent));
                s.SerializePadding(2, logIfNotNull: true);

                s.DoAt(settings.RootTable.GetPointer(s.Context, BitmapResourceId), 
                    () => Bitmap = s.SerializeObject<Bitmap>(Bitmap, name: nameof(Bitmap)));
                s.DoAt(settings.RootTable.GetPointer(s.Context, PaletteResourceId), 
                    () => Palette = s.SerializeObject<Palette256>(Palette, name: nameof(Palette)));
            }
            else
            {
                throw new BinarySerializableException(this, $"Unsupported platform {settings.Platform}");
            }
        }
    }
}