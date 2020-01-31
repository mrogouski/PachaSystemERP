namespace PachaSystem.Data.Models
{
    using PachaSystem.Data.Enums;
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public bool Discontinued { get; set; }
        public int ID { get; set; }

        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual MeasureUnit MeasureUnit { get; set; }
        public int MeasureUnitID { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public int? ProductCategoryID { get; set; }
        public ProductType ProductTypeID { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Vat Vat { get; set; }
        public int? VatID { get; set; }
    }
}