using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Onyx.Gba
{
    public class RotscaleLayerMode7 : BinarySerializable
    {
        public GameLayer Pre_GameLayer { get; set; }

        public byte LayerId { get; set; }
        public bool HasAlphaBlending { get; set; }
        public byte AlphaCoeff { get; set; }
        public byte[] Bytes_0B { get; set; } // Unused in Rayman 3
        public MapTile[] TileMap { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            LayerId = s.Serialize<byte>(LayerId, name: nameof(LayerId));
            HasAlphaBlending = s.Serialize<bool>(HasAlphaBlending, name: nameof(HasAlphaBlending));
            AlphaCoeff = s.Serialize<byte>(AlphaCoeff, name: nameof(AlphaCoeff));
            Bytes_0B = s.SerializeArray<byte>(Bytes_0B, 9, name: nameof(Bytes_0B));

            IStreamEncoder encoder = Pre_GameLayer.IsCompressed ? new LZSSEncoder() : null;
            s.DoEncoded(encoder, () => TileMap = s.SerializeIntoArray<MapTile>(TileMap, Pre_GameLayer.Width * Pre_GameLayer.Height, MapTile.SerializeInto_Affine, name: nameof(TileMap)));
        }
    }
}