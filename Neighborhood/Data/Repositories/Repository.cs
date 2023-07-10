using Data.Provider;
using Domain.RepositoryContracts;

namespace Data.Repository
{
    public class Repository : IRepository
    {
        private readonly IProvider _provider;

        public Repository(IProvider provider)
        {
            _provider = provider;
        }

        public async Task<T> GetAll<T>(string jsonName)
        {
            return await _provider.GetAll<T>(jsonName);
        }
    }
}
