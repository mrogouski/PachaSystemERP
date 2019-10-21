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

    public class DetalleComprobanteRepository : IRepository<DetalleComprobante>
    {
        private PachaSystemContext _context;

        public DetalleComprobanteRepository(PachaSystemContext context)
        {
            _context = context;
        }

        public void Agregar(DetalleComprobante entidad)
        {
            _context.DetalleComprobante.Add(entidad);
        }

        public DetalleComprobante Obtener(Expression<Func<DetalleComprobante, bool>> filtro)
        {
            return _context.DetalleComprobante.Where(filtro).Include(x => x.Producto).FirstOrDefault();
        }

        public IEnumerable<DetalleComprobante> ObtenerTodos(Expression<Func<DetalleComprobante, bool>> filtro)
        {
            return _context.DetalleComprobante.Where(filtro).Include(x => x.Producto).ToList();
        }

        public void Remover(DetalleComprobante entidad)
        {
            _context.DetalleComprobante.Remove(entidad);
        }
    }
}
