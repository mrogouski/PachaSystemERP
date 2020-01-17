namespace PachaSystem.Data.Models
{
    using System.Collections.Generic;

    public class ItemCategory
    {
        public ItemCategory()
        {
            Items = new HashSet<Item>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}