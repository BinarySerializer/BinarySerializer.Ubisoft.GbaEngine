using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class PlayfieldMode7 : BinarySerializable
    {
        public byte Idx_TileKit { get; set; }
        public byte Idx_TileMappingTable { get; set; }
        public byte DefaultPalette { get; set; }
        public byte LayersCount { get; set; }
        public byte[] Idx_Layers { get; set; }
        public ushort TextLayerTileMapLength { get; set; }
        public bool IsTextLayerTileMapCompressed { get; set; }
        public byte Byte_0F { get; set; } // Unused in Rayman 3
        public ushort[] TextLayerTileMap { get; set; }

        // Dependencies
        public TileKit TileKit { get; set; }
        public TileMappingTable TileMappingTable { get; set; }
        public GameLayer[] Layers { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Idx_TileKit = s.Serialize<byte>(Idx_TileKit, name: nameof(Idx_TileKit));
            Idx_TileMappingTable = s.Serialize<byte>(Idx_TileMappingTable, name: nameof(Idx_TileMappingTable));
            DefaultPalette = s.Serialize<byte>(DefaultPalette, name: nameof(DefaultPalette));
            LayersCount = s.Serialize<byte>(LayersCount, name: nameof(LayersCount));
            Idx_Layers = s.SerializeArray<byte>(Idx_Layers, 7, name: nameof(Idx_Layers));
            TextLayerTileMapLength = s.Serialize<ushort>(TextLayerTileMapLength, name: nameof(TextLayerTileMapLength));
            IsTextLayerTileMapCompressed = s.Serialize<bool>(IsTextLayerTileMapCompressed, name: nameof(IsTextLayerTileMapCompressed));
            Byte_0F = s.Serialize<byte>(Byte_0F, name: nameof(Byte_0F));

            IStreamEncoder encoder = IsTextLayerTileMapCompressed ? new LZSSEncoder() : null;
            s.DoEncoded(encoder, () => TextLayerTileMap = s.SerializeArray<ushort>(TextLayerTileMap, TextLayerTileMapLength / 2, name: nameof(TextLayerTileMap)));
        }

        public void SerializeDependencies(SerializerObject s, Resource playfieldResource)
        {
            TileKit = playfieldResource.SerializeDependency<TileKit>(s, TileKit, Idx_TileKit, name: nameof(TileKit));
            TileMappingTable = playfieldResource.SerializeDependency<TileMappingTable>(s, TileMappingTable, Idx_TileMappingTable, name: nameof(TileMappingTable));
            Layers = playfieldResource.SerializeDependencyArray<GameLayer>(s, Layers, Idx_Layers, LayersCount, name: nameof(Layers));
        }
    }
}