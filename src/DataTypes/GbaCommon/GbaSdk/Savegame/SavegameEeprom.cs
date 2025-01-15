namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class SavegameEeprom<T> : BinarySerializable
        where T: BinarySerializable, new()
    {
        public int Pre_Size { get; set; }

        public T SaveSlot { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Checksum16Processor checksumProcessor = null;

            s.SerializeMagic<uint>(0x224455);

            checksumProcessor = new Checksum16Processor(invertBits: true) { CalculatedValue = ~0x4455 };
            checksumProcessor.Serialize<ushort>(s, name: "SaveSlotChecksum");

            s.SerializePadding(2); // Always 0x100, but seems unused? Not part of the checksum calculation.

            // All remaining data is part of the checksum calculation on GBA
            s.DoProcessed(checksumProcessor, () =>
            {
                long offset = s.CurrentFileOffset;
                SaveSlot = s.SerializeObject<T>(SaveSlot, name: nameof(SaveSlot));

                if (s.CurrentFileOffset - offset < Pre_Size)
                    s.SerializePadding(Pre_Size - (s.CurrentFileOffset - offset), logIfNotNull: true);
            });
        }
    }
}