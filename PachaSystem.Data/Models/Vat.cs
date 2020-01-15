namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Vat
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public decimal Aliquot { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}