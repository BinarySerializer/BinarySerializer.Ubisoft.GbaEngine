namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class Texture : BinarySerializable
    {
        public ushort Width { get; set; }
        public ushort Height { get; set; }
        public byte[] ImgData { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Width = s.Serialize<ushort>(Width, name: nameof(Width));
            Height = s.Serialize<ushort>(Height, name: nameof(Height));
            ImgData = s.SerializeArray<byte>(ImgData, Width * Height, name: nameof(ImgData));
        }
    }
}