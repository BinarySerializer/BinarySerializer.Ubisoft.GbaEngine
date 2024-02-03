using System;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class GameCubeOffsetTable : BinarySerializable
    {
        public int Pre_Count { get; set; }
        public int[] Offsets { get; set; }

        public Pointer GetPointer(Context context, Resource resource, int index, bool isLocal)
        {
            if (index >= Pre_Count)
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Invalid offset index {index}, length is {Pre_Count}");

            if (Offsets[index] == -1)
                return null;

            if (isLocal)
            {
                return resource.Offset + Offsets[index];
            }
            else
            {
                OffsetTable rootTable = context.GetRequiredSettings<GbaEngineSettings>().RootTable;
                return rootTable.Offset + Offsets[index] * 4;
            }
        }

        public override void SerializeImpl(SerializerObject s)
        {
            Offsets = s.SerializeArray<int>(Offsets, Pre_Count, name: nameof(Offsets));
        }
    }
}