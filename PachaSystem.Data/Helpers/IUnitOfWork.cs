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
    using PachaSystem.Data.Repository;

    public interface IUnitOfWork : IDisposable
    {
        Repository<Rubro> CategoriaProducto { get; }

        Repository<CategoriaTributo> CategoriaTributo { get; }

        Repository<Cliente> Cliente { get; }

        ComprobanteRepository Comprobante { get; }

        Repository<DetalleComprobante> DetalleComprobante { get; }

        Repository<Producto> Producto { get; }

        Repository<TipoComprobante> TipoComprobante { get; }

        Repository<TipoConcepto> TipoConcepto { get; }

        Repository<Iva> TipoCondicionIva { get; }

        Repository<TipoDocumento> TipoDocumento { get; }

        Repository<TipoMoneda> TipoMoneda { get; }

        Repository<TipoResponsable> TipoResponsable { get; }

        Repository<Tributo> TipoTributo { get; }

        void Guardar();
    }
}
