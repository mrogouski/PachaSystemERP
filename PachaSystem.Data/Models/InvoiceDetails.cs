// <copyright file="DetalleComprobante.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvoiceDetails
    {
        public int InvoiceID { get; set; }

        public int ItemID { get; set; }

        public int Quantity { get; set; }

        public decimal TaxBase { get; set; }

        public decimal Subtotal { get; set; }

        public decimal VatAliquot { get; set; }

        public decimal VatAmount { get; set; }

        public virtual Invoice Invoice { get; set; }

        public Item Item { get; set; }
    }
}
