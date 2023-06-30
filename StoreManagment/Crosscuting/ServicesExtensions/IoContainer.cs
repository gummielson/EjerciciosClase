using Application.Services;
using Application.ServicesContracts;
using Data.Repositories;
using Domain.RepositoryContracts;
using Microsoft.Extensions.DependencyInjection;

namespace Crosscuting.IoC
{
    public static class IoContainer
    {
        public static void ConfigureIoC(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartRepository, CartRepository>();

            services.AddScoped<ICacheRepository, CacheRepository>();

            services.AddScoped<IGeneralService, GeneralService>();
        }
    }
}
