namespace BinarySerializer.Onyx.Gba
{
    public class NGageLoader : Loader
    {
        public NGageLoader(Context context) : base(context) { }

        public void LoadFiles(string exeFileName, string dataFileName, bool cache)
        {
            LoadFile(exeFileName, 0x0fffff84, cache);
            LoadFile(dataFileName, null, cache);
        }

        public void LoadData(string exeFileName, string dataFileName)
        {
            GameOffsetTable = FileFactory.Read<OffsetTable>(Context, dataFileName);
            Context.GetRequiredSettings<OnyxGbaSettings>().RootTable = GameOffsetTable;

            LoadExeData(Context.GetRequiredFile(exeFileName));
        }
    }
}