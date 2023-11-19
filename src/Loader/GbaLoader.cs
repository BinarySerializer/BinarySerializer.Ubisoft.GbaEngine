using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Onyx.Gba
{
    public class GbaLoader : Loader
    {
        public GbaLoader(Context context) : base(context) { }

        public void LoadFiles(string romFileName, bool cache)
        {
            LoadFile(romFileName, Constants.Address_ROM, cache);
        }

        public void LoadData(string romFileName)
        {
            BinaryFile romFile = Context.GetRequiredFile(romFileName);

            GameOffsetTable = FileFactory.Read<OffsetTable>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.GameOffsetTable, romFile), name: nameof(GameOffsetTable));
            Context.GetRequiredSettings<OnyxGbaSettings>().RootTable = GameOffsetTable;

            LoadExeData(romFile);
        }
    }
}