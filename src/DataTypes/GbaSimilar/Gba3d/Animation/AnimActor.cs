namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class AnimActor : Resource
    {
        public byte Idx_GeometryTable { get; set; }
        public byte Byte_01 { get; set; }
        public byte Byte_02 { get; set; }
        public byte TransformsCount { get; set; }
        public byte GeometryObjectsCount { get; set; }
        public byte AnimationsCount { get; set; }
        public byte[] Idx_Animations { get; set; }

        // Dependencies
        public GeometryTable GeometryTable { get; set; }
        public Animation3D[] Animations { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            Idx_GeometryTable = s.Serialize<byte>(Idx_GeometryTable, name: nameof(Idx_GeometryTable));
            Byte_01 = s.Serialize<byte>(Byte_01, name: nameof(Byte_01));
            Byte_02 = s.Serialize<byte>(Byte_02, name: nameof(Byte_02));
            TransformsCount = s.Serialize<byte>(TransformsCount, name: nameof(TransformsCount));
            GeometryObjectsCount = s.Serialize<byte>(GeometryObjectsCount, name: nameof(GeometryObjectsCount));
            AnimationsCount = s.Serialize<byte>(AnimationsCount, name: nameof(AnimationsCount));
            Idx_Animations = s.SerializeArray<byte>(Idx_Animations, AnimationsCount, name: nameof(Idx_Animations));
        }

        public override void SerializeDependencies(SerializerObject s)
        {
            GeometryTable = SerializeDependency<GeometryTable>(s, GeometryTable, Idx_GeometryTable, name: nameof(GeometryTable));
            Animations = SerializeDependencyArray<Animation3D>(s, Animations, Idx_Animations, AnimationsCount, onPreSerialize: x => x.Pre_TransformsCount = TransformsCount, name: nameof(Animations));
        }
    }
}