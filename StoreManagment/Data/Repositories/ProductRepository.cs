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
        private readonly FileRepository _fileRepository;
        #endregion

        #region constructor
        public ProductRepository(IProvider provider, ICacheRepository cache)
        {
            _provider = provider;
            _fileRepository = new FileRepository("Products");
            _cache = cache;
        }
        #endregion

        #region public methods
        public async Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            return DataEntityToEntity(await GetData());
        }

        public async Task InsertProduct(ProductEntity product)
        {
            IEnumerable<ProductDataEntity>? products = await GetData();

            if (products is not null)
            {
                if(products.Any()) 
                {
                    products.Append(EntityToDataEntity(product));
                    await InsertData(products);
                }
            }
            else
            {
                throw new Exception("Data wasnt loaded yet");
            }
        }

        public async Task SaveDataInFile()
        {
            await _fileRepository.WriteDataFirst<ProductDataEntity>(await _provider.GetAll<ProductDataEntity>("Product"));
        }

        public async Task DeleteProduct(int id)
        {
            List<ProductDataEntity> products = (await GetData()).ToList();

            products.Remove(products.First(x => x.Id == id));
            await _fileRepository.WriteData(products);
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
                products = await _fileRepository.ReadJsonFile<ProductDataEntity>() ?? Enumerable.Empty<ProductDataEntity>();
                _cache.SetIntoCache("products", products);
            }

            return products;
        }
        private async Task InsertData(IEnumerable<ProductDataEntity> products)
        {
            await _fileRepository.WriteData(products);
            _cache.SetIntoCache("products", products);
        }

        private ProductDataEntity EntityToDataEntity(ProductEntity entity)
        {
            return new ProductDataEntity
            {
                Id = entity.Id,
                Category = entity.Category,
                RatingProperty = new ProductDataEntity.Rating
                {
                    Count = entity.Count,
                    Rate = entity.Rate
                },
                Description = entity.Description,
                Image = entity.Image,
                Price = entity.Price,
                Title = entity.Title
            };
        }
        #endregion

    }
}
