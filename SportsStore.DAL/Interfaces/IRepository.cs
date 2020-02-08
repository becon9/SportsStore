using System;
using System.Collections.Generic;
using System.Text;

namespace SportsStore.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        void Create(TEntity item);
        void Update(TEntity item);
        TEntity Remove(TEntity item);
    }
}
