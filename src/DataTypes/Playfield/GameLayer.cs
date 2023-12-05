namespace BinarySerializer.Onyx.Gba
{
    public class GameLayer : Resource
    {
        // Header
        public GameLayerType Type { get; set; }
        public bool IsCompressed { get; set; }
        public byte Byte_02 { get; set; } // Unused in Rayman 3
        public byte Byte_03 { get; set; } // Unused in Rayman 3
        public ushort Width { get; set; }
        public ushort Height { get; set; }

        // Layer
        public TileLayer TileLayer { get; set; }
        public PhysicalLayer PhysicalLayer { get; set; }
        public RotscaleLayerMode7 RotscaleLayerMode7 { get; set; }
        public TextLayerMode7 TextLayerMode7 { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            // Serialize header
            Type = s.Serialize<GameLayerType>(Type, name: nameof(Type));
            IsCompressed = s.Serialize<bool>(IsCompressed, name: nameof(IsCompressed));
            Byte_02 = s.Serialize<byte>(Byte_02, name: nameof(Byte_02));
            Byte_03 = s.Serialize<byte>(Byte_03, name: nameof(Byte_03));
            Width = s.Serialize<ushort>(Width, name: nameof(Width));
            Height = s.Serialize<ushort>(Height, name: nameof(Height));

            // Serialize layer
            if (Type == GameLayerType.TileLayer)
                TileLayer = s.SerializeObject<TileLayer>(TileLayer, x => x.Pre_GameLayer = this, name: nameof(TileLayer));
            else if (Type == GameLayerType.PhysicalLayer)
                PhysicalLayer = s.SerializeObject<PhysicalLayer>(PhysicalLayer, x => x.Pre_GameLayer = this, name: nameof(PhysicalLayer));
            else if (Type == GameLayerType.RotscaleLayerMode7)
                RotscaleLayerMode7 = s.SerializeObject<RotscaleLayerMode7>(RotscaleLayerMode7, x => x.Pre_GameLayer = this, name: nameof(RotscaleLayerMode7));
            else if (Type == GameLayerType.TextLayerMode7)
                TextLayerMode7 = s.SerializeObject<TextLayerMode7>(TextLayerMode7, name: nameof(TextLayerMode7));
            else
                throw new BinarySerializableException(this, $"Undefined game layer type {Type}");
        }
    }
}