using System;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    [Flags]
    public enum ActionFlags : byte
    {
        None = 0,
        FlipX = 1 << 0,
        FlipY = 1 << 1,
    }
}