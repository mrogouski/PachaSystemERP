using System.Collections.Generic;

namespace PachaSystem.Data.Models
{
    public class MeasureUnit
    {
        public MeasureUnit()
        {
            Items = new HashSet<Product>();
        }

        public int ID { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Product> Items { get; set; }
    }
}