using SportsStore.BLL.DTO;
using System.Collections.Generic;

namespace SportsStore.BLL.Interfaces
{
    public interface IProductService : IService<ProductDto>
    {
        IEnumerable<ProductDto> GetProductsWithImages();
    }
}