namespace PachaSystem.Data.Models
{
    using System.Collections.Generic;

    public class TributeCategory
    {
        public TributeCategory()
        {
            Tributes = new HashSet<Tribute>();
        }

        public short ID { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Tribute> Tributes { get; set; }
    }
}