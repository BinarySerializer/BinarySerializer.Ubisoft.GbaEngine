using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Onyx.Gba.Rayman3
{
    public class ActBitmap : BinarySerializable
    {
        public byte[] ImgData { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            s.DoEncoded(new LZSSEncoder(), () => ImgData = s.SerializeArray<byte>(ImgData, s.CurrentLength, name: nameof(ImgData)));
        }
    }
}