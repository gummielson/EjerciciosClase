using System.Collections.Generic;
using Data.DataEntities;
using Data.ProviderContracts;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using static Data.DataEntities.CartDataEntity;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IProvider _provider;
        private readonly ICacheRepository _cache;
        private readonly FileRepository _fileRepository;

        public UserRepository(IProvider provider, ICacheRepository cache)
        {
            _provider = provider;
            _cache = cache;
            _fileRepository = new FileRepository("User");
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            IEnumerable<UserDataEntity>? users = _cache.Get<IEnumerable<UserDataEntity>>("users");

            if (users is null)
            {
                users = await _fileRepository.ReadJsonFile<UserDataEntity>() ?? Enumerable.Empty<UserDataEntity>();
                _cache.SetIntoCache("users", users);
            }

            return DataEntityToEntity(users);
        }

        public async Task SaveDataInFile()
        {
            await _fileRepository.WriteData(await _provider.GetAll<UserDataEntity>("User"));
        }

        #region private methods
        private IEnumerable<UserEntity> DataEntityToEntity(IEnumerable<UserDataEntity> dataEntities) 
        {
            return dataEntities.Select(dataEntity => new UserEntity
            {
                Id = dataEntity.Id,
                City = dataEntity.AddressProperty.City,
                ZipCode = dataEntity.AddressProperty.ZipCode,
                Email = dataEntity.Email,
                FirstName = dataEntity.NameProperty.FirstName,
                LastName = dataEntity.NameProperty.LastName,
                Lat = dataEntity.AddressProperty.GeolocationProperty.Lat,
                Long = dataEntity.AddressProperty.GeolocationProperty.Long,
                Number = dataEntity.AddressProperty.Number,
                Password = dataEntity.Password,
                Phone = dataEntity.Phone,
                Street = dataEntity.AddressProperty.Street,
                Username = dataEntity.Username
            });
        }
        #endregion
    }
}
