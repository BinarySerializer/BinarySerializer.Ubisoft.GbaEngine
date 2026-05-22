using System;
using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Ubisoft.GbaEngine.Rayman3
{
    public class Rayman3Loader : Loader
    {
        public Rayman3Loader(Context context) : base(context) { }

        public BinaryFile NGageDataFile { get; set; }

        public void LoadNGageRom(string exeFileName, string dataFileName, bool cache)
        {
            // Load the exe and data files
            RomFile = LoadFile(exeFileName, 0x0fffff84, cache);
            NGageDataFile = LoadFile(dataFileName, null, cache);
        }

        public override void LoadResourceTable()
        {
            GbaEngineSettings settings = GetSettings();
            if (settings.Platform == Platform.GBA)
                base.LoadResourceTable();
            else if (settings.Platform == Platform.NGage)
                settings.RootResourceTable = FileFactory.Read<OffsetTable>(Context, NGageDataFile.FilePath);
            else
                throw new InvalidOperationException($"Invalid Rayman 3 platform {settings.Platform}");
        }

        public NGageSoundEvent[] ReadNGageSoundEvents()
        {
            GbaEngineSettings settings = GetSettings();
            return settings.Platform switch
            {
                Platform.NGage => ReadFromExe<ObjectArray<NGageSoundEvent>>(DefinedPointer.NGage_SoundEvents, x => x.Pre_Length = 515, name: "SoundEvents"),
                _ => throw new InvalidOperationException($"Invalid Rayman 3 platform {settings.Platform}")
            };
        }

        public LocalizedTextBanks ReadTextBanks()
        {
            GbaEngineSettings settings = GetSettings();
            return settings.Platform switch
            {
                Platform.GBA => ReadFromExe<LocalizedTextBanks>(DefinedPointer.Rayman3_TextBanks, x =>
                {
                    x.Pre_LanguagesCount = 10;
                    x.Pre_TextBanksCounts = new[] { 17, 6, 9, 2, 2, 3, 2, 7, 35, 13, 1, 18 };
                }, name: "TextBanks"),
                Platform.NGage => ReadFromExe<LocalizedTextBanks>(DefinedPointer.Rayman3_TextBanks, x =>
                {
                    x.Pre_LanguagesCount = 6;
                    x.Pre_TextBanksCounts = new[] { 17, 6, 9, 2, 2, 3, 2, 7, 35, 13, 1, 40 };
                }, name: "TextBanks"),
                _ => throw new InvalidOperationException($"Invalid Rayman 3 platform {settings.Platform}")
            };
        }

        public LevelInfo[] ReadLevelInfo()
        {
            GbaEngineSettings settings = GetSettings();
            return settings.Platform switch
            {
                Platform.GBA => ReadFromExe<ObjectArray<LevelInfo>>(DefinedPointer.Rayman3_LevelInfo, x => x.Pre_Length = 65, name: "LevelInfo"),
                Platform.NGage => ReadFromExe<ObjectArray<LevelInfo>>(DefinedPointer.Rayman3_LevelInfo, x => x.Pre_Length = 71, name: "LevelInfo"),
                _ => throw new InvalidOperationException($"Invalid Rayman 3 platform {settings.Platform}")
            };
        }

        public Act ReadStoryAct(int id)
        {
            DefinedPointer definedPointer = id switch
            {
                1 => DefinedPointer.Rayman3_Act1,
                2 => DefinedPointer.Rayman3_Act2,
                3 => DefinedPointer.Rayman3_Act3,
                4 => DefinedPointer.Rayman3_Act4,
                5 => DefinedPointer.Rayman3_Act5,
                6 => DefinedPointer.Rayman3_Act6,
                _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
            };
            return ReadFromExe<Act>(definedPointer, name: $"StoryAct{id}");
        }
        public Act ReadNGageSplashScreens()
        {
            GbaEngineSettings settings = GetSettings();
            return settings.Platform switch
            {
                Platform.NGage => ReadFromExe<Act>(DefinedPointer.Rayman3_NGageSplashScreens, name: "NGageSplashScreens"),
                _ => throw new InvalidOperationException($"Invalid Rayman 3 platform {settings.Platform}")
            };
        }

        public Bitmap ReadGameOverBitmap()
        {
            GbaEngineSettings settings = GetSettings();
            return settings.Platform switch
            {
                Platform.GBA => ReadFromExe<Bitmap>(DefinedPointer.Rayman3_GameOverBitmap, name: "GameOverBitmap"),
                Platform.NGage => ReadResource<Resource<Bitmap>>(Rayman3DefinedResource.GameOverBitmap, name: "GameOverBitmap").Value,
                _ => throw new InvalidOperationException($"Invalid Rayman 3 platform {settings.Platform}")
            };
        }
        public Palette256 ReadGameOverPalette()
        {
            GbaEngineSettings settings = GetSettings();
            return settings.Platform switch
            {
                Platform.GBA => ReadFromExe<Palette256>(DefinedPointer.Rayman3_GameOverPalette, name: "GameOverPalette"),
                Platform.NGage => ReadResource<Resource<Palette256>>(Rayman3DefinedResource.GameOverPalette, name: "GameOverPalette").Value,
                _ => throw new InvalidOperationException($"Invalid Rayman 3 platform {settings.Platform}")
            };
        }

        public Bitmap ReadGameCubeMenuBitmap()
        {
            GbaEngineSettings settings = GetSettings();
            return settings.Platform switch
            {
                Platform.GBA => ReadFromExe<Bitmap>(DefinedPointer.Rayman3_GameCubeMenuBitmap, name: "GameCubeMenuBitmap"),
                _ => throw new InvalidOperationException($"Invalid Rayman 3 platform {settings.Platform}")
            };
        }
        public Palette256 ReadGameCubeMenuPalette()
        {
            GbaEngineSettings settings = GetSettings();
            return settings.Platform switch
            {
                Platform.GBA => ReadFromExe<Palette256>(DefinedPointer.Rayman3_GameCubeMenuPalette, name: "GameCubeMenuPalette"),
                _ => throw new InvalidOperationException($"Invalid Rayman 3 platform {settings.Platform}")
            };
        }

        public JoyPadReplayData ReadNewPowerReplayData(int id)
        {
            DefinedPointer definedPointer = id switch
            {
                1 => DefinedPointer.Rayman3_NewPower1Replay,
                2 => DefinedPointer.Rayman3_NewPower2Replay,
                3 => DefinedPointer.Rayman3_NewPower3Replay,
                4 => DefinedPointer.Rayman3_NewPower4Replay,
                5 => DefinedPointer.Rayman3_NewPower5Replay,
                6 => DefinedPointer.Rayman3_NewPower6Replay,
                _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
            };
            return ReadFromExe<JoyPadReplayData>(definedPointer, name: $"NewPowerReplayData{id}");
        }
    }
}