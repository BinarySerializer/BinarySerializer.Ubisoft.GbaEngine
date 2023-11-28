namespace BinarySerializer.Onyx.Gba
{
    public class SoundResource : BinarySerializable
    {
        public SoundBank Pre_SoundBank { get; set; }

        public ushort Id { get; set; } // Unused - same as SongTableIndex
        public ResourceType Type { get; set; }

        public ushort SongTableIndex { get; set; }
        public bool Flag0 { get; set; } // Loop?
        public bool Flag1 { get; set; } // True for music, false for sfx?

        public int ResourceIdsOffset { get; set; }
        public byte ResourceIdsCount { get; set; }

        public ushort[] ResourceIds { get; set; }
        public byte[] ResourceIdConditions { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Id = s.Serialize<ushort>(Id, name: nameof(Id));
            Type = s.Serialize<ResourceType>(Type, name: nameof(Type));

            switch (Type)
            {
                case ResourceType.Song:
                    SongTableIndex = s.Serialize<ushort>(SongTableIndex, name: nameof(SongTableIndex));
                    s.DoBits<byte>(b =>
                    {
                        Flag0 = b.SerializeBits<bool>(Flag0, 1, name: nameof(Flag0));
                        Flag1 = b.SerializeBits<bool>(Flag1, 1, name: nameof(Flag1));
                        b.SerializePadding(6, logIfNotNull: true);
                    });
                    s.SerializePadding(1, logIfNotNull: true);
                    break;

                case ResourceType.Switch or ResourceType.Random:
                    ResourceIdsOffset = s.Serialize<int>(ResourceIdsOffset, name: nameof(ResourceIdsOffset));
                    ResourceIdsCount = s.Serialize<byte>(ResourceIdsCount, name: nameof(ResourceIdsCount));

                    s.DoAt(Pre_SoundBank.DataBufferPointer + ResourceIdsOffset, () =>
                    {
                        ResourceIds = s.SerializeArray<ushort>(ResourceIds, ResourceIdsCount, name: nameof(ResourceIds));
                        ResourceIdConditions = s.SerializeArray<byte>(ResourceIdConditions, ResourceIdsCount, name: nameof(ResourceIdConditions));
                    });
                    break;
                
                default:
                    throw new BinarySerializableException(this, $"Invalid resource type {Type}");
            }
        }

        public enum ResourceType : ushort
        {
            Song = 1,
            Switch = 2, // Unused in Rayman 3
            Random = 3,
        }
    }
}