using AutoMapper;

namespace SportsService.Infrastructure.Core
{
    public class AutoMapper : SportsStore.Infrastructure.Interfaces.IMapper
    {
        private readonly IMapper _mapper;

        public AutoMapper()
        {
            _mapper = AutoMapperConfiguration.Configure();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}
