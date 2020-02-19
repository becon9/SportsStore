using System.Collections.Generic;

namespace SportsStore.BLL.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
        int Count();
    }
}
