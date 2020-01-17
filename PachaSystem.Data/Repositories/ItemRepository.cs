using PachaSystem.Data.Helpers;
using PachaSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PachaSystem.Data.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private PachaSystemContext _context;

        public ItemRepository(PachaSystemContext context)
        {
            _context = context;
        }

        public void Add(Item entity)
        {
            if (entity != null)
            {
                _context.Items.Add(entity);
            }
        }

        public Item Get(Expression<Func<Item, bool>> expression = null)
        {
            return _context.Items.Where(expression).Include(x => x.Vat).FirstOrDefault();
        }

        public IEnumerable<Item> GetAll(Expression<Func<Item, bool>> expression = null)
        {
            return _context.Items.Where(expression).ToList();
        }

        public void Remove(Item entity)
        {
            if (entity != null)
            {
                _context.Items.Remove(entity);
            }
        }
    }
}