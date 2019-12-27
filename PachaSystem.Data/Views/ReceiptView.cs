using PachaSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PachaSystem.Data.Views
{
    public class ReceiptView
    {
        /* Datos del Comprobante */
        public int ReceiptID { get; set; }

        public int ReceiptTypeID { get; set; }

        public int PointOfSale { get; set; }

        public int ReceiptNumber { get; set; }

        public string Cae { get; set; }

        public DateTime CaeExpirationDate { get; set; }

        public DateTime ReceiptDate { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal NetAmountNotTaxed { get; set; }

        public decimal NetAmount { get; set; }

        public decimal ExemptAmount { get; set; }

        public decimal TotalAmountTax { get; set; }

        public decimal TotalAmountVat { get; set; }

        public DateTime? ServiceStartDate { get; set; }

        public DateTime? ServiceEndingDate { get; set; }

        public DateTime? PaymentExpirationDate { get; set; }
        /* Datos del Cliente */
        public string BusinessName { get; set; }

        public string DocumentNumber { get; set; }

        public string FiscalCondition { get; set; }

        public string Address { get; set; }

        /* Detalle del Comprobante */
        public int ItemQuantity { get; set; }

        public decimal TaxBase { get; set; }

        public decimal Subtotal { get; set; }

        public decimal AmountVat { get; set; }
        /* Datos del Producto */
        public IEnumerable<Producto> Product { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public string VatType { get; set; }

        public decimal VatAliquot { get; set; }
    }
}
