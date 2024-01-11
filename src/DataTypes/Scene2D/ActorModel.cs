namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class ActorModel : Resource
    {
        public EngineBox ViewBox { get; set; }
        public EngineBox DetectionBox { get; set; }
        
        public byte Idx_AnimatedObject { get; set; }

        public ActorMapCollisionType MapCollisionType { get; set; }
        public bool HasMapCollision { get; set; }
        public bool HasObjectCollision { get; set; }
        public bool Flag_06 { get; set; }
        public bool IsAgainstCaptor { get; set; }
        public bool ReceivesDamage { get; set; }
        
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
            s.DoBits<byte>(b =>
            {
                MapCollisionType = b.SerializeBits<ActorMapCollisionType>(MapCollisionType, 3, name: nameof(MapCollisionType));
                HasMapCollision = b.SerializeBits<bool>(HasMapCollision, 1, name: nameof(HasMapCollision));
                HasObjectCollision = b.SerializeBits<bool>(HasObjectCollision, 1, name: nameof(HasObjectCollision));
                Flag_06 = b.SerializeBits<bool>(Flag_06, 1, name: nameof(Flag_06));
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
                if (action.MechModelType != null)
                {
                    action.MechModel = SerializeDependency<MechModel>(s, action.MechModel, action.Idx_MechModel, name: nameof(action.MechModel));
                }
            }
        }
    }
}