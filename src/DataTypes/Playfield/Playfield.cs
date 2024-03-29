﻿using System;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class Playfield : Resource
    {
        public PlayfieldType Type { get; set; }

        public Playfield2D Playfield2D { get; set; }
        public PlayfieldMode7 PlayfieldMode7 { get; set; }

        protected override int GetGameCubeOffsetsCount(SerializerObject s)
        {
            // The tile kit is known to always be last
            return Playfield2D.Idx_TileKit + 1;
        }

        public override void SerializeResource(SerializerObject s)
        {
            Type = s.Serialize<PlayfieldType>(Type, name: nameof(Type));

            if (Type == PlayfieldType.Playfield2D)
                Playfield2D = s.SerializeObject<Playfield2D>(Playfield2D, name: nameof(Playfield2D));
            else if (Type == PlayfieldType.PlayfieldMode7)
                PlayfieldMode7 = s.SerializeObject<PlayfieldMode7>(PlayfieldMode7, name: nameof(PlayfieldMode7));
            else if (Type == PlayfieldType.PlayfieldScope)
                throw new NotImplementedException("Not implemented serializing PlayfieldScope");
            else
                throw new BinarySerializableException(this, $"Undefined playfield type {Type}");
        }

        public override void SerializeDependencies(SerializerObject s)
        {
            if (Type == PlayfieldType.Playfield2D)
                Playfield2D.SerializeDependencies(s, this);
            else if (Type == PlayfieldType.PlayfieldMode7)
                PlayfieldMode7.SerializeDependencies(s, this);
            else if (Type == PlayfieldType.PlayfieldScope)
                throw new NotImplementedException("Not implemented serializing PlayfieldScope dependencies");
            else
                throw new BinarySerializableException(this, $"Undefined playfield type {Type}");
        }
    }
}