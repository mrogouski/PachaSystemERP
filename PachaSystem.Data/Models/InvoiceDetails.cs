// <copyright file="DetalleComprobante.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Models
{
    public class InvoiceDetails
    {
        public int InvoiceID { get; set; }

        public int ProductID { get; set; }

        public string ItemDescription
        {
            get
            {
                if (Product == null)
                {
                    return string.Empty;
                }

                return Product.Description;
            }
        }

        public int Quantity { get; set; }

        public decimal TaxBase { get; set; }

        public decimal Subtotal { get; set; }

        public decimal VatAliquot { get; set; }

        public decimal VatAmount { get; set; }

        public virtual Invoice Invoice { get; set; }

        public Product Product { get; set; }
    }
}