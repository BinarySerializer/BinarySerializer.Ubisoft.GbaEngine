using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class GbaLoader : Loader
    {
        public GbaLoader(Context context) : base(context) { }

        public ROMHeader RomHeader { get; protected set; }

        public void LoadFiles(string romFileName, bool cache)
        {
            LoadFile(romFileName, Constants.Address_ROM, cache);
        }

        public void LoadRomHeader(string romFileName)
        {
            RomHeader = FileFactory.Read<ROMHeader>(Context, romFileName);
        }

        public void LoadData(string romFileName)
        {
            BinaryFile romFile = Context.GetRequiredFile(romFileName);

            GameOffsetTable = FileFactory.Read<OffsetTable>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.GameOffsetTable, romFile), name: nameof(GameOffsetTable));
            Context.GetRequiredSettings<GbaEngineSettings>().RootTable = GameOffsetTable;

            LoadExeData(romFile);
        }
    }
}