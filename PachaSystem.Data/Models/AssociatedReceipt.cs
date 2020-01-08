namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AssociatedReceipt
    {
        public int ID { get; set; }

        public int ReceiptTypeID { get; set; }

        public int PointOfSale { get; set; }

        public string ReceiptNumber { get; set; }

        public long Cuit { get; set; }

        public DateTime ReceiptDate { get; set; }

        public int ReceiptID { get; set; }

        public virtual ReceiptType ReceiptType { get; set; }

        public virtual Invoice Receipt { get; set; }
    }
}
