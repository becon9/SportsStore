using System.Linq;
using SportsStore.DAL.Entities;

namespace SportsStore.DAL.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        void SaveProduct(Product product);

        Product DeleteProduct(int productId);
    }
}