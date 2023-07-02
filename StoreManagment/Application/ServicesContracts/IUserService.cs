using Domain.Entities;

namespace Application.ServicesContracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserEntity>> GetAllUsers();
    }
}