namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class Playfield2D : BinarySerializable
    {
        public byte Idx_TileKit { get; set; }
        public byte Idx_TileMappingTable { get; set; }
        public byte DefaultPalette { get; set; }
        public byte ClustersCount { get; set; }
        public byte LayersCount { get; set; }
        public byte[] Idx_Clusters { get; set; }
        public byte[] Idx_Layers { get; set; }

        // Dependencies
        public TileKit TileKit { get; set; }
        public TileMappingTable TileMappingTable { get; set; }
        public Cluster[] Clusters { get; set; }
        public GameLayer[] Layers { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Idx_TileKit = s.Serialize<byte>(Idx_TileKit, name: nameof(Idx_TileKit));
            Idx_TileMappingTable = s.Serialize<byte>(Idx_TileMappingTable, name: nameof(Idx_TileMappingTable));
            DefaultPalette = s.Serialize<byte>(DefaultPalette, name: nameof(DefaultPalette));
            ClustersCount = s.Serialize<byte>(ClustersCount, name: nameof(ClustersCount));
            LayersCount = s.Serialize<byte>(LayersCount, name: nameof(LayersCount));
            Idx_Clusters = s.SerializeArray<byte>(Idx_Clusters, 4, name: nameof(Idx_Clusters));
            Idx_Layers = s.SerializeArray<byte>(Idx_Layers, 6, name: nameof(Idx_Layers));
        }

        public void SerializeDependencies(SerializerObject s, Resource playfieldResource)
        {
            TileKit = playfieldResource.SerializeDependency<TileKit>(s, TileKit, Idx_TileKit, name: nameof(TileKit));
            TileMappingTable = playfieldResource.SerializeDependency<TileMappingTable>(s, TileMappingTable, Idx_TileMappingTable, name: nameof(TileMappingTable));
            Clusters = playfieldResource.SerializeDependencyArray<Cluster>(s, Clusters, Idx_Clusters, ClustersCount, name: nameof(Clusters));
            Layers = playfieldResource.SerializeDependencyArray<GameLayer>(s, Layers, Idx_Layers, LayersCount, name: nameof(Layers));
        }
    }
}