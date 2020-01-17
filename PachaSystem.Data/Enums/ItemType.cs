using System;

namespace PachaSystem.Data.Enums
{
    [Flags]
    public enum ItemType
    {
        Product = 1,
        Service = 2,
        Both = 4
    }
}