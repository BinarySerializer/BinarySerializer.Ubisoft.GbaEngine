namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class Animation3D : Resource
    {
        public int Pre_TransformsCount { get; set; }

        public byte FramesCount { get; set; }
        public byte FrameRate { get; set; }
        public ushort FrameSize { get; set; }
        public FixedPointInt32 Duration { get; set; }
        public AnimationFrame[] Frames { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            FramesCount = s.Serialize<byte>(FramesCount, name: nameof(FramesCount));
            FrameRate = s.Serialize<byte>(FrameRate, name: nameof(FrameRate));
            FrameSize = s.Serialize<ushort>(FrameSize, name: nameof(FrameSize));
            Duration = s.SerializeObject<FixedPointInt32>(Duration, x => x.Pre_PointPosition = 16, name: nameof(Duration));
            Frames = s.SerializeObjectArray<AnimationFrame>(Frames, FramesCount * Pre_TransformsCount, name: nameof(Frames));
        }
    }
}