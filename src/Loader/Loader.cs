using System;
using System.IO;
using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class Loader
    {
        public Loader(Context context)
        {
            Context = context;
        }

        public Context Context { get; }
        public BinaryFile RomFile { get; set; }
        public ROMHeader RomHeader { get; set; }

        protected BinaryFile LoadFile(string fileName, long? address, bool cache)
        {
            if (cache)
            {
                byte[] romBuffer;

                using (Stream romStream = Context.FileManager.GetFileReadStream(Context.GetAbsoluteFilePath(fileName)))
                {
                    romBuffer = new byte[romStream.Length];
                    int read = romStream.Read(romBuffer, 0, romBuffer.Length);

                    if (read != romBuffer.Length)
                        throw new EndOfStreamException();
                }

                MemoryStream memoryStream = new(romBuffer);

                if (address != null)
                    return Context.AddFile(new MemoryMappedStreamFile(Context, fileName, address.Value, memoryStream, mode: VirtualFileMode.Maintain));
                else
                    return Context.AddFile(new StreamFile(Context, fileName, memoryStream, allowLocalPointers: true, mode: VirtualFileMode.Maintain));
            }
            else
            {
                if (address != null)
                    return Context.AddFile(new MemoryMappedFile(Context, fileName, address.Value));
                else
                    return Context.AddFile(new LinearFile(Context, fileName));
            }
        }

        public GbaEngineSettings GetSettings() => Context.GetRequiredSettings<GbaEngineSettings>();

        public void LoadRom(string romFileName, bool cache)
        {
            // Load the ROM file
            RomFile = LoadFile(romFileName, Constants.Address_ROM, cache);

            // Read the ROM header
            RomHeader = FileFactory.Read<ROMHeader>(Context, romFileName);
        }

        public void DefinePointers()
        {
            GbaEngineSettings settings = GetSettings();
            Context.AddPreDefinedPointers(DefinedPointers.GetPointers(RomHeader, settings.Platform, settings.Game, true));
        }

        public void DefineResources()
        {
            GbaEngineSettings settings = GetSettings();
            settings.SetDefinedResources(settings.Game switch
            {
                Game.Rayman3 when settings.Platform == Platform.GBA => DefinedResources.Rayman3_GBA,
                Game.Rayman3 when settings.Platform == Platform.NGage => DefinedResources.Rayman3_NGage,
                _ => throw new InvalidOperationException($"Invalid platform {settings.Platform}")
            });
        }

        public virtual void LoadResourceTable()
        {
            GbaEngineSettings settings = GetSettings();
            settings.RootResourceTable = ReadFromExe<OffsetTable>(DefinedPointer.GameOffsetTable, name: "ResourceTable");
        }

        public T ReadFromExe<T>(DefinedPointer definedPointer, Action<T> onPreSerialize = null, string name = null)
            where T : BinarySerializable, new()
        {
            return FileFactory.Read<T>(
                context: Context,
                offset: Context.GetRequiredPreDefinedPointer(definedPointer, RomFile),
                onPreSerialize: onPreSerialize == null ? null : (_, obj) => onPreSerialize(obj),
                name: name ?? definedPointer.ToString());
        }
        
        public T ReadResource<T>(int id, string name = null)
            where T : Resource, new()
        {
            GbaEngineSettings settings = GetSettings();
            return settings.RootResourceTable.ReadResource<T>(Context, id, name: name ?? $"Resource{id}");
        }
        public T ReadResource<T>(Rayman3DefinedResource definedResource, string name = null)
            where T : Resource, new()
        {
            GbaEngineSettings settings = GetSettings();
            return settings.RootResourceTable.ReadResource<T>(Context, definedResource, name: name ?? definedResource.ToString());
        }

        public Stream ReadResourceStream(int id, string name = null)
        {
            RawResource res = ReadResource<RawResource>(id, name);
            return new MemoryStream(res.RawData);
        }
        public Stream LoadResourceStream(Rayman3DefinedResource definedResource, string name = null)
        {
            RawResource res = ReadResource<RawResource>(definedResource, name);
            return new MemoryStream(res.RawData);
        }

        public Scene2D ReadScene(int id)
        {
            GbaEngineSettings settings = GetSettings();
            return settings.RootResourceTable.ReadResource<Scene2D>(Context, id, name: $"Scene{id}");
        }

        public SoundBank ReadSoundBank()
        {
            return ReadResource<SoundBank>(Rayman3DefinedResource.SoundBank, name: nameof(SoundBank));
        }

        public Font ReadFont8()
        {
            GbaEngineSettings settings = GetSettings();
            return settings.Platform switch
            {
                Platform.GBA => ReadFromExe<Font>(DefinedPointer.Font8, name: "Font8"),
                Platform.NGage => ReadResource<Resource<Font>>(Rayman3DefinedResource.Font8, name: "Font8").Value,
                _ => throw new InvalidOperationException($"Invalid platform {settings.Platform}")
            };
        }
        public Font ReadFont16()
        {
            GbaEngineSettings settings = GetSettings();
            return settings.Platform switch
            {
                Platform.GBA => ReadFromExe<Font>(DefinedPointer.Font16, name: "Font16"),
                Platform.NGage => ReadResource<Resource<Font>>(Rayman3DefinedResource.Font16, name: "Font16").Value,
                _ => throw new InvalidOperationException($"Invalid platform {settings.Platform}")
            };
        }
        public Font ReadFont32()
        {
            GbaEngineSettings settings = GetSettings();
            return settings.Platform switch
            {
                Platform.GBA => ReadFromExe<Font>(DefinedPointer.Font32, name: "Font32"),
                Platform.NGage => ReadResource<Resource<Font>>(Rayman3DefinedResource.Font32, name: "Font32").Value,
                _ => throw new InvalidOperationException($"Invalid platform {settings.Platform}")
            };
        }
    }
}