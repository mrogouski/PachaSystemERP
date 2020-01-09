namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AssociatedInvoice
    {
        public int ID { get; set; }

        public int InvoiceTypeID { get; set; }

        public int PointOfSale { get; set; }

        public long InvoiceNumber { get; set; }

        public long Cuit { get; set; }

        public DateTime InvoiceDate { get; set; }

        public int InvoiceID { get; set; }

        public virtual InvoiceType InvoiceType { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
