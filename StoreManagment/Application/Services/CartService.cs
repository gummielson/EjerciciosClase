using Application.ServicesContracts;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryContracts;

namespace Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        public async Task DeleteCartFromUser(int idUser)
        {
            await _repository.DeleteCartFromUser(idUser);
        }
    }
}
