﻿namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class TextLayerMode7 : BinarySerializable
    {
        public byte LayerId { get; set; }
        public bool HasAlphaBlending { get; set; }
        public byte AlphaCoeff { get; set; }
        public byte BackgroundSize { get; set; }
        public FixedPointInt32 RotationFactor { get; set; }
        public Vector2 Vector2_10 { get; set; } // Unused in Rayman 3
        public Vector2 MapDimensions { get; set; }
        public Vector2 MapPosition { get; set; } // X value is unused in Rayman 3
        public byte MapBlock { get; set; }
        public byte Priority { get; set; }
        public byte Byte_1E { get; set; } // Unused in Rayman 3 - always the same value as LayerId
        public bool Is8Bit { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            LayerId = s.Serialize<byte>(LayerId, name: nameof(LayerId));
            HasAlphaBlending = s.Serialize<bool>(HasAlphaBlending, name: nameof(HasAlphaBlending));
            AlphaCoeff = s.Serialize<byte>(AlphaCoeff, name: nameof(AlphaCoeff));
            BackgroundSize = s.Serialize<byte>(BackgroundSize, name: nameof(BackgroundSize));
            RotationFactor = s.SerializeObject<FixedPointInt32>(RotationFactor, x => x.Pre_PointPosition = 16, name: nameof(RotationFactor));
            Vector2_10 = s.SerializeObject<Vector2>(Vector2_10, name: nameof(Vector2_10));
            MapDimensions = s.SerializeObject<Vector2>(MapDimensions, name: nameof(MapDimensions));
            MapPosition = s.SerializeObject<Vector2>(MapPosition, name: nameof(MapPosition));
            MapBlock = s.Serialize<byte>(MapBlock, name: nameof(MapBlock));
            Priority = s.Serialize<byte>(Priority, name: nameof(Priority));
            Byte_1E = s.Serialize<byte>(Byte_1E, name: nameof(Byte_1E));
            Is8Bit = s.Serialize<bool>(Is8Bit, name: nameof(Is8Bit));
        }
    }
}