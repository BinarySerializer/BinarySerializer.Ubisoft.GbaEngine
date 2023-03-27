using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Onyx.Gba
{
    public class SpritePalettes : Resource
    {
        public bool Pre_Is8Bit { get; set; }
        public int Pre_PalettesCount { get; set; }

        public Palette[] Palettes { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            if (Pre_PalettesCount == 0)
                throw new MissingPreValueException(this, nameof(Pre_PalettesCount));

            Palettes = s.SerializeObjectArray<Palette>(Palettes, Pre_PalettesCount, x => x.Pre_Is8Bit = Pre_Is8Bit, name: nameof(Palettes));
        }
    }
}