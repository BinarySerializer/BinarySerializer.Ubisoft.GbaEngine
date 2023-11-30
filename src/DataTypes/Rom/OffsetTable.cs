using System;
using System.Linq;

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

        public T ReadResource<T>(Context context, int index, string name = null)
            where T : Resource, new()
        {
            return FileFactory.Read<T>(context, GetPointer(context, index), name: name);
        }

        public T ReadResource<T>(Context context, GameResource gameResource, string name = null)
            where T : Resource, new()
        {
            OnyxGbaSettings settings = context.GetRequiredSettings<OnyxGbaSettings>();

            GameResourceDefineAttribute define = gameResource.
                GetAttributes<GameResourceDefineAttribute>().
                FirstOrDefault(x => x.Game == settings.Game && x.Platform == settings.Platform);

            if (define == null)
                throw new ArgumentException("Enum value has no game resource define for the current game settings", nameof(gameResource));

            return FileFactory.Read<T>(context, GetPointer(context, define.ResourceId), name: name);
        }

        public override void SerializeImpl(SerializerObject s)
        {
            Count = s.Serialize<int>(Count, name: nameof(Count));
            Offsets = s.SerializeArray<int>(Offsets, Count, name: nameof(Offsets));
        }
    }
}