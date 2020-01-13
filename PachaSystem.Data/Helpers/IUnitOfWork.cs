// <copyright file="IUnitOfWork.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PachaSystem.Data.Models;
    using PachaSystem.Data.Repositories;

    public interface IUnitOfWork : IDisposable
    {
        Repository<ItemCategory> ItemCategories { get; }

        Repository<TributeCategory> TributeCategories { get; }

        Repository<Client> Clients { get; }

        InvoiceRepository Invoices { get; }

        Repository<InvoiceDetails> InvoiceDetails { get; }

        ItemRepository Items { get; }

        Repository<InvoiceType> InvoiceTypes { get; }

        Repository<ConceptType> ConceptTypes { get; }

        Repository<Vat> Vat { get; }

        Repository<DocumentType> DocumentTypes { get; }

        Repository<CurrencyType> CurrencyTypes { get; }

        Repository<FiscalConditionType> FiscalConditionTypes { get; }

        Repository<Tribute> Tributes { get; }

        InvoiceViewRepository ReceiptView { get; }

        void SaveChanges();
    }
}
