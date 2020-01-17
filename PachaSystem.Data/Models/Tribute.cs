namespace PachaSystem.Data.Models
{
    using System.Collections.Generic;

    public class Tribute
    {
        public Tribute()
        {
            TributeDetails = new HashSet<TributeDetails>();
        }

        public int ID { get; set; }

        public string Description { get; set; }

        public decimal TaxBase { get; set; }

        public decimal Aliquot { get; set; }

        public bool IsFixedAmount { get; set; }

        public short TributeCategoryID { get; set; }

        public virtual IEnumerable<TributeDetails> TributeDetails { get; set; }

        public virtual TributeCategory TributeCategory { get; set; }
    }
}