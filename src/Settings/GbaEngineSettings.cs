namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class GbaEngineSettings
    {
        public Game Game { get; set; }
        public Platform Platform { get; set; }
        public OffsetTable RootTable { get; set; }
    }
}