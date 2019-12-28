using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
