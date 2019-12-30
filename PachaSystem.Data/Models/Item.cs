namespace PachaSystem.Data.Models
{
    using PachaSystem.Data.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Item
    {
        public int ID { get; set; }

        public ItemType ItemTypeID { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public short VatID { get; set; }

        public int? CategoryID { get; set; }

        public bool Discontinued { get; set; }

        public virtual Vat Vat { get; set; }

        public virtual ItemCategory Category { get; set; }

        public virtual ICollection<ReceiptDetails> ReceiptDetails { get; set; }
    }
}
