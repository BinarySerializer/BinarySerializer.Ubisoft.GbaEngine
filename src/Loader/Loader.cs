using System.IO;
using BinarySerializer.Onyx.Gba.Rayman3;

namespace BinarySerializer.Onyx.Gba
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

        // Rayman 3
        public LevelInfo[] Rayman3_LevelInfo { get; protected set; }

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
            OnyxGbaSettings settings = Context.GetRequiredSettings<OnyxGbaSettings>();

            Font8 = FileFactory.Read<Font>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.Font8, file), name: nameof(Font8));
            Font16 = FileFactory.Read<Font>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.Font16, file), name: nameof(Font16));
            Font32 = FileFactory.Read<Font>(Context, Context.GetRequiredPreDefinedPointer(DefinedPointer.Font32, file), name: nameof(Font32));

            if (settings.EngineVersion is EngineVersion.Rayman3 or EngineVersion.Rayman3_NGage)
            {
                Rayman3_LevelInfo = FileFactory.Read<ObjectArray<LevelInfo>>(
                    Context,
                    Context.GetRequiredPreDefinedPointer(DefinedPointer.Rayman3_LevelInfo, file),
                    (_, obj) => obj.Pre_Length = 65,
                    name: nameof(Rayman3_LevelInfo));
            }
        }
    }
}