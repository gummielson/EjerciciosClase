using Data.DataEntities;
using Data.ProviderContracts;
using Domain.RepositoryContracts;
using Microsoft.Extensions.Caching.Memory;

namespace Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ICartProvider _provider;
        private readonly IMemoryCache _cache;
        private readonly FileRepository _localFile;

        public CartRepository(ICartProvider provider, IMemoryCache cache)
        {
            _provider = provider;
            _cache = cache;
            _localFile = new FileRepository("Cart");
        }

        //public async Task<IEnumerable<CartDataEntity>> GetAllCarts()
        //{
        //    return await _provider.GetAllCarts();
        //}

        public async Task SaveDataInFile()
        {
            await _localFile.WriteData(await _provider.GetAllCarts());
        }
    }
}
