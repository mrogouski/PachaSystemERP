namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvoiceType
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public string Class { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
