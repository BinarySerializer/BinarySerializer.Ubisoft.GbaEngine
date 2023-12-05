namespace BinarySerializer.Onyx.Gba.Rayman3
{
    public class Text : BinarySerializable
    {
        public byte LinesCount { get; set; }
        public Pointer<Pointer<string>[]> Lines { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            LinesCount = s.Serialize<byte>(LinesCount, name: nameof(LinesCount));
            s.SerializePadding(3, logIfNotNull: true);
            Lines = s.SerializePointer<Pointer<string>[]>(Lines, name: nameof(Lines)).ResolvePointerArray(s, LinesCount);

            foreach (Pointer<string> linePointer in Lines.Value)
                linePointer.ResolveString(s);
        }
    }
}