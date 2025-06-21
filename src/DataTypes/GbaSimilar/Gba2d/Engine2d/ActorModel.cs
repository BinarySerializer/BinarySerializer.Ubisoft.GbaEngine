namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class ActorModel : Resource
    {
        public EngineBox ViewBox { get; set; }
        public EngineBox DetectionBox { get; set; }
        
        public byte Idx_AnimatedObject { get; set; }

        public ActorMapCollisionType MapCollisionType { get; set; }
        public bool CheckAgainstMapCollision { get; set; }
        public bool CheckAgainstObjectCollision { get; set; }
        public bool IsSolid { get; set; }
        public bool IsAgainstCaptor { get; set; }
        public bool ReceivesDamage { get; set; }
        
        public byte HitPoints { get; set; }
        public byte AttackPoints { get; set; }

        public Action[] Actions { get; set; }

        // Dependencies
        public AnimatedObject AnimatedObject { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            ViewBox = s.SerializeInto<EngineBox>(ViewBox, EngineBox.SerializeInto, name: nameof(ViewBox));
            DetectionBox = s.SerializeInto<EngineBox>(DetectionBox, EngineBox.SerializeInto, name: nameof(DetectionBox));

            Idx_AnimatedObject = s.Serialize<byte>(Idx_AnimatedObject, name: nameof(Idx_AnimatedObject));
            s.DoBits<byte>(b =>
            {
                MapCollisionType = b.SerializeBits<ActorMapCollisionType>(MapCollisionType, 3, name: nameof(MapCollisionType));
                CheckAgainstMapCollision = b.SerializeBits<bool>(CheckAgainstMapCollision, 1, name: nameof(CheckAgainstMapCollision));
                CheckAgainstObjectCollision = b.SerializeBits<bool>(CheckAgainstObjectCollision, 1, name: nameof(CheckAgainstObjectCollision));
                IsSolid = b.SerializeBits<bool>(IsSolid, 1, name: nameof(IsSolid));
                IsAgainstCaptor = b.SerializeBits<bool>(IsAgainstCaptor, 1, name: nameof(IsAgainstCaptor));
                ReceivesDamage = b.SerializeBits<bool>(ReceivesDamage, 1, name: nameof(ReceivesDamage));
            });
            HitPoints = s.Serialize<byte>(HitPoints, name: nameof(HitPoints));
            AttackPoints = s.Serialize<byte>(AttackPoints, name: nameof(AttackPoints));

            Actions = s.SerializeObjectArray<Action>(Actions, (Size - 12) / 8, name: nameof(Actions));
        }

        public override void SerializeDependencies(SerializerObject s)
        {
            AnimatedObject = SerializeDependency<AnimatedObject>(s, AnimatedObject, Idx_AnimatedObject, name: nameof(AnimatedObject));

            foreach (Action action in Actions)
            {
                if (action.MechModelType != null && action.MechModelType.Value is not (0 or 1 or 2 or 33))
                {
                    action.MechModel = SerializeDependency<MechModel>(s, action.MechModel, action.Idx_MechModel, name: nameof(action.MechModel));
                }
            }
        }
    }
}