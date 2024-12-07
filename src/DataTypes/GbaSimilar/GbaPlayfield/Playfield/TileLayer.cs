using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class TileLayer : BinarySerializable
    {
        public GameLayer Pre_GameLayer { get; set; }

        public byte LayerId { get; set; }
        public byte ClusterIndex { get; set; }
        public bool HasAlphaBlending { get; set; }
        public FixedPointInt8 AlphaCoeff { get; set; } // For some reason 15 (0,9375) seems to be the max value here, but it should be 16 (1,00)
        public bool IsDynamic { get; set; }
        public bool Is8Bit { get; set; }
        public byte TileKitIndex { get; set; } // ? - unused in Rayman 3
        public byte Byte_0F { get; set; }
        public MapTile[] TileMap { get; set; }

        private static readonly SerializeInto<MapTile> SerializeIntoMapTile_Dynamic4bpp = (s, x) =>
        {
            s.DoBits<ushort>(b =>
            {
                int tileIndex = b.SerializeBits<int>(x.TileIndex, 11, name: nameof(x.TileIndex));
                bool flipX = b.SerializeBits<bool>(x.FlipX, 1, name: nameof(x.FlipX));
                byte paletteIndex = b.SerializeBits<byte>(x.PaletteIndex, 4, name: nameof(x.PaletteIndex));

                x = new MapTile(tileIndex, flipX, false, paletteIndex);
            });

            return x;
        };
        private static readonly SerializeInto<MapTile> SerializeIntoMapTile_Dynamic8bpp = (s, x) =>
        {
            s.DoBits<ushort>(b =>
            {
                int tileIndex = b.SerializeBits<int>(x.TileIndex, 14, name: nameof(x.TileIndex));
                bool flipX = b.SerializeBits<bool>(x.FlipX, 1, name: nameof(x.FlipX));
                bool flipY = b.SerializeBits<bool>(x.FlipY, 1, name: nameof(x.FlipY));

                x = new MapTile(tileIndex, flipX, flipY, 0);
            });

            return x;
        };

        public override void SerializeImpl(SerializerObject s)
        {
            LayerId = s.Serialize<byte>(LayerId, name: nameof(LayerId));
            ClusterIndex = s.Serialize<byte>(ClusterIndex, name: nameof(ClusterIndex));
            HasAlphaBlending = s.Serialize<bool>(HasAlphaBlending, name: nameof(HasAlphaBlending));
            AlphaCoeff = s.SerializeObject<FixedPointInt8>(AlphaCoeff, x => x.Pre_PointPosition = 4, name: nameof(AlphaCoeff));
            IsDynamic = s.Serialize<bool>(IsDynamic, name: nameof(IsDynamic));
            Is8Bit = s.Serialize<bool>(Is8Bit, name: nameof(Is8Bit));
            TileKitIndex = s.Serialize<byte>(TileKitIndex, name: nameof(TileKitIndex));
            Byte_0F = s.Serialize<byte>(Byte_0F, name: nameof(Byte_0F));

            IStreamEncoder encoder = Pre_GameLayer.IsCompressed ? new LZSSEncoder() : null;
            SerializeInto<MapTile> serializeInto;

            if (IsDynamic)
                serializeInto = Is8Bit ? SerializeIntoMapTile_Dynamic8bpp : SerializeIntoMapTile_Dynamic4bpp;
            else
                serializeInto = MapTile.SerializeInto_Regular;

            s.DoEncoded(encoder, () => TileMap = s.SerializeIntoArray<MapTile>(TileMap, Pre_GameLayer.Width * Pre_GameLayer.Height, serializeInto, name: nameof(TileMap)));

            s.Align();
        }
    }
}