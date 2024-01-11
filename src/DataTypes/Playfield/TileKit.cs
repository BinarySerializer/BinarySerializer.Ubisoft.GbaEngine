namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class TileKit : Resource
    {
        public ushort TilesCount4bpp { get; set; }
        public ushort TilesCount8bpp { get; set; }
        public byte Byte_04 { get; set; } // Unused in Rayman 3
        public byte Idx_AnimatedTileKit { get; set; }
        public byte PalettesCount { get; set; }
        public byte Byte_07 { get; set; } // Unused in Rayman 3

        public byte[] Idx_PaletteIndexes { get; set; }

        public byte[] Tiles4bpp { get; set; }
        public byte[] Tiles8bpp { get; set; }

        // Dependencies
        public TilePalette[] Palettes { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            TilesCount4bpp = s.Serialize<ushort>(TilesCount4bpp, name: nameof(TilesCount4bpp));
            TilesCount8bpp = s.Serialize<ushort>(TilesCount8bpp, name: nameof(TilesCount8bpp));
            Byte_04 = s.Serialize<byte>(Byte_04, name: nameof(Byte_04));
            Idx_AnimatedTileKit = s.Serialize<byte>(Idx_AnimatedTileKit, name: nameof(Idx_AnimatedTileKit));
            PalettesCount = s.Serialize<byte>(PalettesCount, name: nameof(PalettesCount));
            Byte_07 = s.Serialize<byte>(Byte_07, name: nameof(Byte_07));
            
            Idx_PaletteIndexes = s.SerializeArray<byte>(Idx_PaletteIndexes, PalettesCount, name: nameof(Idx_PaletteIndexes));

            Tiles4bpp = s.SerializeArray<byte>(Tiles4bpp, TilesCount4bpp * 0x20, name: nameof(Tiles4bpp));
            Tiles8bpp = s.SerializeArray<byte>(Tiles8bpp, TilesCount8bpp * 0x40, name: nameof(Tiles8bpp));
        }

        public override void SerializeDependencies(SerializerObject s)
        {
            Palettes = SerializeDependencyArray<TilePalette>(s, Palettes, Idx_PaletteIndexes, name: nameof(Palettes));
            // TODO: Serialize animated tile kit
        }
    }
}