﻿using System.Collections.Generic;

namespace BinarySerializer.Ubisoft.GbaEngine
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
            [DefinedPointer.Rayman3_Act2] = 0x080d6e48,
            [DefinedPointer.Rayman3_Act3] = 0x080d6e84,
            [DefinedPointer.Rayman3_Act4] = 0x080d6ed0,
            [DefinedPointer.Rayman3_Act5] = 0x080d6f0c,
            [DefinedPointer.Rayman3_Act6] = 0x080d6f98,
            [DefinedPointer.Rayman3_SinglePakOffsetTable] = 0x087fbea0,
            [DefinedPointer.Rayman3_GameOverBitmap] = 0x082146d4,
            [DefinedPointer.Rayman3_GameOverPalette] = 0x080b39c0,
            [DefinedPointer.Rayman3_GameCubeMenuBitmap] = 0x0820ed94,
            [DefinedPointer.Rayman3_GameCubeMenuPalette] = 0x080b37c0,
            [DefinedPointer.Rayman3_NewPower1Replay] = 0x080d52e8,
            [DefinedPointer.Rayman3_NewPower2Replay] = 0x080d5814,
            [DefinedPointer.Rayman3_NewPower3Replay] = 0x080d5b46,
            [DefinedPointer.Rayman3_NewPower4Replay] = 0x080d5f7e,
            [DefinedPointer.Rayman3_NewPower5Replay] = 0x080d6694,
            [DefinedPointer.Rayman3_NewPower6Replay] = 0x080d6318,
        };

        public static Dictionary<DefinedPointer, long> Rayman3_NGage => new()
        {
            [DefinedPointer.NGage_SongTable] = 0x100f1c3c,

            [DefinedPointer.Rayman3_LocalizedTextBanks] = 0x100d1cec,
            [DefinedPointer.Rayman3_LevelInfo] = 0x100ede28,
            [DefinedPointer.Rayman3_NGageSplashScreens] = 0x100f2e78,
            [DefinedPointer.Rayman3_Act1] = 0x100f2c98,
            [DefinedPointer.Rayman3_Act2] = 0x100f2d20,
            [DefinedPointer.Rayman3_Act3] = 0x100f2d54,
            [DefinedPointer.Rayman3_Act4] = 0x100f2d88,
            [DefinedPointer.Rayman3_Act5] = 0x100f2dc8,
            [DefinedPointer.Rayman3_Act6] = 0x100f2dfc,
            [DefinedPointer.Rayman3_NewPower1Replay] = 0x100cfa9c,
            [DefinedPointer.Rayman3_NewPower2Replay] = 0x100cffc8,
            [DefinedPointer.Rayman3_NewPower3Replay] = 0x100d02fa,
            [DefinedPointer.Rayman3_NewPower4Replay] = 0x100d0732,
            [DefinedPointer.Rayman3_NewPower5Replay] = 0x100d0e48,
            [DefinedPointer.Rayman3_NewPower6Replay] = 0x100d0acc,
        };
    }
}
