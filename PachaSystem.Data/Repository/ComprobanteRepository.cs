// <copyright file="ComprobanteRepository.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Repository
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
                         join ci in _context.TipoCondicionIva on p.TipoCondicionIvaID equals ci.ID
                         join t in _context.TipoTributo on p.TipoTributoID equals t.ID
                         join ct in _context.CategoriaTributo on t.CategoriaTributoID equals ct.ID
                         join cc in _context.ComprobanteCliente on c.ID equals cc.ComprobanteID
                         join client in _context.Cliente on cc.ClienteID equals client.ID
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
