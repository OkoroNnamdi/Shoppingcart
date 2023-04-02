using Microsoft.EntityFrameworkCore;
using ShoppingChart.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingChart.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbset;
        public Repository( ApplicationDbContext context )
        {
            _context = context;
            _dbset = _context.Set<T>();
            
        }

        public void Add(T entity)
        {
            _dbset .Add( entity );  
        }

        public void Delete(T entity)
        {
            _dbset.Remove (  entity );
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbset.RemoveRange ( entities );
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbset;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.ToList ();
        }
        
        public T GetT(Expression<Func<T, bool>> predicate, string? includeProperties = null)
        {
            IQueryable<T> query = _dbset;
            query = query.Where(predicate);
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();


        }
    }
}
