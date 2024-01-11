using System;
using System.IO;
using BinarySerializer.Ubisoft.GbaEngine.Rayman3;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public abstract class Loader
    {
        protected Loader(Context context)
        {
            Context = context;
        }

        public Context Context { get; }

        // Global
        public OffsetTable GameOffsetTable { get; protected set; }
        public Font Font8 { get; set; }
        public Font Font16 { get; set; }
        public Font Font32 { get; set; }

        // N-Gage
        public NGageSoundEvent[] NGage_SoundEvents { get; set; }

        // Rayman 3
        public LocalizedTextBanks Rayman3_LocalizedTextBanks { get; protected set; }
        public LevelInfo[] Rayman3_LevelInfo { get; protected set; }
        public Act Rayman3_NGageSplashScreens { get; protected set; }
        public Act Rayman3_Act1 { get; protected set; }
        public Act Rayman3_Act2 { get; protected set; }
        public Act Rayman3_Act3 { get; protected set; }
        public Act Rayman3_Act4 { get; protected set; }
        public Act Rayman3_Act5 { get; protected set; }
        public Act Rayman3_Act6 { get; protected set; }

        protected void LoadFile(string fileName, long? address, bool cache)
        {
            if (cache)
            {
                byte[] romBuffer;

                using (Stream romStream = Context.FileManager.GetFileReadStream(fileName))
                {
                    romBuffer = new byte[romStream.Length];
                    int read = romStream.Read(romBuffer, 0, romBuffer.Length);

                    if (read != romBuffer.Length)
                        throw new EndOfStreamException();
                }

                if (address != null)
                    Context.AddFile(new MemoryMappedStreamFile(Context, fileName, address.Value, new MemoryStream(romBuffer), mode: VirtualFileMode.Maintain));
                else    
                    Context.AddFile(new StreamFile(Context, fileName, new MemoryStream(romBuffer), mode: VirtualFileMode.Maintain));
            }
            else
            {
                if (address != null)
                    Context.AddFile(new MemoryMappedFile(Context, fileName, address.Value));
                else
                    Context.AddFile(new LinearFile(Context, fileName));
            }
        }

        protected void LoadExeData(BinaryFile file)
        {
            GbaEngineSettings settings = Context.GetRequiredSettings<GbaEngineSettings>();

            if (settings.Platform == Platform.GBA)
            {
                Font8 = FileFactory.Read<Font>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.Font8, file), name: nameof(Font8));
                Font16 = FileFactory.Read<Font>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.Font16, file), name: nameof(Font16));
                Font32 = FileFactory.Read<Font>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.Font32, file), name: nameof(Font32));
            }
            else if (settings.Platform == Platform.NGage)
            {
                Font8 = GameOffsetTable.ReadResource<Resource<Font>>(Context, GameResource.Font8, name: nameof(Font8)).Value;
                Font16 = GameOffsetTable.ReadResource<Resource<Font>>(Context, GameResource.Font16, name: nameof(Font16)).Value;
                Font32 = GameOffsetTable.ReadResource<Resource<Font>>(Context, GameResource.Font32, name: nameof(Font32)).Value;

                NGage_SoundEvents = FileFactory.Read<ObjectArray<NGageSoundEvent>>(
                    Context, 
                    Context.GetRequiredPreDefinedPointer(DefinedPointer.NGage_SongTable, file), 
                    onPreSerialize: (_, x) => x.Pre_Length = 515, 
                    name: nameof(NGage_SoundEvents));
            }

            if (settings.Game == Game.Rayman3)
            {
                Rayman3_LocalizedTextBanks = FileFactory.Read<LocalizedTextBanks>(
                    Context,
                    Context.GetRequiredPreDefinedPointer(DefinedPointer.Rayman3_LocalizedTextBanks, file),
                    (_, obj) =>
                    {
                        obj.Pre_LanguagesCount = settings.Platform switch
                        {
                            Platform.GBA => 10,
                            Platform.NGage => 6,
                            _ => 0,
                        };
                        obj.Pre_TextBanksCounts = settings.Platform switch
                        {
                            Platform.GBA =>   new[] { 17, 6, 9, 2, 2, 3, 2, 7, 35, 13, 1, 18 },
                            Platform.NGage => new[] { 17, 6, 9, 2, 2, 3, 2, 7, 35, 13, 1, 40 },
                            _ => Array.Empty<int>(),
                        };
                    },
                    name: nameof(Rayman3_LocalizedTextBanks));

                Rayman3_LevelInfo = FileFactory.Read<ObjectArray<LevelInfo>>(
                    Context,
                    Context.GetRequiredPreDefinedPointer(DefinedPointer.Rayman3_LevelInfo, file),
                    (_, obj) => obj.Pre_Length = settings.Platform switch
                    {
                        Platform.GBA => 65,
                        Platform.NGage => 71,
                        _ => 0,
                    },
                    name: nameof(Rayman3_LevelInfo));

                if (settings.Platform == Platform.NGage)
                    Rayman3_NGageSplashScreens = FileFactory.Read<Act>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.Rayman3_NGageSplashScreens, file), name: nameof(Rayman3_NGageSplashScreens));

                Rayman3_Act1 = FileFactory.Read<Act>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.Rayman3_Act1, file), name: nameof(Rayman3_Act1));
                Rayman3_Act2 = FileFactory.Read<Act>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.Rayman3_Act2, file), name: nameof(Rayman3_Act2));
                Rayman3_Act3 = FileFactory.Read<Act>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.Rayman3_Act3, file), name: nameof(Rayman3_Act3));
                Rayman3_Act4 = FileFactory.Read<Act>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.Rayman3_Act4, file), name: nameof(Rayman3_Act4));
                Rayman3_Act5 = FileFactory.Read<Act>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.Rayman3_Act5, file), name: nameof(Rayman3_Act5));
                Rayman3_Act6 = FileFactory.Read<Act>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.Rayman3_Act6, file), name: nameof(Rayman3_Act6));
            }
        }
    }
}