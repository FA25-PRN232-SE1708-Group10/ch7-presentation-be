using BLL.MappingProfiles;
using BLL.Services;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddAutoMapper(cfg => cfg.AddProfile<ProductProfile>());

            return services;
        }
    }
}
