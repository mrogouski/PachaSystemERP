namespace PachaSystem.Data.Models
{
    using System.Collections.Generic;

    public class InvoiceType
    {
        public InvoiceType()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int ID { get; set; }

        public string Description { get; set; }

        public string Class { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}