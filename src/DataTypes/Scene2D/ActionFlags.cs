using System;

namespace BinarySerializer.Onyx.Gba
{
    [Flags]
    public enum ActionFlags : byte
    {
        None = 0,
        FlipX = 1 << 0,
        FlipY = 1 << 1,
    }
}