using SportsStore.Infrastructure.Core;
using SportsStore.BLL.DTO;
using SportsStore.DAL.Entities;

namespace SportsStore.BLL.Mapper
{
    public class ProductProfile : AutoMapperProfile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>();
        }
    }
}
