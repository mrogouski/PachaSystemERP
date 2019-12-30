namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TributeCategory
    {
        public short ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Tribute> Tributes { get; set; }
    }
}
