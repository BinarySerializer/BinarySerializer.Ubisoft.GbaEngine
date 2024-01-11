namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class TileMappingTable : Resource
    {
        public ushort Count8bpp { get; set; }
        public ushort Count4bpp { get; set; }

        public ushort[] Table8bpp { get; set; }
        public ushort[] Table4bpp { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            Count8bpp = s.Serialize<ushort>(Count8bpp, name: nameof(Count8bpp));
            Count4bpp = s.Serialize<ushort>(Count4bpp, name: nameof(Count4bpp));

            Table8bpp = s.SerializeArray<ushort>(Table8bpp, Count8bpp, name: nameof(Table8bpp));
            Table4bpp = s.SerializeArray<ushort>(Table4bpp, Count4bpp, name: nameof(Table4bpp));
        }
    }
}