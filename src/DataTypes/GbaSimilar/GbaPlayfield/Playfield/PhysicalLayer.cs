using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class PhysicalLayer : BinarySerializable
    {
        public GameLayer Pre_GameLayer { get; set; }

        public byte[] CollisionMap { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            IStreamEncoder encoder = Pre_GameLayer.IsCompressed ? new LZSSEncoder() : null;
            s.DoEncoded(encoder, () => CollisionMap = s.SerializeArray<byte>(CollisionMap, Pre_GameLayer.Width * Pre_GameLayer.Height, name: nameof(CollisionMap)));
            s.Align();
        }
    }
}