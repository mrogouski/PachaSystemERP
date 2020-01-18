namespace PachaSystem.Data.Models
{
    using System.Collections.Generic;

    public class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int ID { get; set; }

        public string Code { get; set; }

        public string BusinessName { get; set; }

        public int DocumentTypeID { get; set; }

        public long DocumentNumber { get; set; }

        public int FiscalConditionTypeID { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual DocumentType DocumentType { get; set; }

        public virtual FiscalConditionType FiscalConditionType { get; set; }
    }
}