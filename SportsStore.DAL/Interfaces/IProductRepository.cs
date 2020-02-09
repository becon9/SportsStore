using System.Collections.Generic;
using System.Linq;
using SportsStore.DAL.Entities;

namespace SportsStore.DAL.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);

        Product DeleteProduct(int productId);
    }
}