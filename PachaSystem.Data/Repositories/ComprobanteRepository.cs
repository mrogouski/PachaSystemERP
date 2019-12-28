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

    public class ReceiptRepository : IRepository<Receipt>
    {
        private PachaSystemContext _context;

        public ReceiptRepository(PachaSystemContext context)
        {
            _context = context;
        }

        public void Add(Receipt entidad)
        {
            _context.Comprobante.Add(entidad);
        }

        public Receipt Get(Expression<Func<Receipt, bool>> filtro)
        {
            var query = (from c in _context.Comprobante
                         join dc in _context.DetalleComprobante on c.ID equals dc.ReceiptID
                         join p in _context.Producto on dc.ItemID equals p.ID
                         join i in _context.Iva on p.VatID equals i.ID
                         //join dt in _context.DetalleTributo on c.ID equals dt.ComprobanteID
                         //join t in _context.Tributo on dt.TributoID equals t.ID
                         //join ct in _context.CategoriaTributo on t.CategoriaTributoID equals ct.ID
                         join client in _context.Cliente on c.clientID equals client.ID
                         select c)
                         .Where(filtro)
                         .FirstOrDefault();
            return query;
        }

        public IEnumerable<Receipt> GetAll(Expression<Func<Receipt, bool>> filtro)
        {
            return _context.Comprobante.Where(filtro).ToList();
        }

        public void Remove(Receipt entidad)
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
