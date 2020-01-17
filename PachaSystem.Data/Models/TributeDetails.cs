namespace PachaSystem.Data.Models
{
    public class TributeDetails
    {
        public int InvoiceID { get; set; }

        public int TributeID { get; set; }

        public decimal Aliquot { get; set; }

        public decimal Amount { get; set; }

        public virtual Tribute Tribute { get; set; }
    }
}