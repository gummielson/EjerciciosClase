using Data.DataEntities;
using Data.ProviderContracts;
using Domain.Entities;
using Domain.RepositoryContracts;

namespace Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProvider _provider;
        private readonly ICacheRepository _cache;
        private readonly FileRepository _FileRepository;

        public ProductRepository(IProvider provider, ICacheRepository cache)
        {
            _provider = provider;
            _FileRepository = new FileRepository("Products");
            _cache = cache;
        }

        #region Public methods
        public async Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            IEnumerable<ProductDataEntity>? products = _cache.Get<IEnumerable<ProductDataEntity>>("products");

            if (products is null)
            {
                products = await _FileRepository.ReadJsonFile<ProductDataEntity>() ?? Enumerable.Empty<ProductDataEntity>();
                _cache.SetIntoCache("products", products);
            }

            return DataEntityToEntity(products);
        }

        //public async Task InsertProduct(ProductDataEntity product)
        //{
        //    IEnumerable<ProductDataEntity> ? productsInCache = _cache.Get<IEnumerable<ProductDataEntity>>("products");

        //    if (productsInCache != null)
        //    {
        //        productsInCache.ToList().Add(product);
        //        _cache.SetIntoCache("products", productsInCache);
        //    }

        //    await _FileRepository.WriteData((await _FileRepository.ReadJsonFile<ProductDataEntity>()).ToList().Append(product));
        //}

        public async Task SaveDataInFile()
        {
            await _FileRepository.WriteData<ProductDataEntity>(await _provider.GetAll<ProductDataEntity>("Product"));
        }
        #endregion

        #region private methods
        private IEnumerable<ProductEntity> DataEntityToEntity(IEnumerable<ProductDataEntity> dataEntities) 
        {
            return dataEntities.Select(dataEntity => new ProductEntity
            {
                Id = dataEntity.Id,
                Category = dataEntity.Category,
                Count = dataEntity.RatingProperty.Count,
                Description = dataEntity.Description,
                Image = dataEntity.Image,
                Price = dataEntity.Price,
                Rate = dataEntity.RatingProperty.Rate,
                Title = dataEntity.Title
            });
        }
        #endregion

    }
}
