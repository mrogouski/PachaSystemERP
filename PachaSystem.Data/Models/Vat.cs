namespace PachaSystem.Data.Models
{
    using System.Collections.Generic;

    public class Vat
    {
        public Vat()
        {
            Items = new HashSet<Item>();
        }

        public int ID { get; set; }

        public string Description { get; set; }

        public decimal Aliquot { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}