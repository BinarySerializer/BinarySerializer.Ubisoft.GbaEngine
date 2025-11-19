using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public abstract class Resource : BinarySerializable
    {
        private bool[] _serializedDependencies;

        public bool Pre_IsGameCubeResource { get; set; }
        public bool Pre_SerializeDependencies { get; set; } = true;

        public uint Size { get; set; }
        public OffsetTable OffsetTable { get; set; }
        public GameCubeOffsetTable GameCubeOffsetTable { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            // Serialize header and footer
            SerializeHeader(s);
            if (!Pre_IsGameCubeResource)
                SerializeOffsetTable(s);

            // Serialize the block
            SerializeResource(s);
            if (Pre_IsGameCubeResource)
                s.Align();
            CheckSize(s);

            // Serialize GameCube offset table
            if (Pre_IsGameCubeResource)
                SerializeGameCubeOffsetTable(s);

            // Serialize dependencies
            if (Pre_SerializeDependencies)
            {
                SerializeDependencies(s);
                CheckDependencies(s);
            }
        }

        private void SerializeHeader(SerializerObject s)
        {
            if (Pre_IsGameCubeResource)
                Size = s.Serialize<uint>(Size, name: nameof(Size));
            else
                s.DoAt(Offset - 4, () => Size = s.Serialize<uint>(Size, name: nameof(Size)));
        }

        private void SerializeOffsetTable(SerializerObject s)
        {
            s.DoAt(Offset + Size, () => 
            {
                s.Align();
                OffsetTable = s.SerializeObject<OffsetTable>(OffsetTable, name: nameof(OffsetTable));
                _serializedDependencies = OffsetTable.Count == 0 ? Array.Empty<bool>() : new bool[OffsetTable.Count];
            });
        }

        private void SerializeGameCubeOffsetTable(SerializerObject s)
        {
            s.DoAt(Offset + Size, () => 
            {
                s.Align();
                int count = GetGameCubeOffsetsCount(s);
                GameCubeOffsetTable = s.SerializeObject<GameCubeOffsetTable>(GameCubeOffsetTable, x => x.Pre_Count = count, name: nameof(GameCubeOffsetTable));
                _serializedDependencies = count == 0 ? Array.Empty<bool>() : new bool[count];
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

        protected virtual int GetGameCubeOffsetsCount(SerializerObject s) => 0;

        public T SerializeDependency<T>(SerializerObject s, T obj, int index, bool isLocalOnGameCube = false, Action<T> onPreSerialize = null, string name = null)
            where T : Resource, new()
        {
            Pointer pointer = Pre_IsGameCubeResource 
                ? GameCubeOffsetTable.GetPointer(s.Context, this, index, isLocalOnGameCube) 
                : OffsetTable.GetPointer(s.Context, index);

            if (pointer == null)
            {
                if (_serializedDependencies != null && _serializedDependencies.Length > index)
                    _serializedDependencies[index] = true;
            }
            else
            {
                s.DoAt(pointer, () =>
                {
                    Action<T> preSerializeResource = Pre_IsGameCubeResource && isLocalOnGameCube
                        ? x =>
                        {
                            x.Pre_IsGameCubeResource = true;
                            onPreSerialize?.Invoke(x);
                        }
                        : onPreSerialize;

                    obj = s.SerializeObject<T>(obj, preSerializeResource, name: name);

                    if (_serializedDependencies != null && _serializedDependencies.Length > index)
                        _serializedDependencies[index] = true;
                });
            }

            return obj;
        }

        public T[] SerializeDependencyArray<T>(SerializerObject s, T[] obj, byte[] indexes, int count = -1, bool isLocalOnGameCube = false, Action<T> onPreSerialize = null, string name = null)
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
                obj[i] = SerializeDependency<T>(s, obj[i], indexes[i], isLocalOnGameCube: isLocalOnGameCube, onPreSerialize: onPreSerialize, name: s.IsSerializerLoggerEnabled ? $"{name ?? "Dependencies"}[{i}]" : null);

            return obj;
        }

        public abstract void SerializeResource(SerializerObject s);
        public virtual void SerializeDependencies(SerializerObject s) { }
    }

    public class Resource<T> : Resource
        where T : BinarySerializable, new()
    {
        public T Value { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            Value = s.SerializeObject<T>(Value, name: nameof(Value));
        }
    }
}