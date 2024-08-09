namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class RawResource : Resource
    {
        public byte[] RawData { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            RawData = s.SerializeArray<byte>(RawData, Size, name: nameof(RawData));
        }
    }
}