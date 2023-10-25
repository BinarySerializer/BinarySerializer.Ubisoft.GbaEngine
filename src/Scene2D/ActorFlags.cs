using System;

namespace BinarySerializer.Onyx.Gba
{
    [Flags]
    public enum ActorFlags : byte
    {
        None = 0,               // In-game flags:
        Flag0 = 1 << 0,         // Flag 0
        Flag1 = 1 << 1,         // Flag 1
        Flag2 = 1 << 2,         // Flag 2
        Flag3 = 1 << 3,         // Flag 4
        Flag4 = 1 << 4,         // Flag 5
        Flag5 = 1 << 5,         // Flag 6
        AgainstCaptor = 1 << 6, // Flag 7
        RecieveDamage = 1 << 7, // Flag 8
    }
}