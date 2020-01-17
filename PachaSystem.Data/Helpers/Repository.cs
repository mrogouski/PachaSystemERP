namespace PachaSystem.Data.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private PachaSystemContext _context;

        public Repository(PachaSystemContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression = null)
        {
            return _context.Set<TEntity>().Where(expression).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression != null)
            {
                return _context.Set<TEntity>().Where(expression).ToList();
            }
            else
            {
                return _context.Set<TEntity>().ToList();
            }
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}