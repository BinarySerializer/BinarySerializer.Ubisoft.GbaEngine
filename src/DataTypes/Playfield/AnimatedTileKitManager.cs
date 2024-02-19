namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class AnimatedTileKitManager : Resource
    {
        public byte AnimatedTileKitsCount { get; set; }
        public byte[] Idx_AnimatedTileKits { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            AnimatedTileKitsCount = s.Serialize<byte>(AnimatedTileKitsCount, name: nameof(AnimatedTileKitsCount));
            Idx_AnimatedTileKits = s.SerializeArray<byte>(Idx_AnimatedTileKits, AnimatedTileKitsCount, name: nameof(Idx_AnimatedTileKits));
        }
    }
}