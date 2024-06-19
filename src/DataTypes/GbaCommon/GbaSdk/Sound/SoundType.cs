namespace BinarySerializer.Ubisoft.GbaEngine
{
    // The engine supports types 0-7, but only 0 and 1 are used in Rayman 3
    public enum SoundType : byte
    {
        Music = 0,
        Sfx = 1,
    }
}