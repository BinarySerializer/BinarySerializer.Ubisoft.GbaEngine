namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class JoyPadReplayData : BinarySerializable
    {
        public GbaInput[] Inputs { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Inputs = s.SerializeArrayUntil(Inputs, x => x == GbaInput.None, name: nameof(Inputs));
        }
    }
}