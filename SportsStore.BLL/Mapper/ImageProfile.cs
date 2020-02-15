using SportsService.Infrastructure.Core;
using SportsStore.BLL.DTO;
using SportsStore.DAL.Entities;

namespace SportsStore.BLL.Mapper
{
    public class ImageProfile : AutoMapperProfile
    {
        public ImageProfile()
        {
            CreateMap<ImageDto, Image>();
            CreateMap<Image, ImageDto>();
        }
    }
}
