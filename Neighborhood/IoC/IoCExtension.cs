using Application.ServiceContracts;
using Application.Services;
using Data.Repository;
using Domain.RepositoryContracts;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class IoCExtension
    {
        public static void ConfigureIoC(this IServiceCollection services)
        {
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IRepository, Repository>();

            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IUserRepository, UserRepository>();

            //services.AddScoped<ICartService, CartService>();
            //services.AddScoped<ICartRepository, CartRepository>();

            //services.AddScoped<ICacheRepository, CacheRepository>();

            //services.AddScoped<IGeneralService, GeneralService>();
        }
    }
}
