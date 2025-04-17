using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class PaletteTable : Resource
    {
        public ushort PalettesCount { get; set; }
        public Pointer<Palette>[] Palettes { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            PalettesCount = s.Serialize<ushort>(PalettesCount, name: nameof(PalettesCount));
            s.SerializePadding(2, logIfNotNull: true);

            Palettes = s.SerializePointerArray<Palette>(Palettes, PalettesCount, size: PointerSize.Pointer16, anchor: Offset, name: nameof(Palettes));
            Palettes.ResolveObject(s, (x, _) => x.Pre_Is8Bit = true);

            s.Goto(Offset + Size);
        }
    }
}