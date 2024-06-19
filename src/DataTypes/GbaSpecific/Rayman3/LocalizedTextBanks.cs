namespace BinarySerializer.Ubisoft.GbaEngine.Rayman3
{
    public class LocalizedTextBanks : BinarySerializable
    {
        public int Pre_LanguagesCount { get; set; }
        public int[] Pre_TextBanksCounts { get; set; }

        public Pointer<Pointer<TextBank>[]>[] TextBanks { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            TextBanks = s.SerializePointerArray<Pointer<TextBank>[]>(TextBanks, Pre_LanguagesCount, name: nameof(TextBanks));

            foreach (Pointer<Pointer<TextBank>[]> langPointer in TextBanks)
            {
                langPointer.ResolvePointerArray(s, Pre_TextBanksCounts.Length);

                for (int i = 0; i < langPointer.Value!.Length; i++)
                {
                    langPointer.Value[i].ResolveObject(s, x => x.Pre_TextsCount = Pre_TextBanksCounts[i]);
                }
            }
        }
    }
}
