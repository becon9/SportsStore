using SportsStore.Infrastructure.Core;
using SportsStore.BLL.DTO;
using SportsStore.DAL.Entities;

namespace SportsStore.BLL.Mapper
{
    public class OrderProfile : AutoMapperProfile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();

            CreateMap<OrderDto, Order>();
        }
    }
}
