using SportsStore.Api.Models;
using SportsStore.BLL.DTO;
using SportsStore.Infrastructure.Core;

namespace SportsStore.Api.Mapper
{
    public class OrderCreationRequestModelProfile : AutoMapperProfile
    {
        public OrderCreationRequestModelProfile()
        {
            CreateMap<OrderCreationRequestModel, OrderDto>()
                .ForMember(
                    dest => dest.Lines,
                    opt => opt.MapFrom(
                        src => src.CartLines));
        }
    }
}