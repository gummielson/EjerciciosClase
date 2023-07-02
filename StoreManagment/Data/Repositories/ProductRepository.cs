using Data.DataEntities;
using Data.ProviderContracts;
using Domain.Entities;
using Domain.RepositoryContracts;

namespace Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region private variables
        private readonly IProvider _provider;
        private readonly ICacheRepository _cache;
        private readonly FileRepository _FileRepository;
        #endregion

        #region constructor
        public ProductRepository(IProvider provider, ICacheRepository cache)
        {
            _provider = provider;
            _FileRepository = new FileRepository("Products");
            _cache = cache;
        }
        #endregion

        #region public methods
        public async Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            return DataEntityToEntity(await GetData());
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
            await _FileRepository.WriteDataFirst<ProductDataEntity>(await _provider.GetAll<ProductDataEntity>("Product"));
        }

        public async Task DeleteProduct(int id)
        {
            List<ProductDataEntity> products = (await GetData()).ToList();

            products.Remove(products.First(x => x.Id == id));
            await _FileRepository.WriteData(products);
            _cache.SetIntoCache("products", products);
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

        private async Task<IEnumerable<ProductDataEntity>> GetData()
        {
            IEnumerable<ProductDataEntity>? products = _cache.Get<IEnumerable<ProductDataEntity>>("products");

            if (products is null)
            {
                products = await _FileRepository.ReadJsonFile<ProductDataEntity>() ?? Enumerable.Empty<ProductDataEntity>();
                _cache.SetIntoCache("products", products);
            }

            return products;
        }
        #endregion

    }
}
