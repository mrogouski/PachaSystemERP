namespace PachaSystem.Data.Models
{
    using System.Collections.Generic;

    public class FiscalConditionType
    {
        public FiscalConditionType()
        {
            Customers = new HashSet<Customer>();
        }

        public int ID { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}