using Data.DataEntities;
using Data.ProviderContracts;
using Domain.RepositoryContracts;

namespace Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductProvider _provider;
        private readonly ICacheRepository _cache;
        private readonly FileRepository _localFile;

        public ProductRepository(IProductProvider provider, ICacheRepository cache)
        {
            _provider = provider;
            _localFile = new FileRepository("Products");
            _cache = cache;
        }

        #region Public methods
        public async Task<IEnumerable<ProductDataEntity>> GetAllProducts()
        {
            IEnumerable<ProductDataEntity>? products = _cache.Get<IEnumerable<ProductDataEntity>>("products");

            if (products == null) 
            {
                products = await _localFile.ReadJsonFile<IEnumerable<ProductDataEntity>>() ?? Enumerable.Empty<ProductDataEntity>();
                _cache.SetIntoCache("products", products);
            }

            return products;
        }

        public async Task InsertProduct(ProductDataEntity product)
        {
            IEnumerable<ProductDataEntity> ? productsInCache = _cache.Get<IEnumerable<ProductDataEntity>>("products");

            if (productsInCache != null)
            {
                productsInCache.ToList().Add(product);
                _cache.SetIntoCache("products", productsInCache);
            }

            await _localFile.WriteData((await _localFile.ReadJsonFile<IEnumerable<ProductDataEntity>>()).ToList().Append(product));
        }

        public async Task SaveDataInFile()
        {
            await _localFile.WriteData(await _provider.GetAllProducts());
        }
        #endregion

    }
}
