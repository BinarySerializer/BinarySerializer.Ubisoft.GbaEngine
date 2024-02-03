using System.Linq;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class Scene2D : Resource
    {
        public byte Idx_PlayField { get; set; }
        public ushort ActorVramLength { get; set; }
        public byte GameObjectCount { get; set; }
        public byte AlwaysActorsCount { get; set; }
        public byte ActorsCount { get; set; }
        public byte ProjectileActorsCount { get; set; } // Unused in final version of Rayman 3 - used in earlier engine versions
        public byte Byte_08 { get; set; }
        public byte CaptorsCount { get; set; }
        public byte KnotsWidth { get; set; }
        public byte KnotsCount { get; set; }
        public Actor[] AlwaysActors { get; set; }
        public Actor[] Actors { get; set; }
        public Captor[] Captors { get; set; }
        public Knot[] Knots { get; set; }

        // Dependencies
        public Playfield Playfield { get; set; }

        protected override int GetGameCubeOffsetsCount(SerializerObject s)
        {
            int highestIndex = Idx_PlayField;

            foreach (Actor actor in Actors.Concat(AlwaysActors))
            {
                if (actor.Idx_ActorModel > highestIndex) 
                    highestIndex = actor.Idx_ActorModel;
            }

            foreach (Captor captor in Captors)
            {
                if (captor.Idx_Events > highestIndex) 
                    highestIndex = captor.Idx_Events;
            }

            return highestIndex + 1;
        }

        public override void SerializeResource(SerializerObject s)
        {
            Idx_PlayField = s.Serialize<byte>(Idx_PlayField, name: nameof(Idx_PlayField));
            s.SerializePadding(1, logIfNotNull: true);
            ActorVramLength = s.Serialize<ushort>(ActorVramLength, name: nameof(ActorVramLength));
            GameObjectCount = s.Serialize<byte>(GameObjectCount, name: nameof(GameObjectCount));
            AlwaysActorsCount = s.Serialize<byte>(AlwaysActorsCount, name: nameof(AlwaysActorsCount));
            ActorsCount = s.Serialize<byte>(ActorsCount, name: nameof(ActorsCount));
            ProjectileActorsCount = s.Serialize<byte>(ProjectileActorsCount, name: nameof(ProjectileActorsCount));
            Byte_08 = s.Serialize<byte>(Byte_08, name: nameof(Byte_08));
            CaptorsCount = s.Serialize<byte>(CaptorsCount, name: nameof(CaptorsCount));
            KnotsWidth = s.Serialize<byte>(KnotsWidth, name: nameof(KnotsWidth));
            KnotsCount = s.Serialize<byte>(KnotsCount, name: nameof(KnotsCount));

            AlwaysActors = s.SerializeObjectArray<Actor>(AlwaysActors, AlwaysActorsCount, name: nameof(AlwaysActors));
            Actors = s.SerializeObjectArray<Actor>(Actors, ActorsCount, name: nameof(Actors));
            Captors = s.SerializeObjectArray<Captor>(Captors, CaptorsCount, name: nameof(Captors));
            Knots = s.SerializeObjectArray<Knot>(Knots, KnotsCount, name: nameof(Knots));
        }

        public override void SerializeDependencies(SerializerObject s)
        {
            Playfield = SerializeDependency<Playfield>(s, Playfield, Idx_PlayField, name: nameof(Playfield));

            foreach (Actor actor in AlwaysActors.Concat(Actors))
                actor.Model = SerializeDependency<ActorModel>(s, actor.Model, actor.Idx_ActorModel, name: nameof(actor.Model));

            foreach (Captor captor in Captors)
                captor.Events = SerializeDependency<CaptorEvents>(s, captor.Events, captor.Idx_Events, isLocalOnGameCube: true, onPreSerialize: x => x.Pre_Length = captor.EventsCount, name: nameof(captor.Events));
        }
    }
}