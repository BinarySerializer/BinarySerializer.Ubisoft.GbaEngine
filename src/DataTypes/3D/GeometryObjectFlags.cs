using System;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    [Flags]
    public enum GeometryObjectFlags : byte
    {
        None = 0,
        IsTextured = 1 << 1,
    }
}