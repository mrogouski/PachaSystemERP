// <copyright file="IUnitOfWork.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Helpers
{
    using PachaSystem.Data.Models;
    using PachaSystem.Data.Repositories;
    using System;

    public interface IUnitOfWork : IDisposable
    {
        Repository<ProductCategory> ItemCategories { get; }

        Repository<TributeCategory> TributeCategories { get; }

        Repository<Customer> Customers { get; }

        InvoiceRepository Invoices { get; }

        Repository<InvoiceDetails> InvoiceDetails { get; }

        ItemRepository Items { get; }

        Repository<InvoiceType> InvoiceTypes { get; }

        Repository<ConceptType> ConceptTypes { get; }

        Repository<Vat> Vat { get; }

        Repository<DocumentType> DocumentTypes { get; }

        Repository<CurrencyType> CurrencyTypes { get; }

        Repository<FiscalCondition> FiscalConditionTypes { get; }

        Repository<Tribute> Tributes { get; }

        Repository<MeasureUnit> MeasureUnit { get; }

        void SaveChanges();
    }
}