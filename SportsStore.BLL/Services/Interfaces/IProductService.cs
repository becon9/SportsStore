using SportsStore.BLL.DTO;
using System.Collections.Generic;

namespace SportsStore.BLL.Services.Interfaces
{
    public interface IProductService : IService<ProductDto>
    {
        IList<ProductDto> GetProductsWithImages();

        IList<string> GetCategories();

        IList<ProductDto> GetPaged(int page, int limit, string category = null, string searchQuery = null);

        IList<ProductDto> GetAll(string category);
    }
}