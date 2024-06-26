﻿using System;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    [Flags]
    public enum GbaInput : ushort
    {
        None = 0,
        A = 1 << 0,
        B = 1 << 1,
        Select = 1 << 2,
        Start = 1 << 3,
        Right = 1 << 4,
        Left = 1 << 5,
        Up = 1 << 6,
        Down = 1 << 7,
        R = 1 << 8,
        L = 1 << 9,
        Valid = 0xFC00,
    }
}