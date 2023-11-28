namespace BinarySerializer.Onyx.Gba
{
    public class SoundEvent : BinarySerializable
    {
        public ushort Type { get; set; }

        public ushort Type1_Ushort_00 { get; set; }
        public ushort ResourceId { get; set; }
        public byte Type1_Byte_04 { get; set; }
        public bool Type1_Flag0 { get; set; } // Always false in Rayman 3
        public bool Type1_Flag1 { get; set; } // Only true for one event in Rayman 3

        public ushort Type23_Ushort_00 { get; set; } // Unused?
        public ushort Type23_Value1 { get; set; }
        public ushort Type23_Value2 { get; set; }
        public ushort Type23_Value3 { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Type = s.Serialize<ushort>(Type, name: nameof(Type));

            switch (Type)
            {
                case 1:
                    Type1_Ushort_00 = s.Serialize<ushort>(Type1_Ushort_00, name: nameof(Type1_Ushort_00));
                    ResourceId = s.Serialize<ushort>(ResourceId, name: nameof(ResourceId));
                    Type1_Byte_04 = s.Serialize<byte>(Type1_Byte_04, name: nameof(Type1_Byte_04));
                    s.DoBits<byte>(b =>
                    {
                        Type1_Flag0 = b.SerializeBits<bool>(Type1_Flag0, 1, name: nameof(Type1_Flag0));
                        Type1_Flag1 = b.SerializeBits<bool>(Type1_Flag1, 1, name: nameof(Type1_Flag1));
                        b.SerializePadding(6, logIfNotNull: true);
                    });
                    break;

                case 2:
                    Type23_Ushort_00 = s.Serialize<ushort>(Type23_Ushort_00, name: nameof(Type23_Ushort_00));
                    Type23_Value1 = s.Serialize<ushort>(Type23_Value1, name: nameof(Type23_Value1));
                    Type23_Value2 = 0xFFFF;
                    Type23_Value3 = s.Serialize<ushort>(Type23_Value3, name: nameof(Type23_Value3));
                    break;

                case 3:
                    Type23_Ushort_00 = s.Serialize<ushort>(Type23_Ushort_00, name: nameof(Type23_Ushort_00));
                    Type23_Value2 = s.Serialize<ushort>(Type23_Value2, name: nameof(Type23_Value2));
                    Type23_Value1 = s.Serialize<ushort>(Type23_Value1, name: nameof(Type23_Value1));
                    Type23_Value3 = s.Serialize<ushort>(Type23_Value3, name: nameof(Type23_Value3));
                    break;

                default:
                    throw new BinarySerializableException(this, $"Invalid event type {Type}");
            }
        }
    }
}