﻿// <copyright file="Comprobante.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Receipt
    {
        public Receipt()
        {
            ReceiptDetails = new HashSet<ReceiptDetails>();
        }

        public int ID { get; set; }

        public int ReceiptTypeID { get; set; }

        public int ConceptTypeID { get; set; }

        public int PointOfSale { get; set; }

        public int ReceiptNumber { get; set; }

        public string Cae { get; set; }

        public DateTime CaeExpirationDate { get; set; }

        public DateTime ReceiptDate { get; set; }

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

        public int clientID { get; set; }

        public virtual Cliente Client { get; set; }

        public virtual ComprobanteAsociado AssociatedReceipt { get; set; }

        public virtual ICollection<ReceiptDetails> ReceiptDetails { get; set; }

        public virtual TipoConcepto ConceptType { get; set; }

        public virtual TipoComprobante ReceiptType { get; set; }

        public virtual TipoMoneda CurrencyType { get; set; }

        public virtual ICollection<DetalleTributo> TributeDetails { get; set; }
    }
}