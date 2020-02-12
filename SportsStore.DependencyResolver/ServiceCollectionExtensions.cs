using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.BLL.Interfaces;
using SportsStore.BLL.Services;
using SportsStore.DAL.Context;
using SportsStore.DAL.Interfaces;
using SportsStore.DAL.Repositories;
using SportsStore.Infrastructure.Interfaces;

namespace SportsStore.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton<SportsStore.Infrastructure.Interfaces.IMapper,
                    SportsService.Infrastructure.Core.AutoMapper>();

            //services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration["Data:SportsStoreProducts:ConnectionString"],
                    b => b.MigrationsAssembly("SportsStore.DAL")));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    configuration["Data:SportStoreIdentity:ConnectionString"],
                    b => b.MigrationsAssembly("SportsStore.DAL")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IIdentityInitializer, IdentityInitializer>();
        }
    }
}
