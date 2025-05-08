using System;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class TileKit : Resource
    {
        public bool Pre_IsMode7 { get; set; }

        public ushort TilesCount4bpp { get; set; }
        public ushort TilesCount8bpp { get; set; }
        public byte Byte_04 { get; set; } // Unused in Rayman 3
        public byte Idx_AnimatedTileKit { get; set; }
        public byte PalettesCount { get; set; }
        public byte Byte_07 { get; set; } // Unused in Rayman 3

        public byte[] Idx_Palettes { get; set; }

        public byte[] Tiles4bpp { get; set; }
        public byte[] Tiles8bpp { get; set; }

        // Dependencies
        public TilePalette[] Palettes { get; set; }
        public AnimatedTileKitManager AnimatedTileKitManager { get; set; }
        public AnimatedTileKit[] AnimatedTileKits { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            GbaEngineSettings settings = s.GetRequiredSettings<GbaEngineSettings>();

            if (settings.Game == Game.Rayman3_20020118_DemoRLE)
            {
                TilesCount4bpp = 0;
                TilesCount8bpp = s.Serialize<ushort>(TilesCount8bpp, name: nameof(TilesCount8bpp));
                PalettesCount = 1;
                Idx_Palettes = s.SerializeArray<byte>(Idx_Palettes, 1, name: nameof(Idx_Palettes));
                Idx_AnimatedTileKit = s.Serialize<byte>(Idx_AnimatedTileKit, name: nameof(Idx_AnimatedTileKit));

                Tiles4bpp = Array.Empty<byte>();
                Tiles8bpp = s.SerializeArray<byte>(Tiles8bpp, TilesCount8bpp * 0x40, name: nameof(Tiles8bpp));
            }
            else if (settings.Game == Game.Rayman3_20020301_PreAlpha || (settings.Game == Game.Rayman3_20020418_NintendoE3Approval && Pre_IsMode7))
            {
                TilesCount4bpp = s.Serialize<ushort>(TilesCount4bpp, name: nameof(TilesCount4bpp));
                TilesCount8bpp = s.Serialize<ushort>(TilesCount8bpp, name: nameof(TilesCount8bpp));
                Byte_04 = s.Serialize<byte>(Byte_04, name: nameof(Byte_04));
                PalettesCount = 1;
                Idx_Palettes = s.SerializeArray<byte>(Idx_Palettes, 1, name: nameof(Idx_Palettes));
                Idx_AnimatedTileKit = s.Serialize<byte>(Idx_AnimatedTileKit, name: nameof(Idx_AnimatedTileKit));
                Byte_07 = s.Serialize<byte>(Byte_07, name: nameof(Byte_07));

                Tiles4bpp = s.SerializeArray<byte>(Tiles4bpp, TilesCount4bpp * 0x20, name: nameof(Tiles4bpp));
                Tiles8bpp = s.SerializeArray<byte>(Tiles8bpp, TilesCount8bpp * 0x40, name: nameof(Tiles8bpp));
            }
            else
            {
                TilesCount4bpp = s.Serialize<ushort>(TilesCount4bpp, name: nameof(TilesCount4bpp));
                TilesCount8bpp = s.Serialize<ushort>(TilesCount8bpp, name: nameof(TilesCount8bpp));
                Byte_04 = s.Serialize<byte>(Byte_04, name: nameof(Byte_04));
                Idx_AnimatedTileKit = s.Serialize<byte>(Idx_AnimatedTileKit, name: nameof(Idx_AnimatedTileKit));
                PalettesCount = s.Serialize<byte>(PalettesCount, name: nameof(PalettesCount));
                Byte_07 = s.Serialize<byte>(Byte_07, name: nameof(Byte_07));

                Idx_Palettes = s.SerializeArray<byte>(Idx_Palettes, PalettesCount, name: nameof(Idx_Palettes));

                Tiles4bpp = s.SerializeArray<byte>(Tiles4bpp, TilesCount4bpp * 0x20, name: nameof(Tiles4bpp));
                Tiles8bpp = s.SerializeArray<byte>(Tiles8bpp, TilesCount8bpp * 0x40, name: nameof(Tiles8bpp));
            }
        }

        public override void SerializeDependencies(SerializerObject s)
        {
            Palettes = SerializeDependencyArray<TilePalette>(s, Palettes, Idx_Palettes, name: nameof(Palettes));

            if (Idx_AnimatedTileKit != 0xFF)
            {
                AnimatedTileKitManager = SerializeDependency<AnimatedTileKitManager>(s, AnimatedTileKitManager, Idx_AnimatedTileKit, name: nameof(AnimatedTileKitManager));
                AnimatedTileKits = SerializeDependencyArray<AnimatedTileKit>(s, AnimatedTileKits, AnimatedTileKitManager.Idx_AnimatedTileKits, name: nameof(AnimatedTileKits));
            }
        }
    }
}