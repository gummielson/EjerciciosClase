using Application.Dtos;
using Application.Services;
using Application.ServicesContracts;
using Data.ProviderContracts;
using Data.Providers;
using Data.Repositories;
using Domain.RepositoryContracts;
using Microsoft.OpenApi.Models;
using WebApi;
using WebApi.Controllers;

namespace MinimalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddHttpClient<IProductProvider, ProductProvider>(c =>
            {
                c.BaseAddress = new Uri("https://fakestoreapi.com/products");
                c.Timeout = new TimeSpan(0, 0, 45);
                c.DefaultRequestHeaders.Clear();
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("a",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            builder.Services.AddMemoryCache();

            builder.Services.AddAutoMapper(typeof(Startup));

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Store managment API",
                    Version = "v1"
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/api/Product/SaveProductsFromExternalApi", async (IProductService productService, ILogger<ProductController> logger) =>
            {
                try
                {
                    await productService.SaveDataFromExternalApi();

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    logger.LogError("Can't save data");

                    return Results.BadRequest(ex.Message);
                }
            });

            app.MapGet("/api/Product/GetAllProducts", async (IProductService productService, ILogger<ProductController> logger) =>
            {
                try
                {
                    return Results.Ok(await productService.GetAllProducts());
                }
                catch (Exception ex)
                {
                    logger.LogError("Unable to get all products");

                    return Results.BadRequest(ex.Message);
                }
            });

            app.MapPost("/api/Product/InsertProduct", async (ProductDto product, IProductService productService, ILogger<ProductController> logger) =>
            {
                try
                {
                    var response = await productService.InsertProduct(product);

                    return string.IsNullOrWhiteSpace(response.Result) ? Results.Ok() : Results.BadRequest(response.Result);
                }
                catch (Exception ex)
                {
                    logger.LogError("Unable to insert product");

                    return Results.BadRequest(ex.Message);
                }
            });

            app.MapGet("/api/Product/GetProductsByFilter", async (string filter, IProductService productService, ILogger<ProductController> logger) =>
            {
                try
                {
                    await productService.GetProductsByFilter(filter);

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    logger.LogError("Unable to get products by filter");

                    return Results.BadRequest(ex.Message);
                }
            });

            app.Run();
        }
    }
}