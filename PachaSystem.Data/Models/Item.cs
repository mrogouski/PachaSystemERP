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

        public int? VatID { get; set; }

        public int? ItemCategoryID { get; set; }

        public int MeasureUnitID { get; set; }

        public bool Discontinued { get; set; }

        public virtual Vat Vat { get; set; }

        public virtual ItemCategory ItemCategory { get; set; }

        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }

        public virtual MeasureUnit MeasureUnit { get; set; }
    }
}
