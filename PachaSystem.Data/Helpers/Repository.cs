namespace PachaSystem.Data.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private PachaSystemContext _context;

        public Repository(PachaSystemContext context)
        {
            _context = context;
        }

        public void Agregar(TEntity entidad)
        {
            _context.Set<TEntity>().Add(entidad);
        }

        public TEntity Obtener(Expression<Func<TEntity, bool>> filtro = null)
        {
            if (filtro == null)
            {
                return _context.Set<TEntity>().FirstOrDefault();
            }
            else
            {
                return _context.Set<TEntity>().Where(filtro).FirstOrDefault();
            }
        }

        public IEnumerable<TEntity> ObtenerTodos(Expression<Func<TEntity, bool>> filtro = null)
        {
            if (filtro == null)
            {
                return _context.Set<TEntity>().ToList();
            }
            else
            {
                return _context.Set<TEntity>().Where(filtro).ToList();
            }
        }

        public void Remover(TEntity entidad)
        {
            _context.Set<TEntity>().Remove(entidad);
        }
    }
}
