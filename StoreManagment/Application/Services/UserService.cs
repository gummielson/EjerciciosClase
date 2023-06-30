using Application.ServicesContracts;
using Data.Repositories;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        //public async Task<IEnumerable<UserDto>> GetAllUsers()
        //{
        //    return MapUserToDto(await _repository.GetAllUsers());
        //}

        //private IEnumerable<UserDto> MapUserToDto(IEnumerable<UserEntity> users)
        //{
        //    return users.Select(x => new UserDto()
        //    {
        //        AddressProperty = x.AddressProperty,
        //        Email = x.Email,
        //        NameProperty = x.NameProperty,
        //        Password = x.Password,
        //        Phone = x.Phone,
        //        Username = x.Username
        //    });
        //}
    }
}
