namespace BinarySerializer.Ubisoft.GbaEngine
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
            Context.GetRequiredSettings<GbaEngineSettings>().RootTable = GameOffsetTable;

            LoadExeData(Context.GetRequiredFile(exeFileName));
        }
    }
}