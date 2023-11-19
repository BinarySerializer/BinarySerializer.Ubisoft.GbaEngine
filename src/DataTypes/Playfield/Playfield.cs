using System;

namespace BinarySerializer.Onyx.Gba
{
    public class Playfield : Resource
    {
        public PlayfieldType Type { get; set; }

        // 2d
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

        private void SerializePlayfield2d(SerializerObject s)
        {
            Idx_TileKit = s.Serialize<byte>(Idx_TileKit, name: nameof(Idx_TileKit));
            Idx_TileMappingTable = s.Serialize<byte>(Idx_TileMappingTable, name: nameof(Idx_TileMappingTable));
            DefaultPalette = s.Serialize<byte>(DefaultPalette, name: nameof(DefaultPalette));
            ClustersCount = s.Serialize<byte>(ClustersCount, name: nameof(ClustersCount));
            LayersCount = s.Serialize<byte>(LayersCount, name: nameof(LayersCount));
            Idx_Clusters = s.SerializeArray<byte>(Idx_Clusters, 4, name: nameof(Idx_Clusters));
            Idx_Layers = s.SerializeArray<byte>(Idx_Layers, 6, name: nameof(Idx_Layers));
        }

        private void SerializePlayfield2dDependencies(SerializerObject s)
        {
            TileKit = SerializeDependency<TileKit>(s, TileKit, Idx_TileKit, name: nameof(TileKit));
            TileMappingTable = SerializeDependency<TileMappingTable>(s, TileMappingTable, Idx_TileMappingTable, name: nameof(TileMappingTable));
            Clusters = SerializeDependencyArray<Cluster>(s, Clusters, Idx_Clusters, ClustersCount, name: nameof(Clusters));
            Layers = SerializeDependencyArray<GameLayer>(s, Layers, Idx_Layers, LayersCount, name: nameof(Layers));
        }

        public override void SerializeResource(SerializerObject s)
        {
            Type = s.Serialize<PlayfieldType>(Type, name: nameof(Type));

            if (Type == PlayfieldType.Playfield2d)
                SerializePlayfield2d(s);
            else if (Type == PlayfieldType.PlayfieldMode7)
                throw new NotImplementedException("Not implemented serializing PlayfieldMode7");
            else if (Type == PlayfieldType.PlayfieldScope)
                throw new NotImplementedException("Not implemented serializing PlayfieldScope");
            else
                throw new BinarySerializableException(this, $"Undefined playfield type {Type}");
        }

        public override void SerializeDependencies(SerializerObject s)
        {
            if (Type == PlayfieldType.Playfield2d)
                SerializePlayfield2dDependencies(s);
            else if (Type == PlayfieldType.PlayfieldMode7)
                throw new NotImplementedException("Not implemented serializing PlayfieldMode7 dependencies");
            else if (Type == PlayfieldType.PlayfieldScope)
                throw new NotImplementedException("Not implemented serializing PlayfieldScope dependencies");
            else
                throw new BinarySerializableException(this, $"Undefined playfield type {Type}");
        }
    }
}