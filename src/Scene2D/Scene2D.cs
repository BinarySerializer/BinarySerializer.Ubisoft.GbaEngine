using System;

namespace BinarySerializer.Onyx.Gba
{
    public class Scene2D : Resource
    {
        public byte Idx_PlayField { get; set; }
        public ushort Ushort_02 { get; set; }
        public byte GameObjectCount { get; set; }
        public byte AlwaysActorsCount { get; set; }
        public byte ActorsCount { get; set; }
        public byte Byte_07 { get; set; }
        public byte Byte_08 { get; set; }
        public byte CaptorsCount { get; set; }
        public byte Byte_0A { get; set; }
        public byte KnotsCount { get; set; }
        public Actor[] AlwaysActors { get; set; }
        public Actor[] Actors { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            Idx_PlayField = s.Serialize<byte>(Idx_PlayField, name: nameof(Idx_PlayField));
            Ushort_02 = s.Serialize<ushort>(Ushort_02, name: nameof(Ushort_02));
            GameObjectCount = s.Serialize<byte>(GameObjectCount, name: nameof(GameObjectCount));
            AlwaysActorsCount = s.Serialize<byte>(AlwaysActorsCount, name: nameof(AlwaysActorsCount));
            ActorsCount = s.Serialize<byte>(ActorsCount, name: nameof(ActorsCount));
            Byte_07 = s.Serialize<byte>(Byte_07, name: nameof(Byte_07));
            Byte_08 = s.Serialize<byte>(Byte_08, name: nameof(Byte_08));
            CaptorsCount = s.Serialize<byte>(CaptorsCount, name: nameof(CaptorsCount));
            Byte_0A = s.Serialize<byte>(Byte_0A, name: nameof(Byte_0A));
            KnotsCount = s.Serialize<byte>(KnotsCount, name: nameof(KnotsCount));

            AlwaysActors = s.SerializeObjectArray<Actor>(AlwaysActors, AlwaysActorsCount, name: nameof(AlwaysActors));
            Actors = s.SerializeObjectArray<Actor>(Actors, ActorsCount, name: nameof(Actors));
            throw new NotImplementedException("Not implemented serializing captors and knots");
        }

        public override void SerializeDependencies(SerializerObject s)
        {
            throw new NotImplementedException("Not implemented serializing scene dependencies");
        }
    }
}