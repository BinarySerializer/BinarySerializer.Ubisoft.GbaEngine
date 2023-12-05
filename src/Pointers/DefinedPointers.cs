using System.Collections.Generic;

namespace BinarySerializer.Onyx.Gba
{
    public static class DefinedPointers
    {
        public static Dictionary<DefinedPointer, long> Rayman3_GBA_EU => new()
        {
            [DefinedPointer.GameOffsetTable] = 0x0829beec,
            [DefinedPointer.Font8] = 0x080e9e30,
            [DefinedPointer.Font16] = 0x080ea4c8,
            [DefinedPointer.Font32] = 0x080eb3c4,

            [DefinedPointer.Rayman3_LocalizedTextBanks] = 0x080d4058,
            [DefinedPointer.Rayman3_LevelInfo] = 0x080d4080,
            [DefinedPointer.Rayman3_Act1] = 0x080d6e0c,
            //[DefinedPointer.Rayman3_Act2] = 0x,
            //[DefinedPointer.Rayman3_Act3] = 0x,
            //[DefinedPointer.Rayman3_Act4] = 0x,
            //[DefinedPointer.Rayman3_Act5] = 0x,
            [DefinedPointer.Rayman3_Act6] = 0x080d6f98,
            [DefinedPointer.Rayman3_SinglePakOffsetTable] = 0x087fbea0,
        };

        public static Dictionary<DefinedPointer, long> Rayman3_NGage => new()
        {
            [DefinedPointer.NGage_SongTable] = 0x100f1c3c,

            [DefinedPointer.Rayman3_LevelInfo] = 0x100ede28,
            //[DefinedPointer.Rayman3_Act1] = 0x,
            //[DefinedPointer.Rayman3_Act2] = 0x,
            //[DefinedPointer.Rayman3_Act3] = 0x,
            //[DefinedPointer.Rayman3_Act4] = 0x,
            //[DefinedPointer.Rayman3_Act5] = 0x,
            //[DefinedPointer.Rayman3_Act6] = 0x,
        };
    }
}
