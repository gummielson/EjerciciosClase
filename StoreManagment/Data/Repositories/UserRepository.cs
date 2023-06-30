using System.Collections.Generic;
using Data.DataEntities;
using Data.ProviderContracts;
using Microsoft.Extensions.Caching.Memory;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserProvider _provider;
        private readonly IMemoryCache _cache;
        private readonly FileRepository _fileRepository;

        public UserRepository(IUserProvider provider, IMemoryCache cache)
        {
            _provider = provider;
            _cache = cache;
            _fileRepository = new FileRepository("User");
        }

        public async Task<IEnumerable<UserDataEntity>> GetAllUsers()
        {
            return await _provider.GetAllUsers();
        }

        public async Task SaveDataInFile()
        {
            await _fileRepository.WriteData(await _provider.GetAllUsers());
        }
    }
}
