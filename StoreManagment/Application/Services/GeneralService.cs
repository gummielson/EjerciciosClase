using Application.ServicesContracts;
using Data.Repositories;
using Domain.RepositoryContracts;

namespace Application.Services
{
    public class GeneralService : IGeneralService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;

        public GeneralService(IProductRepository productRepository,
            ICartRepository cartRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }

        public async Task SaveDataInMemory()
        {
            await _cartRepository.SaveDataInFile();
            await _productRepository.SaveDataInFile();
            await _userRepository.SaveDataInFile();
        }
    }
}
