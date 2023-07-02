using Application.ServicesContracts;
using Data.Repositories;
using Domain.Entities;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ICartService _cartService;

        public UserService(IUserRepository repository, ICartService cartService)
        {
            _repository = repository;
            _cartService = cartService;
        }

        public async Task Delete(int id)
        {
            UserEntity? userEntity = (await GetAllUsers()).FirstOrDefault(x => x.Id == id);

            if (userEntity is not null) 
            {
                if(await CheckIfTheUserHasACart(userEntity))
                {
                    await _cartService.DeleteCartFromUser(id);
                }
                await _repository.Delete(id);
            }
            else
            {
                throw new Exception("The entered user doesn`t exists");
            }
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            return await _repository.GetAllUsers();
        }

        private async Task<bool> CheckIfTheUserHasACart(UserEntity user)
        {
            return (await _cartService.GetAllCarts()).Any(x => x.User == user);
        }


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
