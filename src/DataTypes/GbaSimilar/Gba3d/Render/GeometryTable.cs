namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class GeometryTable : Resource
    {
        public ushort GeometryObjectCount { get; set; }
        public Pointer<GeometryObject>[] GeometryObjects { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            GeometryObjectCount = s.Serialize<ushort>(GeometryObjectCount, name: nameof(GeometryObjectCount));
            s.SerializePadding(2, logIfNotNull: true);

            GeometryObjects = s.SerializePointerArray<GeometryObject>(GeometryObjects, GeometryObjectCount, size: PointerSize.Pointer16, anchor: Offset, name: nameof(GeometryObjects));
            GeometryObjects.ResolveObject(s);
        }
    }
}