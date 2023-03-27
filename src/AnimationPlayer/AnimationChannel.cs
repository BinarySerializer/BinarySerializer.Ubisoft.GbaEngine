using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Onyx.Gba
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
        public bool FlipX { get; set; }
        public bool FlipY { get; set; }
        public ushort AffineMatrixIndex { get; set; }

        // Sound
        public ushort SoundId { get; set; }

        // Unknown
        public Vector2 Unknown { get; set; }

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

            if (ChannelType == AnimationChannelType.Sprite)
            {
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
                    b.SerializePadding(1, logIfNotNull: true);
                });
            }
            else if (ChannelType == AnimationChannelType.Sound)
            {
                SoundId = s.Serialize<ushort>(SoundId, name: nameof(SoundId));
                s.SerializePadding(2, logIfNotNull: true);
            }
            else if (ChannelType == AnimationChannelType.Unknown)
            {
                Unknown = s.SerializeObject<Vector2>(Unknown, name: nameof(Unknown));
            }
            else if (ChannelType is AnimationChannelType.AttackBox or AnimationChannelType.VulnerabilityBox)
            {
                Box = s.SerializeObject<ChannelBox>(Box, name: nameof(Box));
            }
            else
            {
                throw new BinarySerializableException(this, $"Unsupported channel type {ChannelType}");
            }
        }
    }
}