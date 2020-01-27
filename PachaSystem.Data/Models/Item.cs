namespace PachaSystem.Data.Models
{
    using PachaSystem.Data.Enums;
    using System.Collections.Generic;

    public class Item
    {
        public Item()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        public int ID { get; set; }

        public ItemType ItemTypeID { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int? VatID { get; set; }

        public decimal FinalPrice { get; set; }

        public int? ItemCategoryID { get; set; }

        public int MeasureUnitID { get; set; }

        public bool Discontinued { get; set; }

        public virtual Vat Vat { get; set; }

        public virtual ItemCategory ItemCategory { get; set; }

        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }

        public virtual MeasureUnit MeasureUnit { get; set; }
    }
}