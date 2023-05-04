using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository
{
    public class Repository <T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> _DbSet;
        public Repository(ApplicationDbContext context)
        {
            _context= context;
            this._DbSet = _context.Set<T>(); // _context.Caegories == _DbSet
        }
        public void Add(T entity)
        {
            
            _DbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query = _DbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _DbSet;
            return query.ToList(); ;
        }

        public void Remove(T entity)
        {
            _DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            _DbSet.RemoveRange(entity);
        }
    }
}
