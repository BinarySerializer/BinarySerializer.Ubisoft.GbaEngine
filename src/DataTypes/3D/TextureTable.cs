namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class TextureTable : Resource
    {
        public ushort TexturesCount { get; set; }
        public Pointer<Texture>[] Textures { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            TexturesCount = s.Serialize<ushort>(TexturesCount, name: nameof(TexturesCount));
            s.SerializePadding(2, logIfNotNull: true);

            Textures = s.SerializePointerArray<Texture>(Textures, TexturesCount, size: PointerSize.Pointer16, anchor: Offset, name: nameof(Textures));
            Textures.ResolveObject(s);

            // NOTE: For some reason for Rayman 3 the textures are all duplicated in the file, but the offsets only point to the first instances of them
        }
    }
}