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
        Repository<ItemCategory> CategoriaProducto { get; }

        Repository<TributeCategory> CategoriaTributo { get; }

        Repository<Client> Cliente { get; }

        ReceiptRepository Receipt { get; }

        Repository<ReceiptDetails> DetalleComprobante { get; }

        Repository<Item> Producto { get; }

        Repository<ReceiptType> TipoComprobante { get; }

        Repository<ConceptType> TipoConcepto { get; }

        Repository<Vat> TipoCondicionIva { get; }

        Repository<DocumentType> TipoDocumento { get; }

        Repository<CurrencyType> TipoMoneda { get; }

        Repository<FiscalConditionType> TipoResponsable { get; }

        Repository<Tribute> TipoTributo { get; }

        ReceiptViewRepository ReceiptView { get; }

        void SaveChanges();
    }
}
