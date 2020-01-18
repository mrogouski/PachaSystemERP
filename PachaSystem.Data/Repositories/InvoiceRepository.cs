// <copyright file="ComprobanteRepository.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Repositories
{
    using PachaSystem.Data.Helpers;
    using PachaSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class InvoiceRepository : IRepository<Invoice>
    {
        private PachaSystemContext _context;

        public InvoiceRepository(PachaSystemContext context)
        {
            _context = context;
        }

        public void Add(Invoice entidad)
        {
            _context.Invoices.Add(entidad);
        }

        public Invoice Find(int id)
        {
            return _context.Invoices.Find(id);
        }

        public Invoice Get(Expression<Func<Invoice, bool>> filtro)
        {
            var query = (from c in _context.Invoices
                         join dc in _context.InvoiceDetails on c.ID equals dc.InvoiceID
                         join p in _context.Items on dc.ItemID equals p.ID
                         join i in _context.Vat on p.VatID equals i.ID
                         //join dt in _context.DetalleTributo on c.ID equals dt.ComprobanteID
                         //join t in _context.Tributo on dt.TributoID equals t.ID
                         //join ct in _context.CategoriaTributo on t.CategoriaTributoID equals ct.ID
                         join client in _context.Clients on c.ClientID equals client.ID
                         select c)
                         .Where(filtro)
                         .FirstOrDefault();
            return query;
        }

        public IEnumerable<Invoice> GetAll()
        {
            return _context.Invoices.ToList();
        }

        public IEnumerable<Invoice> GetAll(Expression<Func<Invoice, bool>> filtro)
        {
            return _context.Invoices.Where(filtro).ToList();
        }

        public void Remove(Invoice entidad)
        {
            _context.Invoices.Remove(entidad);
        }
    }
}