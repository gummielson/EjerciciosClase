using Application.Dtos;
using Application.ServicesContracts;
using Data.Repositories;
using Domain.Entities;
using Domain.RepositoryContracts;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ICartRepository _cartRepository;

        public UserService(IUserRepository repository, ICartRepository cartRepository)
        {
            _repository = repository;
            _cartRepository = cartRepository;
        }

        public async Task Delete(int id)
        {
            UserEntity? userEntity = (await GetAllUsers()).FirstOrDefault(x => x.Id == id);

            if (userEntity is not null)
            {
                await _cartRepository.DeleteCartFromUser(id);
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

        public async Task InsertUser(UserDto userDto)
        {
            if ((await GetAllUsers()).Any())
            {
                await _repository.InsertUser(await MapDtoToEntity(userDto));
            }
            else
            {
                throw new Exception("");
            }
        }

        private async Task<UserEntity> MapDtoToEntity(UserDto userDto)
        {
            int id = (await GetAllUsers()).Select(p => p.Id).Max() + 1;

            return new UserEntity
            {
                Id = id,
                City = userDto.City,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Lat = userDto.Lat,
                Long = userDto.Long,
                Number = userDto.Number,
                Password = userDto.Password,
                Phone = userDto.Phone,
                Street = userDto.Street,
                Username = userDto.Username,
                ZipCode = userDto.ZipCode
            };
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
