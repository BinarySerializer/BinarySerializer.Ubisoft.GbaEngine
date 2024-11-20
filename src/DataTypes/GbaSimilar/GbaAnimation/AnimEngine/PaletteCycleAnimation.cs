namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class PaletteCycleAnimation : Resource
    {
        public byte PaletteIndex { get; set; }
        public byte ColorStartIndex { get; set; }
        public byte ColorEndIndex { get; set; }

        public byte[] Bytes_03 { get; set; } // Appears unused, but has data

        public override void SerializeResource(SerializerObject s)
        {
            PaletteIndex = s.Serialize<byte>(PaletteIndex, name: nameof(PaletteIndex));
            ColorStartIndex = s.Serialize<byte>(ColorStartIndex, name: nameof(ColorStartIndex));
            ColorEndIndex = s.Serialize<byte>(ColorEndIndex, name: nameof(ColorEndIndex));

            // In Rayman 3 this has 1 byte for the blue lums bar and 5 bytes for the fire animation
            Bytes_03 = s.SerializeArray<byte>(Bytes_03, Size - 3, name: nameof(Bytes_03));
        }
    }
}