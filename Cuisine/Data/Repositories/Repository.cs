using Data.ProviderContracts;

namespace Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly IProvider _provider;

        public Repository(IProvider provider)
        {
            _provider = provider;
        }

        public async Task<IEnumerable<T>> GetAll<T>(string jsonName)
        {
            return await _provider.GetAll<T>(jsonName);
        }
    }
}
