using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class TilePalette : Resource
    {
        public ushort ColorsCount { get; set; }
        public Palette Palette { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            ColorsCount = s.Serialize<ushort>(ColorsCount, name: nameof(ColorsCount));
            s.SerializePadding(2, logIfNotNull: true);
            Palette = s.SerializeObject<Palette>(Palette, x => x.Pre_CustomLength = ColorsCount, name: nameof(Palette));
        }
    }
}