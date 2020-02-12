using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportsStore.DependencyResolver;
using SportsStore.Infrastructure.Interfaces;
using SportsStore.WEB.Models;

namespace SportsStore.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllersWithViews();

            services.RegisterDependencies(Configuration);

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IIdentityInitializer identityInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                var supportedCultures = new[] { new CultureInfo("ru-UA") };
                app.UseRequestLocalization(new RequestLocalizationOptions
                {
                    DefaultRequestCulture = new RequestCulture("ru-UA"),
                    SupportedCultures = supportedCultures,
                    SupportedUICultures = supportedCultures
                });
                
                identityInitializer.SeedData().Wait();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute(
                    name: null,
                    pattern: "{category}/Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List" });

                endpoint.MapControllerRoute(
                    name: null,
                    pattern: "Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 });

                endpoint.MapControllerRoute(
                    name: null,
                    pattern: "{category}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 });

                endpoint.MapControllerRoute(
                    name: null,
                    pattern: "",
                    defaults: new { controller = "Product", action = "List", productPage = 1 });

                endpoint.MapControllerRoute(
                    name: null,
                    pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}