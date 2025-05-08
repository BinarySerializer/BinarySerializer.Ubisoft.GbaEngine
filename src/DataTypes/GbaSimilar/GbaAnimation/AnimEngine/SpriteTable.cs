using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class SpriteTable : Resource
    {
        public bool Pre_IsDynamic { get; set; }

        public ushort Length { get; set; }
        public bool IsCompressed { get; set; }
        public byte[] UnusedBytes { get; set; }
        public byte[] Data { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            GbaEngineSettings settings = s.GetRequiredSettings<GbaEngineSettings>();

            Length = s.Serialize<ushort>(Length, name: nameof(Length));

            if (settings.Game is Game.Rayman3_20020118_DemoRLE)
            {
                IsCompressed = false;
                UnusedBytes = s.SerializeArray<byte>(UnusedBytes, 2, name: nameof(UnusedBytes));
            }
            else if (settings.Game is Game.Rayman3_20020301_PreAlpha or Game.Rayman3_20020418_NintendoE3Approval or Game.Rayman3_20020513_E3GameCube)
            {
                IsCompressed = !Pre_IsDynamic;
                UnusedBytes = s.SerializeArray<byte>(UnusedBytes, 2, name: nameof(UnusedBytes));
            }
            else
            {
                IsCompressed = s.Serialize<bool>(IsCompressed, name: nameof(IsCompressed));
                UnusedBytes = s.SerializeArray<byte>(UnusedBytes, 1, name: nameof(UnusedBytes));
            }

            IStreamEncoder encoder = IsCompressed ? new LZSSEncoder() : null;
            s.DoEncoded(encoder, () => Data = s.SerializeArray<byte>(Data, Length * 0x20, name: nameof(Data)));
            s.Align();
        }
    }
}