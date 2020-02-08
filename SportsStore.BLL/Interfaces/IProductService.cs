using System.Collections.Generic;
using System.Linq;
using SportsStore.BLL.DTO;

namespace SportsStore.BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> Products { get; }
        void SaveProduct(ProductDto productDto);

        ProductDto DeleteProduct(int productId);
    }
}