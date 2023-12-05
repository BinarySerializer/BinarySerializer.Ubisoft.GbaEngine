namespace BinarySerializer.Onyx.Gba.Rayman3
{
    public class TextBank : BinarySerializable
    {
        public int Pre_TextsCount { get; set; }

        public Text[] Texts { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Texts = s.SerializeObjectArray<Text>(Texts, Pre_TextsCount, name: nameof(Texts));
        }
    }
}