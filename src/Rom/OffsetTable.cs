using System;

namespace BinarySerializer.Onyx.Gba
{
    public class OffsetTable : BinarySerializable
    {
        public int Count { get; set; }
        public int[] Offsets { get; set; }

        public Pointer GetPointer(Context context, int index)
        {
            if (index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Invalid offset index {index}, length is {Count}");

            OffsetTable rootTable = context.GetRequiredSettings<OnyxGbaSettings>().RootTable;

            return rootTable.Offset + Offsets[index] * 4;
        }

        public override void SerializeImpl(SerializerObject s)
        {
            Count = s.Serialize<int>(Count, name: nameof(Count));
            Offsets = s.SerializeArray<int>(Offsets, Count, name: nameof(Offsets));
        }
    }
}