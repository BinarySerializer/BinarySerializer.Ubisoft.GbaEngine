namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class CaptorEvents : Resource
    {
        public int Pre_Length { get; set; }
        public CaptorEvent[] Events { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            Events = s.SerializeIntoArray<CaptorEvent>(Events, Pre_Length, CaptorEvent.SerializeInto, name: nameof(Events));
        }
    }
}