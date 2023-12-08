namespace BinarySerializer.Onyx.Gba.Rayman3
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
        public ActBitmap Bitmap { get; set; }
        public RGB555Color[] Palette { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            OnyxGbaSettings settings = s.GetRequiredSettings<OnyxGbaSettings>();

            if (settings.Platform == Platform.GBA)
            {
                BitmapPointer = s.SerializePointer(BitmapPointer, name: nameof(BitmapPointer));
                TextId = s.Serialize<short>(TextId, name: nameof(TextId));
                s.SerializePadding(2, logIfNotNull: true);
                PalettePointer = s.SerializePointer(PalettePointer, name: nameof(PalettePointer));
                MusicSongEvent = s.Serialize<Rayman3SoundEvent>(MusicSongEvent, name: nameof(MusicSongEvent));
                UnusedMusicSongEvent = s.Serialize<Rayman3SoundEvent>(UnusedMusicSongEvent, name: nameof(UnusedMusicSongEvent));

                s.DoAt(BitmapPointer, () => Bitmap = s.SerializeObject<ActBitmap>(Bitmap, name: nameof(Bitmap)));
                s.DoAt(PalettePointer, () => Palette = s.SerializeObjectArray<RGB555Color>(Palette, 256, name: nameof(Palette)));
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
                    () => Bitmap = s.SerializeObject<ActBitmap>(Bitmap, name: nameof(Bitmap)));
                s.DoAt(settings.RootTable.GetPointer(s.Context, PaletteResourceId), 
                    () => Palette = s.SerializeObjectArray<RGB555Color>(Palette, 256, name: nameof(Palette)));
            }
            else
            {
                throw new BinarySerializableException(this, $"Unsupported platform {settings.Platform}");
            }
        }
    }
}