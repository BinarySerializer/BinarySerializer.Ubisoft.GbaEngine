namespace BinarySerializer.Onyx.Gba
{
    public class ActorModel : Resource
    {
        public EngineBox ViewBox { get; set; }
        public EngineBox DetectionBox { get; set; }
        
        public byte Idx_AnimatedObject { get; set; }
        public ActorFlags Flags { get; set; }
        public byte HitPoints { get; set; }
        public byte AttackPoints { get; set; }

        public Action[] Actions { get; set; }

        // Dependencies
        public AnimatedObject AnimatedObject { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            ViewBox = s.SerializeObject<EngineBox>(ViewBox, name: nameof(ViewBox));
            DetectionBox = s.SerializeObject<EngineBox>(DetectionBox, name: nameof(DetectionBox));

            Idx_AnimatedObject = s.Serialize<byte>(Idx_AnimatedObject, name: nameof(Idx_AnimatedObject));
            Flags = s.Serialize<ActorFlags>(Flags, name: nameof(Flags));
            HitPoints = s.Serialize<byte>(HitPoints, name: nameof(HitPoints));
            AttackPoints = s.Serialize<byte>(AttackPoints, name: nameof(AttackPoints));

            Actions = s.SerializeObjectArray<Action>(Actions, (Size - 12) / 8, name: nameof(Actions));
        }

        public override void SerializeDependencies(SerializerObject s)
        {
            AnimatedObject = SerializeDependency<AnimatedObject>(s, AnimatedObject, Idx_AnimatedObject, name: nameof(AnimatedObject));

            // TODO: Serialize action data
        }
    }
}