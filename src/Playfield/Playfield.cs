using System;

namespace BinarySerializer.Onyx.Gba
{
    public  class Playfield : Resource
    {
        public PlayfieldType Type { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            Type = s.Serialize<PlayfieldType>(Type, name: nameof(Type));

            if (Type == PlayfieldType.Playfield2d)
            {
                throw new NotImplementedException("Not implemented serializing Playfield2d");
            }
            else if (Type == PlayfieldType.PlayfieldMode7)
            {
                throw new NotImplementedException("Not implemented serializing PlayfieldMode7");
            }
            else if (Type == PlayfieldType.PlayfieldScope)
            {
                throw new NotImplementedException("Not implemented serializing PlayfieldScope");
            }
            else
            {
                throw new BinarySerializableException(this, $"Undefined playfield type {Type}");
            }
        }
    }
}
