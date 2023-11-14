using System.Linq;

namespace BinarySerializer.Onyx.Gba
{
    public class Animation : Resource
    {
        public byte Speed { get; set; }
        public bool DoNotRepeat { get; set; }
        public byte Idx_PaletteCycleAnimation { get; set; }
        public byte Idx_AffineMatrices { get; set; }
        public byte FramesCount { get; set; }
        public byte FramesCountAlignment { get; set; }

        public byte[] ChannelsPerFrame { get; set; }
        public AnimationChannel[] Channels { get; set; }

        // Dependencies (from AnimatedObject)
        public AffineMatrices AffineMatrices { get; set; }
        public PaletteCycleAnimation PaletteCycleAnimation { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            s.DoBits<byte>(b =>
            {
                Speed = b.SerializeBits<byte>(Speed, 7, name: nameof(Speed));
                DoNotRepeat = b.SerializeBits<bool>(DoNotRepeat, 1, name: nameof(DoNotRepeat));
            });
            Idx_PaletteCycleAnimation = s.Serialize<byte>(Idx_PaletteCycleAnimation, name: nameof(Idx_PaletteCycleAnimation));
            Idx_AffineMatrices = s.Serialize<byte>(Idx_AffineMatrices, name: nameof(Idx_AffineMatrices));
            s.DoBits<byte>(b =>
            {
                FramesCount = b.SerializeBits<byte>(FramesCount, 6, name: nameof(FramesCount));
                FramesCountAlignment = b.SerializeBits<byte>(FramesCountAlignment, 2, name: nameof(FramesCountAlignment));
            });

            ChannelsPerFrame = s.SerializeArray<byte>(ChannelsPerFrame, FramesCount, name: nameof(ChannelsPerFrame));
            s.SerializePadding(FramesCountAlignment, logIfNotNull: true);
        
            Channels = s.SerializeObjectArray<AnimationChannel>(Channels, ChannelsPerFrame.Sum(x => x), name: nameof(Channels));
        }
    }
}