namespace BinarySerializer.Onyx.Gba
{
    public class TextLayerMode7 : BinarySerializable
    {
        public byte LayerId { get; set; }
        public bool HasAlphaBlending { get; set; }
        public byte AlphaCoeff { get; set; }
        public byte BackgroundSize { get; set; }
        public int Int_0C { get; set; }
        public short Short_10 { get; set; }
        public short Short_12 { get; set; }
        public Vector2 MapDimensions { get; set; }
        public byte[] Bytes_18 { get; set; } // Unused in Rayman 3
        public short Short_1A { get; set; }
        public byte MapBlock { get; set; }
        public byte Priority { get; set; }
        public byte Byte_1E { get; set; }
        public bool Is8Bit { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            LayerId = s.Serialize<byte>(LayerId, name: nameof(LayerId));
            HasAlphaBlending = s.Serialize<bool>(HasAlphaBlending, name: nameof(HasAlphaBlending));
            AlphaCoeff = s.Serialize<byte>(AlphaCoeff, name: nameof(AlphaCoeff));
            BackgroundSize = s.Serialize<byte>(BackgroundSize, name: nameof(BackgroundSize));
            Int_0C = s.Serialize<int>(Int_0C, name: nameof(Int_0C));
            Short_10 = s.Serialize<short>(Short_10, name: nameof(Short_10));
            Short_12 = s.Serialize<short>(Short_12, name: nameof(Short_12));
            MapDimensions = s.SerializeObject<Vector2>(MapDimensions, name: nameof(MapDimensions));
            Bytes_18 = s.SerializeArray<byte>(Bytes_18, 2, name: nameof(Bytes_18));
            Short_1A = s.Serialize<short>(Short_1A, name: nameof(Short_1A));
            MapBlock = s.Serialize<byte>(MapBlock, name: nameof(MapBlock));
            Priority = s.Serialize<byte>(Priority, name: nameof(Priority));
            Byte_1E = s.Serialize<byte>(Byte_1E, name: nameof(Byte_1E));
            Is8Bit = s.Serialize<bool>(Is8Bit, name: nameof(Is8Bit));
        }
    }
}