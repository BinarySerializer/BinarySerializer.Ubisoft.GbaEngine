using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class SpriteTable : Resource
    {
        public ushort Length { get; set; }
        public bool IsCompressed { get; set; }
        public byte[] Data { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            Length = s.Serialize<ushort>(Length, name: nameof(Length));
            IsCompressed = s.Serialize<bool>(IsCompressed, name: nameof(IsCompressed));
            s.SerializePadding(1, logIfNotNull: true);

            IStreamEncoder encoder = IsCompressed ? new LZSSEncoder() : null;
            s.DoEncoded(encoder, () => Data = s.SerializeArray<byte>(Data, Length * 0x20, name: nameof(Data)));
            s.Align();
        }
    }
}