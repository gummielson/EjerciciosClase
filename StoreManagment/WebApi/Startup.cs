﻿using Crosscuting.IoC;
using Data.ProviderContracts;
using Data.Providers;
using Microsoft.OpenApi.Models;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.ConfigureIoC();

            #region Providers
            services.AddHttpClient<IProvider, Provider>(c =>
            {
                c.Timeout = new TimeSpan(0, 0, 45);
                c.DefaultRequestHeaders.Clear();
            });
            #endregion

            services.AddCors(options =>
            {
                options.AddPolicy("a",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            services.AddMemoryCache();
            //    memoryCacheOptions =>
            //{
            //    memoryCacheOptions.SizeLimit = 1024;
            //    memoryCacheOptions.ExpirationScanFrequency = TimeSpan.FromMinutes(5);
    //            var cacheOptions = new MemoryCacheEntryOptions()
    //.SetAbsoluteExpiration(TimeSpan.FromMinutes(1))
    //.SetSlidingExpiration(TimeSpan.FromSeconds(20));
            //});

            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Store managment API",
                    Version = "v1"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI();


            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
