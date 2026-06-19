using BinarySerializer.Nintendo.GBA;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public readonly struct AnimationChannel : ISerializerShortLog
    {
        #region Constructor

        public AnimationChannel(Game game, ushort attribute0, ushort attribute1, ushort attribute2)
        {
            Game = game;
            Attribute0 = attribute0;
            Attribute1 = attribute1;
            Attribute2 = attribute2;
        }

        #endregion

        #region Data

        public Game Game { get; }

        // 00_08: Y position (signed)
        // 08_02: Object mode (unused in Rayman 3 RLE demo)
        // 10_04: Channel type
        // 14_02: Sprite shape
        public ushort Attribute0 { get; }

        // 00_09: X position (signed)
        // 09_03: Unused
        // 12_01: Flip X (regular object mode only)
        // 13_01: Flip Y (regular object mode only)
        // 09_05: Affine matrix index (affine object modes only)
        // 14_02: Sprite size
        public ushort Attribute1 { get; }

        // 00_12: Tile index
        // 12_03: Palette index
        // 15_01: Reuses tiles
        public ushort Attribute2 { get; }

        #endregion

        #region Values

        public AnimationChannelType ChannelType => (AnimationChannelType)BitHelpers.ExtractBits(Attribute0, 4, 10);

        // Sprite
        public short XPosition => (short)BitHelpers.ExtractBits64(Attribute1, 9, 0, GetSignedNumberRepresentation(Game));
        public short YPosition => (short)BitHelpers.ExtractBits64(Attribute0, 8, 0, GetSignedNumberRepresentation(Game));
        public byte SpriteShape => (byte)BitHelpers.ExtractBits(Attribute0, 2, 14);
        public byte SpriteSize => (byte)BitHelpers.ExtractBits(Attribute1, 2, 14);
        public OBJ_ATTR_ObjectMode ObjectMode => Game == Game.Rayman3_20020118_DemoRLE 
            ? OBJ_ATTR_ObjectMode.REG 
            : (OBJ_ATTR_ObjectMode)BitHelpers.ExtractBits(Attribute0, 2, 8);
        public ushort TileIndex => (ushort)BitHelpers.ExtractBits(Attribute2, 12, 0);
        public byte PalIndex => (byte)BitHelpers.ExtractBits(Attribute2, 3, 12);
        public bool ReusesTiles => BitHelpers.ExtractBits(Attribute2, 1, 15) != 0; // Same tiles as previous channel
        public bool FlipX => ObjectMode == OBJ_ATTR_ObjectMode.REG && BitHelpers.ExtractBits(Attribute1, 1, 12) != 0;
        public bool FlipY => ObjectMode == OBJ_ATTR_ObjectMode.REG && BitHelpers.ExtractBits(Attribute1, 1, 13) != 0;
        public ushort AffineMatrixIndex => (ushort)BitHelpers.ExtractBits(Attribute1, 5, 9);

        // Sound
        public short SoundId => (short)Attribute1;

        // Displacement vector
        public Vector2 DisplacementVector => new((short)Attribute1, (short)Attribute2);

        // Box
        public ChannelBox Box => new(
            bottom: (sbyte)BitHelpers.ExtractBits64(Attribute1, 8, 0, SignedNumberRepresentation.TwosComplement),
            top: (sbyte)BitHelpers.ExtractBits64(Attribute1, 8, 8, SignedNumberRepresentation.TwosComplement),
            left: (sbyte)BitHelpers.ExtractBits64(Attribute2, 8, 0, SignedNumberRepresentation.TwosComplement),
            right: (sbyte)BitHelpers.ExtractBits64(Attribute2, 8, 8, SignedNumberRepresentation.TwosComplement));

        #endregion

        #region Helpers

        private static SignedNumberRepresentation GetSignedNumberRepresentation(Game game)
        {
            return game is
                Game.Rayman3_20020118_DemoRLE or
                Game.Rayman3_20020301_PreAlpha or
                Game.Rayman3_20020418_NintendoE3Approval
                ? SignedNumberRepresentation.SignMagnitude
                : SignedNumberRepresentation.TwosComplement;
        }

        public static AnimationChannel CreateSpriteChannel(
            Game game, 
            short xPosition,
            short yPosition,
            byte spriteShape,
            byte spriteSize,
            OBJ_ATTR_ObjectMode objectMode,
            ushort tileIndex,
            byte palIndex,
            bool reusesTiles,
            bool flipX,
            bool flipY)
        {
            ushort attr0 = 0;
            ushort attr1 = 0;
            ushort attr2 = 0;

            attr0 = (ushort)BitHelpers.SetBits(attr0, (int)AnimationChannelType.Sprite, 4, 10);

            attr1 = (ushort)BitHelpers.SetBits64(attr1, xPosition, 9, 0, GetSignedNumberRepresentation(game));
            attr0 = (ushort)BitHelpers.SetBits64(attr0, yPosition, 8, 0, GetSignedNumberRepresentation(game));
            attr0 = (ushort)BitHelpers.SetBits(attr0, spriteShape, 2, 14);
            attr1 = (ushort)BitHelpers.SetBits(attr1, spriteSize, 2, 14);
            attr0 = (ushort)BitHelpers.SetBits(attr0, (int)objectMode, 2, 8);
            attr2 = (ushort)BitHelpers.SetBits(attr2, tileIndex, 12, 0);
            attr2 = (ushort)BitHelpers.SetBits(attr2, palIndex, 3, 12);
            attr2 = (ushort)BitHelpers.SetBits(attr2, reusesTiles ? 1 : 0, 1, 15);
            attr1 = (ushort)BitHelpers.SetBits(attr1, flipX ? 1 : 0, 1, 12);
            attr1 = (ushort)BitHelpers.SetBits(attr1, flipY ? 1 : 0, 1, 13);

            return new AnimationChannel(game, attr0, attr1, attr2);
        }

        public static AnimationChannel CreateAffineSpriteChannel(
            Game game, 
            short xPosition,
            short yPosition,
            byte spriteShape,
            byte spriteSize,
            OBJ_ATTR_ObjectMode objectMode,
            ushort tileIndex,
            byte palIndex,
            bool reusesTiles,
            ushort affineMatrixIndex)
        {
            ushort attr0 = 0;
            ushort attr1 = 0;
            ushort attr2 = 0;

            attr0 = (ushort)BitHelpers.SetBits(attr0, (int)AnimationChannelType.Sprite, 4, 10);

            attr1 = (ushort)BitHelpers.SetBits64(attr1, xPosition, 9, 0, GetSignedNumberRepresentation(game));
            attr0 = (ushort)BitHelpers.SetBits64(attr0, yPosition, 8, 0, GetSignedNumberRepresentation(game));
            attr0 = (ushort)BitHelpers.SetBits(attr0, spriteShape, 2, 14);
            attr1 = (ushort)BitHelpers.SetBits(attr1, spriteSize, 2, 14);
            attr0 = (ushort)BitHelpers.SetBits(attr0, (int)objectMode, 2, 8);
            attr2 = (ushort)BitHelpers.SetBits(attr2, tileIndex, 12, 0);
            attr2 = (ushort)BitHelpers.SetBits(attr2, palIndex, 3, 12);
            attr2 = (ushort)BitHelpers.SetBits(attr2, reusesTiles ? 1 : 0, 1, 15);
            attr1 = (ushort)BitHelpers.SetBits(attr1, affineMatrixIndex, 5, 9);

            return new AnimationChannel(game, attr0, attr1, attr2);
        }

        public static AnimationChannel CreateSoundChannel(
            Game game, 
            short soundId)
        {
            ushort attr0 = 0;
            ushort attr1 = 0;
            ushort attr2 = 0;

            attr0 = (ushort)BitHelpers.SetBits(attr0, (int)AnimationChannelType.Sound, 4, 10);

            attr1 = (ushort)soundId;

            return new AnimationChannel(game, attr0, attr1, attr2);
        }

        public static AnimationChannel CreateDisplacementVectorChannel(
            Game game,
            Vector2 displacementVector)
        {
            ushort attr0 = 0;
            ushort attr1 = 0;
            ushort attr2 = 0;

            attr0 = (ushort)BitHelpers.SetBits(attr0, (int)AnimationChannelType.DisplacementVector, 4, 10);
            attr1 = (ushort)displacementVector.X;
            attr2 = (ushort)displacementVector.Y;

            return new AnimationChannel(game, attr0, attr1, attr2);
        }

        public static AnimationChannel CreateBoxChannel(
            Game game,
            AnimationChannelType type,
            ChannelBox box)
        {
            ushort attr0 = 0;
            ushort attr1 = 0;
            ushort attr2 = 0;

            attr0 = (ushort)BitHelpers.SetBits(attr0, (int)type, 4, 10);
            attr1 = (ushort)BitHelpers.SetBits64(attr1, box.Bottom, 8, 0, SignedNumberRepresentation.TwosComplement);
            attr1 = (ushort)BitHelpers.SetBits64(attr1, box.Top, 8, 8, SignedNumberRepresentation.TwosComplement);
            attr2 = (ushort)BitHelpers.SetBits64(attr2, box.Left, 8, 0, SignedNumberRepresentation.TwosComplement);
            attr2 = (ushort)BitHelpers.SetBits64(attr2, box.Right, 8, 8, SignedNumberRepresentation.TwosComplement);

            return new AnimationChannel(game, attr0, attr1, attr2);
        }

        #endregion

        #region Serialization

        public static readonly SerializeInto<AnimationChannel> SerializeInto = (s, x) =>
        {
            GbaEngineSettings settings = s.GetRequiredSettings<GbaEngineSettings>();

            ushort v1 = s.Serialize<ushort>(x.Attribute0, name: nameof(Attribute0));
            ushort v2 = s.Serialize<ushort>(x.Attribute1, name: nameof(Attribute1));
            ushort v3 = s.Serialize<ushort>(x.Attribute2, name: nameof(Attribute2));

            return new AnimationChannel(settings.Game, v1, v2, v3);
        };

        public string ShortLog => ToString();

        public override string ToString()
        {
            switch (ChannelType)
            {
                case AnimationChannelType.None:
                    return "EMPTY";

                case AnimationChannelType.Sprite:
                    OBJ_ATTR_ObjectMode objectMode = ObjectMode;

                    switch (objectMode)
                    {
                        case OBJ_ATTR_ObjectMode.REG:
                            return $"SPRITE | X: {XPosition} Y: {YPosition} SHAPE: {SpriteShape} SIZE: {SpriteSize} OBJ: {objectMode} TILE: {TileIndex} PAL: {PalIndex} REUSE: {ReusesTiles} FLIPX: {FlipX} FLIPY: {FlipY}";

                        case OBJ_ATTR_ObjectMode.AFF:
                        case OBJ_ATTR_ObjectMode.AFF_DBL:
                            return $"SPRITE | X: {XPosition} Y: {YPosition} SHAPE: {SpriteShape} SIZE: {SpriteSize} OBJ: {objectMode} TILE: {TileIndex} PAL: {PalIndex} REUSE: {ReusesTiles} MATRIX: {AffineMatrixIndex}";

                        case OBJ_ATTR_ObjectMode.HIDE:
                        default:
                            return "SPRITE";
                    }
                
                case AnimationChannelType.Sound:
                    return $"SOUND | ID: {SoundId}";

                case AnimationChannelType.DisplacementVector:
                    Vector2 displacementVector = DisplacementVector;
                    return $"DISPLACEMENT VECTOR | X: {displacementVector.X} Y: {displacementVector.Y}";

                case AnimationChannelType.AttackBox:
                    ChannelBox attackBox = Box;
                    return $"ATTACK BOX | B: {attackBox.Bottom} T: {attackBox.Top} L: {attackBox.Left} R: {attackBox.Right}";

                case AnimationChannelType.VulnerabilityBox:
                case AnimationChannelType.VulnerabilityBox_Prototypes:
                    ChannelBox vulnerabilityBox = Box;
                    return $"VULNERABILITY BOX | B: {vulnerabilityBox.Bottom} T: {vulnerabilityBox.Top} L: {vulnerabilityBox.Left} R: {vulnerabilityBox.Right}";

                default:
                    return "UNKNOWN";
            }
        }

        #endregion
    }
}