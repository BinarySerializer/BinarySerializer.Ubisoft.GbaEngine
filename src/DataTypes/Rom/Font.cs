namespace BinarySerializer.Onyx.Gba
{
    public class Font : BinarySerializable
    {
        public const int CharactersCount = 256;

        public ushort CharacterHeight { get; set; }
        public ushort ImgDataSize { get; set; }

        public byte[] CharacterWidths { get; set; }
        public ushort[] CharacterOffsets { get; set; }

        public byte[] ImgData { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            CharacterHeight = s.Serialize<ushort>(CharacterHeight, name: nameof(CharacterHeight));
            ImgDataSize = s.Serialize<ushort>(ImgDataSize, name: nameof(ImgDataSize));

            CharacterWidths = s.SerializeArray<byte>(CharacterWidths, CharactersCount, name: nameof(CharacterWidths));
            CharacterOffsets = s.SerializeArray<ushort>(CharacterOffsets, CharactersCount, name: nameof(CharacterOffsets));

            ImgData = s.SerializeArray<byte>(ImgData, ImgDataSize, name: nameof(ImgData));
        }
    }
}