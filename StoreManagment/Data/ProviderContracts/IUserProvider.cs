using Data.DataEntities;

namespace Data.ProviderContracts
{
    public interface IUserProvider
    {
        Task<IEnumerable<UserDataEntity>> GetAllUsers();
    }
}