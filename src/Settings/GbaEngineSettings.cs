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

        public void SetDefinedResources<T>(Dictionary<int, DefinedResourceInfo<T>> definedResources)
            where T : Enum
        {
            DefinedResources = definedResources.ToDictionary(x => (Enum)x.Value.Resource, x => x.Key);
        }

        public int GetDefinedResourceId<T>(T definedResource)
            where T : Enum
        {
            if (DefinedResources == null)
                throw new Exception("The resources have not been defined");

            return DefinedResources[definedResource];
        }
    }
}