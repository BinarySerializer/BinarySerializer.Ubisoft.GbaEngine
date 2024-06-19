using System;
using System.Linq;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class GeometryObject : BinarySerializable
    {
        public GeometryObjectFlags Flags { get; set; }
        public byte Byte_01 { get; set; }
        public ushort Ushort_02 { get; set; }
        public ushort VerticesCount { get; set; }
        public ushort TrianglesCount { get; set; }
        public Vector3[] Vertices { get; set; }
        public Triangle[] Triangles { get; set; }
        public TriangleUVs[] TriangleUVs { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Flags = s.Serialize<GeometryObjectFlags>(Flags, name: nameof(Flags));
            Byte_01 = s.Serialize<byte>(Byte_01, name: nameof(Byte_01));
            Ushort_02 = s.Serialize<ushort>(Ushort_02, name: nameof(Ushort_02));
            VerticesCount = s.Serialize<ushort>(VerticesCount, name: nameof(VerticesCount));
            TrianglesCount = s.Serialize<ushort>(TrianglesCount, name: nameof(TrianglesCount));
            Vertices = s.SerializeObjectArray<Vector3>(Vertices, VerticesCount, name: nameof(Vertices));
            Triangles = s.SerializeObjectArray<Triangle>(Triangles, TrianglesCount, name: nameof(Triangles));

            if ((Flags & GeometryObjectFlags.IsTextured) != 0)
                TriangleUVs = s.SerializeObjectArray<TriangleUVs>(TriangleUVs, Triangles.Max(x => x.UVsOffset) / 6 + 1, name: nameof(TriangleUVs));
            else
                throw new NotImplementedException();
        }
    }
}