namespace PachaSystem.Data.Models
{
    using System.Collections.Generic;

    public class Vat
    {
        public Vat()
        {
            Items = new HashSet<Product>();
        }

        public int ID { get; set; }

        public string Description { get; set; }

        public decimal Aliquot { get; set; }

        public virtual ICollection<Product> Items { get; set; }
    }
}