using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    // NOTE: Could turn into a struct, but it's pretty big (around 36 bytes) so not really worth it for performance
    public class AnimationChannel : BinarySerializable
    {
        public AnimationChannelType ChannelType { get; set; }

        // Sprite
        public short XPosition { get; set; }
        public short YPosition { get; set; }
        public byte SpriteShape { get; set; }
        public byte SpriteSize { get; set; }
        public OBJ_ATTR_ObjectMode ObjectMode { get; set; }
        public byte UnusedValue { get; set; }
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
            GbaEngineSettings settings = s.GetRequiredSettings<GbaEngineSettings>();

            SignedNumberRepresentation signedNumberRepresentation = settings.Game is 
                Game.Rayman3_20020118_DemoRLE or 
                Game.Rayman3_20020301_PreAlpha or 
                Game.Rayman3_20020418_NintendoE3Approval
                ? SignedNumberRepresentation.SignMagnitude
                : SignedNumberRepresentation.TwosComplement;

            s.DoBits<ushort>(b =>
            {
                YPosition = b.SerializeBits<short>(YPosition, 8, sign: signedNumberRepresentation, name: nameof(YPosition));

                if (settings.Game == Game.Rayman3_20020118_DemoRLE)
                {
                    ObjectMode = OBJ_ATTR_ObjectMode.REG;
                    UnusedValue = b.SerializeBits<byte>(UnusedValue, 2, name: nameof(UnusedValue));
                }
                else
                {
                    ObjectMode = b.SerializeBits<OBJ_ATTR_ObjectMode>(ObjectMode, 2, name: nameof(ObjectMode));
                }

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
                        XPosition = b.SerializeBits<short>(XPosition, 9, sign: signedNumberRepresentation, name: nameof(XPosition));

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
                    DisplacementVector = s.SerializeInto<Vector2>(DisplacementVector, Vector2.SerializeInto, name: nameof(DisplacementVector));
                    break;

                case AnimationChannelType.AttackBox or AnimationChannelType.VulnerabilityBox or AnimationChannelType.VulnerabilityBox_Prototypes:
                    Box = s.SerializeInto<ChannelBox>(Box, ChannelBox.SerializeInto, name: nameof(Box));
                    break;

                default:
                    throw new BinarySerializableException(this, $"Unsupported channel type {ChannelType}");
            }
        }
    }
}