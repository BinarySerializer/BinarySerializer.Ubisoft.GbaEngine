using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Onyx.Gba
{
    public class GameLayer : Resource
    {
        public GameLayerType Type { get; set; }
        public bool IsCompressed { get; set; }
        public byte Byte_02 { get; set; } // Unused in Rayman 3
        public byte Byte_03 { get; set; } // Unused in Rayman 3
        public ushort Width { get; set; }
        public ushort Height { get; set; }

        // Tile
        public byte LayerId { get; set; }
        public byte ClusterIndex { get; set; }
        public bool HasAlphaBlending { get; set; }
        public byte AlphaCoeff { get; set; }
        public bool IsDynamic { get; set; }
        public bool Is8Bit { get; set; }
        public byte TileKitIndex { get; set; } // ? - unused in Rayman 3
        public byte Byte_0F { get; set; }
        public MapTile[] TileMap { get; set; }

        // Collision
        public byte[] CollisionMap { get; set; }

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

        private void SerializeTileLayer(SerializerObject s)
        {
            LayerId = s.Serialize<byte>(LayerId, name: nameof(LayerId));
            ClusterIndex = s.Serialize<byte>(ClusterIndex, name: nameof(ClusterIndex));
            HasAlphaBlending = s.Serialize<bool>(HasAlphaBlending, name: nameof(HasAlphaBlending));
            AlphaCoeff = s.Serialize<byte>(AlphaCoeff, name: nameof(AlphaCoeff));
            IsDynamic = s.Serialize<bool>(IsDynamic, name: nameof(IsDynamic));
            Is8Bit = s.Serialize<bool>(Is8Bit, name: nameof(Is8Bit));
            TileKitIndex = s.Serialize<byte>(TileKitIndex, name: nameof(TileKitIndex));
            Byte_0F = s.Serialize<byte>(Byte_0F, name: nameof(Byte_0F));

            IStreamEncoder encoder = IsCompressed ? new LZSSEncoder() : null;
            SerializeInto<MapTile> serializeInto;

            if (IsDynamic)
                serializeInto = Is8Bit ? SerializeIntoMapTile_Dynamic8bpp : SerializeIntoMapTile_Dynamic4bpp;
            else
                serializeInto = MapTile.SerializeInto_Regular;

            s.DoEncoded(encoder, () => TileMap = s.SerializeIntoArray<MapTile>(TileMap, Width * Height, serializeInto, name: nameof(TileMap)));
        }

        private void SerializeTileCollisionLayer(SerializerObject s)
        {
            IStreamEncoder encoder = IsCompressed ? new LZSSEncoder() : null;
            s.DoEncoded(encoder, () => CollisionMap = s.SerializeArray<byte>(CollisionMap, Width * Height, name: nameof(CollisionMap)));
        }

        public override void SerializeResource(SerializerObject s)
        {
            Type = s.Serialize<GameLayerType>(Type, name: nameof(Type));
            IsCompressed = s.Serialize<bool>(IsCompressed, name: nameof(IsCompressed));
            Byte_02 = s.Serialize<byte>(Byte_02, name: nameof(Byte_02));
            Byte_03 = s.Serialize<byte>(Byte_03, name: nameof(Byte_03));
            Width = s.Serialize<ushort>(Width, name: nameof(Width));
            Height = s.Serialize<ushort>(Height, name: nameof(Height));

            if (Type == GameLayerType.TileLayer)
                SerializeTileLayer(s);
            else if (Type == GameLayerType.TileCollisionLayer)
                SerializeTileCollisionLayer(s);
            else
                throw new BinarySerializableException(this, $"Undefined game layer type {Type}");
        }
    }
}