using System.Collections.Generic;

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

        public static Dictionary<DefinedPointer, long> Rayman3_GBA_US => new()
        {
            [DefinedPointer.GameOffsetTable] = 0x0829be54,
            [DefinedPointer.Font8] = 0x080e9dd0,
            [DefinedPointer.Font16] = 0x080ea468,
            [DefinedPointer.Font32] = 0x080eb364,

            [DefinedPointer.Rayman3_LocalizedTextBanks] = 0x080d40b4,
            [DefinedPointer.Rayman3_LevelInfo] = 0x080d40dc,
            [DefinedPointer.Rayman3_Act1] = 0x080d6dac,
            [DefinedPointer.Rayman3_Act2] = 0x080d6de8,
            [DefinedPointer.Rayman3_Act3] = 0x080d6e24,
            [DefinedPointer.Rayman3_Act4] = 0x080d6e70,
            [DefinedPointer.Rayman3_Act5] = 0x080d6eac,
            [DefinedPointer.Rayman3_Act6] = 0x080d6f38,
            [DefinedPointer.Rayman3_SinglePakOffsetTable] = 0x087fbe08,
            [DefinedPointer.Rayman3_GameOverBitmap] = 0x0821463c,
            [DefinedPointer.Rayman3_GameOverPalette] = 0x080b39d4,
            [DefinedPointer.Rayman3_GameCubeMenuBitmap] = 0x0820ecfc,
            [DefinedPointer.Rayman3_GameCubeMenuPalette] = 0x080b37d4,
            [DefinedPointer.Rayman3_NewPower1Replay] = 0x080d5288,
            [DefinedPointer.Rayman3_NewPower2Replay] = 0x080d57b4,
            [DefinedPointer.Rayman3_NewPower3Replay] = 0x080d5ae6,
            [DefinedPointer.Rayman3_NewPower4Replay] = 0x080d5f1e,
            [DefinedPointer.Rayman3_NewPower5Replay] = 0x080d6634,
            [DefinedPointer.Rayman3_NewPower6Replay] = 0x080d62b8,
        };

        public static Dictionary<DefinedPointer, long> Rayman3_GBA_10thAnniversary_EU => new()
        {
            [DefinedPointer.GameOffsetTable] = 0x08995e34,
            [DefinedPointer.Font8] = 0x08141a54,
            [DefinedPointer.Font16] = 0x081420ec,
            [DefinedPointer.Font32] = 0x08142fe8,

            [DefinedPointer.Rayman3_LocalizedTextBanks] = 0x0812bc40,
            [DefinedPointer.Rayman3_LevelInfo] = 0x0812bc68,
            [DefinedPointer.Rayman3_Act1] = 0x0812ea0c,
            [DefinedPointer.Rayman3_Act2] = 0x0812ea48,
            [DefinedPointer.Rayman3_Act3] = 0x0812ea84,
            [DefinedPointer.Rayman3_Act4] = 0x0812ead0,
            [DefinedPointer.Rayman3_Act5] = 0x0812eb0c,
            [DefinedPointer.Rayman3_Act6] = 0x0812eb98,
            [DefinedPointer.Rayman3_SinglePakOffsetTable] = 0x08fc9d68,
            [DefinedPointer.Rayman3_GameOverBitmap] = 0x0835e3f4,
            [DefinedPointer.Rayman3_GameOverPalette] = 0x0810afb0,
            [DefinedPointer.Rayman3_GameCubeMenuBitmap] = 0x08358ab4,
            [DefinedPointer.Rayman3_GameCubeMenuPalette] = 0x0810adb0,
            [DefinedPointer.Rayman3_NewPower1Replay] = 0x0812cee8,
            [DefinedPointer.Rayman3_NewPower2Replay] = 0x0812d414,
            [DefinedPointer.Rayman3_NewPower3Replay] = 0x0812d746,
            [DefinedPointer.Rayman3_NewPower4Replay] = 0x0812db7e,
            [DefinedPointer.Rayman3_NewPower5Replay] = 0x0812e294,
            [DefinedPointer.Rayman3_NewPower6Replay] = 0x0812df18,
        };

        public static Dictionary<DefinedPointer, long> Rayman3_GBA_10thAnniversary_US => new()
        {
            [DefinedPointer.GameOffsetTable] = 0x08996180,
            [DefinedPointer.Font8] = 0x081419e4,
            [DefinedPointer.Font16] = 0x0814207c,
            [DefinedPointer.Font32] = 0x08142f78,

            [DefinedPointer.Rayman3_LocalizedTextBanks] = 0x0812bca4,
            [DefinedPointer.Rayman3_LevelInfo] = 0x0812bccc,
            [DefinedPointer.Rayman3_Act1] = 0x0812e99c,
            [DefinedPointer.Rayman3_Act2] = 0x0812e9d8,
            [DefinedPointer.Rayman3_Act3] = 0x0812ea14,
            [DefinedPointer.Rayman3_Act4] = 0x0812ea60,
            [DefinedPointer.Rayman3_Act5] = 0x0812ea9c,
            [DefinedPointer.Rayman3_Act6] = 0x0812eb28,
            [DefinedPointer.Rayman3_SinglePakOffsetTable] = 0x08fca0b4,
            [DefinedPointer.Rayman3_GameOverBitmap] = 0x0835e3d4,
            [DefinedPointer.Rayman3_GameOverPalette] = 0x0810afc4,
            [DefinedPointer.Rayman3_GameCubeMenuBitmap] = 0x08358a94,
            [DefinedPointer.Rayman3_GameCubeMenuPalette] = 0x0810adc4,
            [DefinedPointer.Rayman3_NewPower1Replay] = 0x0812ce78,
            [DefinedPointer.Rayman3_NewPower2Replay] = 0x0812d3a4,
            [DefinedPointer.Rayman3_NewPower3Replay] = 0x0812d6d6,
            [DefinedPointer.Rayman3_NewPower4Replay] = 0x0812db0e,
            [DefinedPointer.Rayman3_NewPower5Replay] = 0x0812e224,
            [DefinedPointer.Rayman3_NewPower6Replay] = 0x0812dea8,
        };

        public static Dictionary<DefinedPointer, long> Rayman3_GBA_WinnieThePoohPack_EU => new()
        {
            [DefinedPointer.GameOffsetTable] = 0x08a9c1b4,
            [DefinedPointer.Font8] = 0x088ea13c,
            [DefinedPointer.Font16] = 0x088ea7d4,
            [DefinedPointer.Font32] = 0x088eb6d0,

            [DefinedPointer.Rayman3_LocalizedTextBanks] = 0x088d4364,
            [DefinedPointer.Rayman3_LevelInfo] = 0x088d438c,
            [DefinedPointer.Rayman3_Act1] = 0x088d7118,
            [DefinedPointer.Rayman3_Act2] = 0x088d7154,
            [DefinedPointer.Rayman3_Act3] = 0x088d7190,
            [DefinedPointer.Rayman3_Act4] = 0x088d71dc,
            [DefinedPointer.Rayman3_Act5] = 0x088d7218,
            [DefinedPointer.Rayman3_Act6] = 0x088d72a4,
            [DefinedPointer.Rayman3_SinglePakOffsetTable] = 0x08ffc168,
            [DefinedPointer.Rayman3_GameOverBitmap] = 0x08a1499c,
            [DefinedPointer.Rayman3_GameOverPalette] = 0x088b3ccc,
            [DefinedPointer.Rayman3_GameCubeMenuBitmap] = 0x08a0f05c,
            [DefinedPointer.Rayman3_GameCubeMenuPalette] = 0x088b3acc,
            [DefinedPointer.Rayman3_NewPower1Replay] = 0x088d55f4,
            [DefinedPointer.Rayman3_NewPower2Replay] = 0x088d5b20,
            [DefinedPointer.Rayman3_NewPower3Replay] = 0x088d5e52,
            [DefinedPointer.Rayman3_NewPower4Replay] = 0x088d628a,
            [DefinedPointer.Rayman3_NewPower5Replay] = 0x088d69a0,
            [DefinedPointer.Rayman3_NewPower6Replay] = 0x088d6624,
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
