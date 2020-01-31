using PachaSystem.Data.Helpers;
using PachaSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PachaSystem.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private PachaSystemContext _context;

        public ProductRepository(PachaSystemContext context)
        {
            _context = context;
        }

        public void Add(Product entity)
        {
            if (entity != null)
            {
                _context.Products.Add(entity);
            }
        }

        public Product Find(int id)
        {
            return _context.Products.Find(id);
        }

        public Product Get(Expression<Func<Product, bool>> expression = null)
        {
            return _context.Products.Where(expression).Include(x => x.Vat).FirstOrDefault();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetAll(Expression<Func<Product, bool>> expression)
        {
            return _context.Products.Where(expression).ToList();
        }

        public void Remove(Product entity)
        {
            if (entity != null)
            {
                _context.Products.Remove(entity);
            }
        }
    }
}