using System.Collections.Generic;

namespace PachaSystem.Data.Models
{
    public class CurrencyType
    {
        public CurrencyType()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int ID { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; } 
    }
}