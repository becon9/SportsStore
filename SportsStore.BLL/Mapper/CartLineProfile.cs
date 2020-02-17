using SportsService.Infrastructure.Core;
using SportsStore.BLL.DTO;
using SportsStore.DAL.Entities;

namespace SportsStore.BLL.Mapper
{
    public class CartLineProfile : AutoMapperProfile
    {
        public CartLineProfile()
        {
            CreateMap<CartLine, CartLineDto>();

            CreateMap<CartLineDto, CartLine>();
        }
    }
}
