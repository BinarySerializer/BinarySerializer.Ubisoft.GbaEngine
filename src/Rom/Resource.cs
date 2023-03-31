using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySerializer.Onyx.Gba
{
    public abstract class Resource : BinarySerializable
    {
        private bool[] _serializedDependencies;

        public uint Size { get; set; }
        public OffsetTable OffsetTable { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            // Serialize header and footer
            SerializeHeader(s);
            SerializeOffsetTable(s);

            // Serialize the block
            SerializeResource(s);
            CheckSize(s);

            // Serialize dependencies
            SerializeDependencies(s);
            CheckDependencies(s);
        }

        private void SerializeHeader(SerializerObject s)
        {
            s.DoAt(Offset - 4, () => Size = s.Serialize<uint>(Size, name: nameof(Size)));
        }

        private void SerializeOffsetTable(SerializerObject s)
        {
            s.DoAt(Offset + Size, () => 
            {
                s.Align();
                OffsetTable = s.SerializeObject<OffsetTable>(OffsetTable, name: nameof(OffsetTable));
                _serializedDependencies = new bool[OffsetTable.Count];
            });
        }

        private void CheckSize(SerializerObject s)
        {
            if (Offset + Size != s.CurrentPointer)
            {
                s.SystemLogger?.LogWarning($"{GetType().Name} @ {Offset}: Serialized size 0x{s.CurrentPointer - Offset:X8} != resource size 0x{Size:X8}");
            }
        }

        private void CheckDependencies(SerializerObject s)
        {
            if (_serializedDependencies != null && _serializedDependencies.Any(x => !x))
            {
                IEnumerable<int> skippedIndexes = _serializedDependencies.
                    Select((x, i) => new { Serialized = x, Index = i }).
                    Where(x => !x.Serialized).
                    Select(x => x.Index);
                s.SystemLogger?.LogWarning($"{GetType().Name} @ {Offset}: Not all dependencies were serialized ({String.Join(", ", skippedIndexes)})");
            }
        }

        public T SerializeDependency<T>(SerializerObject s, T obj, int index, Action<T> onPreSerialize = null, string name = null)
            where T : Resource, new()
        {
            Pointer pointer = OffsetTable.GetPointer(s.Context, index);
            s.DoAt(pointer, () =>
            {
                obj = s.SerializeObject<T>(obj, onPreSerialize, name: name);

                if (_serializedDependencies != null && _serializedDependencies.Length > index)
                    _serializedDependencies[index] = true;
            });
            return obj;
        }

        public T[] SerializeDependencyArray<T>(SerializerObject s, T[] obj, byte[] indexes, int count = -1, Action<T> onPreSerialize = null, string name = null)
            where T : Resource, new()
        {
            if (count == -1)
                count = indexes.Length;

            if (obj != null)
            {
                if (obj.Length != count)
                    Array.Resize(ref obj, count);
            }
            else
            {
                obj = new T[count];
            }

            for (int i = 0; i < count; i++)
                obj[i] = SerializeDependency<T>(s, obj[i], indexes[i], onPreSerialize: onPreSerialize, name: s.IsSerializerLoggerEnabled ? $"{name ?? "Dependencies"}[{i}]" : null);

            return obj;
        }

        public abstract void SerializeResource(SerializerObject s);
        public virtual void SerializeDependencies(SerializerObject s) { }
    }
}