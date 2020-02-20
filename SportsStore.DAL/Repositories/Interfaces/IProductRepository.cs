using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using SportsStore.DAL.Entities;

namespace SportsStore.DAL.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IList<Product> GetPaged(int page, int limit, string category = null, string searchQuery = null,
            Func<IQueryable<Product>, IIncludableQueryable<Product, object>> include = null,
            bool disableTracking = true);
        IList<string> GetCategories();
    }
}