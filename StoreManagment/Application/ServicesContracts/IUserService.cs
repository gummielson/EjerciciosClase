using Application.Dtos;
using Domain.Entities;

namespace Application.ServicesContracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserEntity>> GetAllUsers();
        Task Delete(int id);
        Task InsertUser(UserDto userDto);
    }
}