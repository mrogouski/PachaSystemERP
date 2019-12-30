namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tribute
    {
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
