using Application.ServicesContracts;
using AutoMapper;
using Domain.RepositoryContracts;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //public async Task SaveDataFromExternalApi()
        //{
        //    await _repository.SaveInMemory();
        //}

        //public async Task<IEnumerable<ProductDto>> GetAllProducts()
        //{
        //    IEnumerable<ProductEntity> products = await _repository.GetAllProducts();

        //    //return _mapper.Map<ProductDto>(products);
        //    return MapProductsToDto(products);
        //}

        //public async Task<ResponseDto> InsertProduct(ProductDto product)
        //{
        //    string result = string.Empty;

        //    if((await _repository.GetAllProducts()).Any()) 
        //    {
        //        int id = (await _repository.GetAllProducts()).Select(p => p.Id).Max() + 1;
        //        await _repository.InsertProduct(MapDtoToProduct(product, id));
        //    }
        //    else
        //    {
        //        result = "Failed to insert product. No products loaded yet.";
        //    }

        //    return new ResponseDto() { Result = result };
        //}

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

        //private ProductEntity MapDtoToProduct(ProductDto product, int id)
        //{
        //    return new ProductEntity()
        //    {
        //        Id = id,
        //        Title = product.Title,
        //        Price = product.Price,
        //        Description = product.Description,
        //        Category = product.Category,
        //        Image = product.Image,
        //        RatingProperty = product.RatingProperty
        //    };
        //}
    }
}
