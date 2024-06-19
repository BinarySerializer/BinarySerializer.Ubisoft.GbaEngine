namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class CaptorEvents : Resource
    {
        public int Pre_Length { get; set; }
        public CaptorEvent[] Events { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            Events = s.SerializeObjectArray<CaptorEvent>(Events, Pre_Length, name: nameof(Events));
        }
    }
}