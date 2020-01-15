namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Customer
    {
        public int ID { get; set; }

        public string BusinessName { get; set; }

        public int DocumentTypeID { get; set; }

        public long DocumentNumber { get; set; }

        public int FiscalConditionTypeID { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual DocumentType DocumentType { get; set; }

        public virtual FiscalConditionType FiscalConditionType { get; set; }
    }
}
