namespace BinarySerializer.Onyx.Gba
{
    public class NGageSoundEvent : BinarySerializable
    {
        public bool IsValid { get; set; }

        public int Int_00 { get; set; }
        public int Int_0A { get; set; }
        public int Int_16 { get; set; }

        public bool Bool_1D { get; set; }
        public bool Bool_1E { get; set; }
        public bool Bool_1F { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            s.DoBits<int>(b =>
            {
                IsValid = b.SerializeBits<int>(IsValid ? 0 : -1, 32, name: nameof(IsValid)) != -1;

                if (!IsValid)
                    return;

                b.Position = 0;

                Int_00 = b.SerializeBits<int>(Int_00, 10, name: nameof(Int_00));
                Int_0A = b.SerializeBits<int>(Int_0A, 10, name: nameof(Int_0A));
                b.SerializePadding(2, logIfNotNull: true);
                Int_16 = b.SerializeBits<int>(Int_16, 3, name: nameof(Int_16));
                b.SerializePadding(4, logIfNotNull: true);
                Bool_1D = b.SerializeBits<bool>(Bool_1D, 1, name: nameof(Bool_1D));
                Bool_1E = b.SerializeBits<bool>(Bool_1E, 1, name: nameof(Bool_1E));
                Bool_1F = b.SerializeBits<bool>(Bool_1F, 1, name: nameof(Bool_1F));
            });
        }
    }
}