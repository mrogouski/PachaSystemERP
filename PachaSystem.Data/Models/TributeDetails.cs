using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PachaSystem.Data.Models
{
    public class TributeDetails
    {
        public int ReceiptID { get; set; }

        public int TributeID { get; set; }

        public int Amount { get; set; }

        public virtual Tribute Tribute { get; set; }
    }
}
