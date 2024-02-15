namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class Actor : GameObject
    {
        public byte Type { get; set; }
        public byte Idx_ActorModel { get; set; }
        public byte FirstActionId { get; set; }
        public byte?[] Links { get; set; }

        // Dependencies
        public ActorModel Model { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            base.SerializeImpl(s);

            Type = s.Serialize<byte>(Type, name: nameof(Type));
            Idx_ActorModel = s.Serialize<byte>(Idx_ActorModel, name: nameof(Idx_ActorModel));
            FirstActionId = s.Serialize<byte>(FirstActionId, name: nameof(FirstActionId));
            Links = s.SerializeNullableArray<byte>(Links, 4, name: nameof(Links));
        }
    }
}