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
                         join ci in _context.Iva on p.IvaID equals ci.ID
                         join dt in _context.DetalleTributo on c.ID equals dt.ComprobanteID
                         join t in _context.Tributo on dt.TributoID equals t.ID
                         join ct in _context.CategoriaTributo on t.CategoriaTributoID equals ct.ID
                         join client in _context.Cliente on c.ClienteID equals client.ID
                         select c)
                         .Where(filtro)
                         .FirstOrDefault();
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
