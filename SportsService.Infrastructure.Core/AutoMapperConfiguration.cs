using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace SportsService.Infrastructure.Core
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            IEnumerable<Type> profiles = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(a => typeof(AutoMapperProfile).IsAssignableFrom(a));

            var mapperConfiguration = new MapperConfiguration(a => profiles.ForEach(a.AddProfile));

            return mapperConfiguration.CreateMapper();
        }

        
    }

    public class AutoMapperProfile : Profile
    {

    }

    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable,
            Action<T> action)
        {
            foreach (T item in enumerable) { action(item); }
        }
    }
}
