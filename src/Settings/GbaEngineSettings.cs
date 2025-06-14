using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class GbaEngineSettings
    {
        public Game Game { get; set; }
        public Platform Platform { get; set; }

        public OffsetTable RootTable { get; set; }
        public Dictionary<Enum, int> DefinedResources { get; set; }
        public Dictionary<int, Type> DefinedResourceTypes { get; set; }

        public void SetDefinedResources<T>(Dictionary<int, DefinedResourceInfo<T>> definedResources)
            where T : Enum
        {
            DefinedResources = definedResources.ToDictionary(x => (Enum)x.Value.Resource, x => x.Key);
            DefinedResourceTypes = definedResources.ToDictionary(x => x.Key, x => x.Value.Type);
        }

        public int GetDefinedResourceId<T>(T definedResource)
            where T : Enum
        {
            if (DefinedResources == null || DefinedResourceTypes == null)
                throw new Exception("The resources have not been defined");

            return DefinedResources[definedResource];
        }

        public Type GetDefinedResourceType(int resourceId)
        {
            if (DefinedResources == null || DefinedResourceTypes == null)
                throw new Exception("The resources have not been defined");

            return DefinedResourceTypes.TryGetValue(resourceId, out Type type) ? type : typeof(Scene2D);
        }

        public Type GetDefinedResourceType<T>(T definedResource)
            where T : Enum
        {
            return GetDefinedResourceType(GetDefinedResourceId(definedResource));
        }
    }
}