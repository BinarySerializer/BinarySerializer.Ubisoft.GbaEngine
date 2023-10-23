namespace BinarySerializer.Onyx.Gba
{
    public class Actor : GameObject
    {
        public byte Id { get; set; }
        public byte Idx_ActorModel { get; set; }
        public byte FirstActionId { get; set; }
        public byte[] Links { get; set; }

        // Dependencies
        public ActorModel Model { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            base.SerializeImpl(s);

            Id = s.Serialize<byte>(Id, name: nameof(Id));
            Idx_ActorModel = s.Serialize<byte>(Idx_ActorModel, name: nameof(Idx_ActorModel));
            FirstActionId = s.Serialize<byte>(FirstActionId, name: nameof(FirstActionId));
            Links = s.SerializeArray<byte>(Links, 4, name: nameof(Links));
        }
    }
}