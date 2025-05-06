using System;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class OffsetTable : BinarySerializable
    {
        public int Count { get; set; }
        public int[] Offsets { get; set; }

        public Pointer GetPointer(Context context, int index)
        {
            if (index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Invalid offset index {index}, length is {Count}");

            OffsetTable rootTable = context.GetRequiredSettings<GbaEngineSettings>().RootTable;
            return rootTable.Offset + Offsets[index] * 4;
        }

        public T ReadResource<T>(Context context, int index, Action<SerializerObject, T> onPreSerialize = null, string name = null)
            where T : Resource, new()
        {
            return FileFactory.Read<T>(context, GetPointer(context, index), onPreSerialize: onPreSerialize, name: name);
        }

        public T ReadResource<T>(Context context, Enum definedResource, Action<SerializerObject, T> onPreSerialize = null, string name = null)
            where T : Resource, new()
        {
            GbaEngineSettings settings = context.GetRequiredSettings<GbaEngineSettings>();
            int resourceId = settings.GetDefinedResourceId(definedResource);

            return FileFactory.Read<T>(context, GetPointer(context, resourceId), onPreSerialize: onPreSerialize, name: name);
        }

        public override void SerializeImpl(SerializerObject s)
        {
            Count = s.Serialize<int>(Count, name: nameof(Count));
            Offsets = s.SerializeArray<int>(Offsets, Count, name: nameof(Offsets));
        }
    }
}