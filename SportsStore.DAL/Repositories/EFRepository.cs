using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SportsStore.DAL.Context;
using SportsStore.DAL.Interfaces;

namespace SportsStore.DAL.Repositories
{
    public abstract class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().AsEnumerable();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().AsEnumerable().Where(predicate);
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public TEntity Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();

            return item;
        }
    }
}
