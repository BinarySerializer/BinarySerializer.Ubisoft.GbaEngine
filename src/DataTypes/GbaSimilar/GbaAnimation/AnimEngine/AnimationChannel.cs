using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class AnimationChannel : BinarySerializable
    {
        public AnimationChannelType ChannelType { get; set; }

        // Sprite
        public short XPosition { get; set; }
        public short YPosition { get; set; }
        public byte SpriteShape { get; set; }
        public byte SpriteSize { get; set; }
        public OBJ_ATTR_ObjectMode ObjectMode { get; set; }
        public ushort TileIndex { get; set; }
        public byte PalIndex { get; set; }
        public bool ReusesTiles { get; set; } // Same tiles as previous channel
        public bool FlipX { get; set; }
        public bool FlipY { get; set; }
        public ushort AffineMatrixIndex { get; set; }

        // Sound
        public short SoundId { get; set; }

        // Displacement vector
        public Vector2 DisplacementVector { get; set; }

        // Box
        public ChannelBox Box { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            s.DoBits<ushort>(b =>
            {
                YPosition = b.SerializeBits<short>(YPosition, 8, sign: SignedNumberRepresentation.TwosComplement, name: nameof(YPosition));
                ObjectMode = b.SerializeBits<OBJ_ATTR_ObjectMode>(ObjectMode, 2, name: nameof(ObjectMode));
                ChannelType = b.SerializeBits<AnimationChannelType>(ChannelType, 4, name: nameof(ChannelType));
                SpriteShape = b.SerializeBits<byte>(SpriteShape, 2, name: nameof(SpriteShape));
            });

            switch (ChannelType)
            {
                case AnimationChannelType.None:
                    s.SerializePadding(4, logIfNotNull: true);
                    break;

                case AnimationChannelType.Sprite:
                    if (ObjectMode == OBJ_ATTR_ObjectMode.HIDE)
                        throw new BinarySerializableException(this, "Invalid object mode");

                    s.DoBits<ushort>(b =>
                    {
                        XPosition = b.SerializeBits<short>(XPosition, 9, sign: SignedNumberRepresentation.TwosComplement, name: nameof(XPosition));

                        if (ObjectMode == OBJ_ATTR_ObjectMode.REG)
                        {
                            b.SerializePadding(3, logIfNotNull: true);
                            FlipX = b.SerializeBits<bool>(FlipX, 1, name: nameof(FlipX));
                            FlipY = b.SerializeBits<bool>(FlipY, 1, name: nameof(FlipY));
                        }
                        else
                        {
                            AffineMatrixIndex = b.SerializeBits<ushort>(AffineMatrixIndex, 5, name: nameof(AffineMatrixIndex));
                        }

                        SpriteSize = b.SerializeBits<byte>(SpriteSize, 2, name: nameof(SpriteSize));
                    });
                    s.DoBits<ushort>(b =>
                    {
                        TileIndex = b.SerializeBits<ushort>(TileIndex, 12, name: nameof(TileIndex));
                        PalIndex = b.SerializeBits<byte>(PalIndex, 3, name: nameof(PalIndex));
                        ReusesTiles = b.SerializeBits<bool>(ReusesTiles, 1, name: nameof(ReusesTiles));
                    });
                    break;

                case AnimationChannelType.Sound:
                    SoundId = s.Serialize<short>(SoundId, name: nameof(SoundId));
                    s.SerializePadding(2, logIfNotNull: true);
                    break;

                case AnimationChannelType.DisplacementVector:
                    DisplacementVector = s.SerializeObject<Vector2>(DisplacementVector, name: nameof(DisplacementVector));
                    break;

                case AnimationChannelType.AttackBox or AnimationChannelType.VulnerabilityBox:
                    Box = s.SerializeObject<ChannelBox>(Box, name: nameof(Box));
                    break;

                default:
                    throw new BinarySerializableException(this, $"Unsupported channel type {ChannelType}");
            }
        }
    }
}