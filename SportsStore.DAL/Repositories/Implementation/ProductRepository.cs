using SportsStore.DAL.Context;
using SportsStore.DAL.Entities;
using SportsStore.DAL.Repositories.Interfaces;

namespace SportsStore.DAL.Repositories.Implementation
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}