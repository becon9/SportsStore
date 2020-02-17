using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.BLL.Services.Implementation;
using SportsStore.BLL.Services.Interfaces;
using SportsStore.DAL;
using SportsStore.DAL.Context;
using SportsStore.DAL.Repositories.Implementation;
using SportsStore.DAL.Repositories.Interfaces;
using SportsStore.Infrastructure.Interfaces;

namespace SportsStore.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependenciesWeb(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton<SportsStore.Infrastructure.Interfaces.IMapper,
                    Infrastructure.Core.AutoMapper>();

            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();

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
        
        public static void RegisterDependenciesApi(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton<SportsStore.Infrastructure.Interfaces.IMapper,
                    Infrastructure.Core.AutoMapper>();

            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration["Data:SportsStoreProducts:ConnectionString"],
                    b => b.MigrationsAssembly("SportsStore.DAL")));

            /*services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    configuration["Data:SportStoreIdentity:ConnectionString"],
                    b => b.MigrationsAssembly("SportsStore.DAL")));*/

            /*services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();*/

            //services.AddScoped<IIdentityInitializer, IdentityInitializer>();
        }
    }
}
