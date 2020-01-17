// <copyright file="Comprobante.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Invoice
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
            TributeDetails = new HashSet<TributeDetails>();
        }

        public int ID { get; set; }

        public int InvoiceTypeID { get; set; }

        public int ConceptTypeID { get; set; }

        public int PointOfSale { get; set; }

        public int InvoiceNumber { get; set; }

        public string Cae { get; set; }

        public DateTime CaeExpirationDate { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal NotTaxedNetAmount { get; set; }

        public decimal NetAmount { get; set; }

        public decimal ExemptAmount { get; set; }

        public decimal TributeTotalAmount { get; set; }

        public decimal VatTotalAmount { get; set; }

        public DateTime? ServiceStartDate { get; set; }

        public DateTime? ServiceFinishDate { get; set; }

        public DateTime? DueDate { get; set; }

        public int CurrencyTypeID { get; set; }

        public double CurrencyExchangeRate { get; set; }

        public int ClientID { get; set; }

        public virtual Customer Client { get; set; }

        public virtual AssociatedInvoice AssociatedReceipt { get; set; }

        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }

        public virtual ConceptType ConceptType { get; set; }

        public virtual InvoiceType InvoiceType { get; set; }

        public virtual CurrencyType CurrencyType { get; set; }

        public virtual ICollection<TributeDetails> TributeDetails { get; set; }
    }
}