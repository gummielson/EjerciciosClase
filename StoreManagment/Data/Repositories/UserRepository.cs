﻿using Data.DataEntities;
using Data.ProviderContracts;
using Domain.Entities;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region private variables
        private readonly IProvider _provider;
        private readonly ICacheRepository _cache;
        private readonly FileRepository _fileRepository;
        #endregion

        #region constructor
        public UserRepository(IProvider provider, ICacheRepository cache)
        {
            _provider = provider;
            _cache = cache;
            _fileRepository = new FileRepository("User");
        }
        #endregion

        #region public methods
        public async Task Delete(int id)
        {
            List<UserDataEntity> users = (await GetData()).ToList();

            users.Remove(users.First(x => x.Id == id));
            await _fileRepository.WriteData(users);
            _cache.SetIntoCache("users", users);
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            return DataEntityToEntity(await GetData());
        }

        public async Task SaveDataInFile()
        {
            await _fileRepository.WriteDataFirst(await _provider.GetAll<UserDataEntity>("User"));
        }
        #endregion

        #region private methods
        private async Task<IEnumerable<UserDataEntity>> GetData()
        {
            IEnumerable<UserDataEntity>? users = _cache.Get<IEnumerable<UserDataEntity>>("users");

            if (users is null)
            {
                users = await _fileRepository.ReadJsonFile<UserDataEntity>() ?? Enumerable.Empty<UserDataEntity>();
                _cache.SetIntoCache("users", users);
            }

            return users;
        }

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
