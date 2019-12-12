// <copyright file="ComprobanteRepository.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using PachaSystem.Data.Helpers;
    using PachaSystem.Data.Models;
    using PachaSystem.Data.Views;

    public class ComprobanteRepository : IRepository<Comprobante>
    {
        private PachaSystemContext _context;

        public ComprobanteRepository(PachaSystemContext context)
        {
            _context = context;
        }

        public void Agregar(Comprobante entidad)
        {
            _context.Comprobante.Add(entidad);
        }

        public Comprobante Obtener(Expression<Func<Comprobante, bool>> filtro)
        {
            var query = (from c in _context.Comprobante
                         join dc in _context.DetalleComprobante on c.ID equals dc.ComprobanteID
                         join p in _context.Producto on dc.ProductoID equals p.ID
                         join i in _context.Iva on p.IvaID equals i.ID
                         //join dt in _context.DetalleTributo on c.ID equals dt.ComprobanteID
                         //join t in _context.Tributo on dt.TributoID equals t.ID
                         //join ct in _context.CategoriaTributo on t.CategoriaTributoID equals ct.ID
                         join client in _context.Cliente on c.ClienteID equals client.ID
                         select c)
                         .Where(filtro)
                         .FirstOrDefault();
            return query;
        }

        public List<ComprobanteView> Obtener(int id)
        {
            var query = (from c in _context.Comprobante
                                 join dc in _context.DetalleComprobante on c.ID equals dc.ComprobanteID
                                 join p in _context.Producto on dc.ProductoID equals p.ID
                                 join i in _context.Iva on p.IvaID equals i.ID
                                 //join dt in _context.DetalleTributo on c.ID equals dt.ComprobanteID
                                 //join t in _context.Tributo on dt.TributoID equals t.ID
                                 //join ct in _context.CategoriaTributo on t.CategoriaTributoID equals ct.ID
                                 join client in _context.Cliente on c.ClienteID equals client.ID
                                 where c.ID == id
                                 select new ComprobanteView 
                                 {
                                     PuntoVenta = c.PuntoVenta,
                                     NumeroComprobante = c.NumeroComprobante,
                                     CAE = c.CAE,
                                     FechaVencimientoCAE = c.FechaVencimientoCAE,
                                     FechaComprobante = c.FechaComprobante,
                                     ImporteTotal = c.ImporteTotal,
                                     ImporteNetoNoGravado = c.ImporteNetoNoGravado,
                                     ImporteNeto = c.ImporteNeto,
                                     ImporteExento = c.ImporteExento,
                                     ImporteTotalTributo = c.ImporteTotalTributo,
                                     ImporteTotalIva = c.ImporteTotalIva,
                                     FechaInicioServicio = c.FechaInicioServicio,
                                     FechaFinalizacionServicio = c.FechaFinalizacionServicio,
                                     FechaVencimientoPago = c.FechaVencimientoPago,
                                     RazonSocial = client.RazonSocial,
                                     NumeroDocumento = client.NumeroDocumento,
                                     TipoResponsable = client.TipoResponsable.Descripcion,
                                     Domicilio = client.Domicilio,
                                     Cantidad = dc.Cantidad,
                                     BaseImponible = dc.BaseImponible,
                                     Subtotal = dc.Subtotal,
                                     ImporteIva = dc.ImporteIva,
                                     Codigo = p.Codigo,
                                     DescripcionProductoServicio = p.Descripcion,
                                     PrecioUnitario = p.PrecioUnitario,
                                     DescripcionIva = i.Descripcion,
                                     AlicuotaIva = i.Alicuota
                                 }).ToList();
            return query;
        }

        public IEnumerable<Comprobante> ObtenerTodos(Expression<Func<Comprobante, bool>> filtro)
        {
            return _context.Comprobante.Where(filtro).ToList();
        }

        public void Remover(Comprobante entidad)
        {
            _context.Comprobante.Remove(entidad);
        }

        public int ObtenerNumeroUltimoComprobante()
        {
            var query = (from c in _context.Comprobante
                         select c.ID).DefaultIfEmpty().Max();
            return query;
        }
    }
}
