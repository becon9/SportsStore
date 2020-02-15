using SportsStore.BLL.DTO;
using System.Collections.Generic;

namespace SportsStore.BLL.Services.Interfaces
{
    public interface IProductService : IService<ProductDto>
    {
        IEnumerable<ProductDto> GetProductsWithImages();

        IEnumerable<string> GetCategories();
    }
}