using System;

namespace PachaSystem.Data.Enums
{
    [Flags]
    public enum ProductType
    {
        Goods = 1,
        Services = 2,
        Both = 4
    }
}