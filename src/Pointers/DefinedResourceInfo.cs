using System;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class DefinedResourceInfo<T>
        where T : Enum
    {
        public DefinedResourceInfo(Type type, T resource)
        {
            Resource = resource;
            Type = type;
        }

        public T Resource { get; }
        public Type Type { get; }
    }
}