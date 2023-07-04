using Application.Dtos;
using Application.ServicesContracts;
using AutoMapper;
using Data.Repositories;
using Domain.Entities;
using Domain.RepositoryContracts;

namespace Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository repository, IMapper mapper, IUserRepository userRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<CartEntity>> GetAllCarts()
        {
            return await _repository.GetAllCarts();
        }

        public async Task Delete(int id)
        {
            CartEntity? cartToDelete = (await _repository.GetAllCarts()).FirstOrDefault(x => x.Id == id);

            if (cartToDelete is not null)
            {
                await _repository.Delete(id);
            }
            else
            {
                throw new Exception("Inserted cart id doesn´t exists");
            }
        }

        public async Task DeleteProductInCarts(int idProduct)
        {
            await _repository.DeleteProductsInCart(idProduct);
        }

        public async Task InsertCart(CartDto cartDto)
        {
            UserEntity user = await _userRepository.GetUserById(cartDto.IdUser);
            await _repository.InsertCart(await DtoToEntity(user));
        }

        private async Task<CartEntity> DtoToEntity(UserEntity user)
        {
            int id = (await GetAllCarts()).Select(p => p.Id).Max() + 1;

            return new CartEntity
            {
                Id = id,
                User = user
            };
        }
    }
}
