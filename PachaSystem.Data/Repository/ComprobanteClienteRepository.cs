namespace PachaSystem.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using PachaSystem.Data.Helpers;
    using PachaSystem.Data.Models;

    public class ComprobanteClienteRepository : IRepository<ComprobanteCliente>
    {
        private PachaSystemContext _context;

        public ComprobanteClienteRepository(PachaSystemContext context)
        {
            _context = context;
        }

        public void Agregar(ComprobanteCliente entidad)
        {
            _context.ComprobanteCliente.Add(entidad);
        }

        public ComprobanteCliente Obtener(Expression<Func<ComprobanteCliente, bool>> filtro)
        {
            return _context.ComprobanteCliente.Where(filtro).FirstOrDefault();
        }

        public IEnumerable<ComprobanteCliente> ObtenerTodos(Expression<Func<ComprobanteCliente, bool>> filtro)
        {
            return _context.ComprobanteCliente.Where(filtro).ToList();
        }

        public void Remover(ComprobanteCliente entidad)
        {
            _context.ComprobanteCliente.Remove(entidad);
        }

        public void AgregarClientePorID(int id)
        {
            ComprobanteCliente comprobanteCliente = new ComprobanteCliente();
            comprobanteCliente.ClienteID = id;
            comprobanteCliente.PorcentajeTitularidad = 100;
            _context.ComprobanteCliente.Add(comprobanteCliente);
        }
    }
}
