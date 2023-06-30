using Application.ServicesContracts;
using AutoMapper;
using Data.Repositories;
using Domain.RepositoryContracts;

namespace Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository repository, IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
        {
            _repository = repository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //public async Task<IEnumerable<CartDto>> GetAllCarts()
        //{
        //    List<CartDto> carts = new List<CartDto>();

        //    foreach(var cart in await _repository.GetAllCarts())
        //    {
        //        carts.Add(MapCartsToDto(cart, await _userRepository.GetAllUsers(), await _productRepository.GetAllProducts()));
        //    }

        //    return carts;
        //}

        //private CartDto MapCartsToDto(CartEntity cart,
        //    IEnumerable<UserEntity> users, IEnumerable<ProductEntity> products)
        //{
        //    List<ProductInUser> productsInUser = new List<ProductInUser>();

        //    return new CartDto
        //    {
        //        Date = cart.Date,
        //        User = users.FirstOrDefault(x => x.Id == cart.UserId) ?? new UserEntity(),
        //        ProductInUserProperty = ProductsInCarToProductsInCarDto(cart, products)
        //    };
        //}

        //private List<ProductInUser> ProductsInCarToProductsInCarDto(CartEntity cart, IEnumerable<ProductEntity> products)
        //{
        //    List<ProductInUser> productsInUser = new List<ProductInUser>();

        //    foreach (var product in cart.Products) 
        //    {
        //        productsInUser.Add(new ProductInUser
        //        {
        //            ProductQuantity = product.Quantity,
        //            Product = products.FirstOrDefault(x => x.Id == product.ProductId) ?? new ProductEntity()
        //        });
        //    }

        //    return productsInUser;
        //}
    }
}
