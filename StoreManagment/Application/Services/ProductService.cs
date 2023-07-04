using Application.Dtos;
using Application.ServicesContracts;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryContracts;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper, ICartService cartService)
        {
            _repository = repository;
            _mapper = mapper;
            _cartService = cartService;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            return await _repository.GetAllProducts();
        }

        public async Task DeleteProduct(int id)
        {
            ProductEntity? productEntity = (await GetAllProducts()).FirstOrDefault(x => x.Id == id);

            if (productEntity is not null)
            {
                await _repository.DeleteProduct(id);
                await _cartService.DeleteProductInCarts(id);
            }
            else
            {
                throw new Exception("The entered id doesn't exists");
            }      
        }

        public async Task InsertProduct(ProductDto product)
        {
            if ((await GetAllProducts()).Any())
            {
                await _repository.InsertProduct(await MapDtoToProduct(product));
            }
            else
            {
                throw new Exception("");
            }
        }

        //public async Task<IEnumerable<ProductDto>> GetProductsByFilter(string filter)
        //{
        //    IEnumerable<ProductEntity> products = await _repository.GetAllProducts();

        //    ParameterExpression param = Expression.Parameter(typeof(ProductEntity), "p");
        //    var predicate = DynamicExpressionParser.ParseLambda(new[] { param }, null, filter);

        //    return MapProductsToDto(products.Where((Func<ProductEntity, bool>)predicate.Compile()));
        //}

        //private IEnumerable<ProductDto> MapProductsToDto(IEnumerable<ProductEntity> products) 
        //{
        //    return products.Select(x => new ProductDto()
        //    {
        //        Title = x.Title,
        //        Price = x.Price,
        //        Description = x.Description,
        //        Category = x.Category,
        //        Image = x.Image,
        //        RatingProperty = x.RatingProperty
        //    });
        //}

        private async Task<ProductEntity> MapDtoToProduct(ProductDto product)
        {
            int id = (await GetAllProducts()).Select(p => p.Id).Max() + 1;

            return new ProductEntity()
            {
                Id = id,
                Title = product.Title,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category,
                Image = product.Image,
                Count = product.Count,
                Rate = product.Rate
            };
        }
    }
}
