using System.Collections.Generic;

namespace PachaSystem.Data.Models
{
    public class MeasureUnit
    {
        public MeasureUnit()
        {
            Items = new HashSet<Item>();
        }

        public int ID { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}