namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Vat
    {
        public short ID { get; set; }

        public string Name { get; set; }

        public decimal Aliquot { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
