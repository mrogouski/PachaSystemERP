using System.Collections.Generic;

namespace PachaSystem.Data.Models
{
    public class ConceptType
    {
        public ConceptType()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}