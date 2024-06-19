namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class AnimationFrame : BinarySerializable
    {
        public byte RotationX { get; set; }
        public byte RotationY { get; set; }
        public byte RotationZ { get; set; }
        public Vector3 Position { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            RotationX = s.Serialize<byte>(RotationX, name: nameof(RotationX));
            RotationY = s.Serialize<byte>(RotationY, name: nameof(RotationY));
            RotationZ = s.Serialize<byte>(RotationZ, name: nameof(RotationZ));
            s.SerializePadding(1, logIfNotNull: true);
            Position = s.SerializeObject<Vector3>(Position, name: nameof(Position));
        }
    }
}