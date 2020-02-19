using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SportsStore.DAL.Context;
using SportsStore.DAL.Entities;
using SportsStore.DAL.Repositories.Interfaces;

namespace SportsStore.DAL.Repositories.Implementation
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public IList<Product> GetPaged(int page, int limit, string category = null)
        {
            IQueryable<Product> query = _context.Products;
            query = query.Where(p => category == null || p.Category == category)
                .Skip((page - 1) * limit)
                .Take(limit);

            return query.ToList();
        }

        public IList<string> GetCategories()
        {
            IQueryable<string> query = _context.Products
                .Select(product => product.Category)
                .Distinct();

            return query.ToList();
        }
    }
}