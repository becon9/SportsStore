using System.Collections.Generic;
using SportsStore.DAL.Entities;

namespace SportsStore.DAL.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IList<Product> GetPaged(int page, int limit, string category = null);
        IList<string> GetCategories();
    }
}