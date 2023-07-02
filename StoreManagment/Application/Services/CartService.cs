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
    }
}
