using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SportsStore.DAL.Context;
using SportsStore.DAL.Repositories.Interfaces;

namespace SportsStore.DAL.Repositories.Implementation
{
    public class EfRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public EfRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual T GetById(int id, bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            return query.FirstOrDefault(entity => entity.Id == id);
        }

        public virtual IList<T> GetAll(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, 
            bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }

        public int Count()
        {
            return _context.Set<T>().AsNoTracking().Count();
        }

        public virtual void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }
        public virtual void Update(T item)
        {
            _context.Set<T>().Update(item);
            _context.SaveChanges();
        }
        public virtual void Remove(T item)
        {
            _context.Set<T>().Attach(item);
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }
    }
}
