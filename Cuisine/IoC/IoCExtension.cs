﻿using Application.Services;
using Application.ServicesContracts;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class IoCExtension
    {
        public static void ConfigureIoC(this IServiceCollection services)
        {
            services.AddScoped<IRecipeService, RecipeService>();
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