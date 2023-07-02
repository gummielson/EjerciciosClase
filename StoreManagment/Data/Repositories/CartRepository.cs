using Data.DataEntities;
using Data.ProviderContracts;
using Domain.Entities;
using Domain.RepositoryContracts;
using static Domain.Entities.CartEntity;

namespace Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        #region private variables
        private readonly IProvider _provider;
        private readonly ICacheRepository _cache;
        private readonly FileRepository _FileRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        #endregion

        public CartRepository(IProvider provider, ICacheRepository cache,
            IProductRepository productRepository, IUserRepository userRepository)
        {
            _provider = provider;
            _cache = cache;
            _FileRepository = new FileRepository("Cart");
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<CartEntity>> GetAllCarts()
        {
            List<CartEntity> cartEntities = new List<CartEntity>();
            IEnumerable<CartDataEntity>? carts = await GetDataFormCache();
            IEnumerable<ProductEntity> products = await _productRepository.GetAllProducts();
            IEnumerable<UserEntity> users = await _userRepository.GetAllUsers();

            foreach (var cart in carts)
            {
                cartEntities.Add(DataEntityToEntity(cart, users, products));
            }

            return cartEntities;
        }

        public async Task SaveDataInFile()
        {
            await _FileRepository.WriteData(await _provider.GetAll<CartDataEntity>("Cart"));
        }

        private async Task<IEnumerable<CartDataEntity>> GetDataFormCache()
        {
            IEnumerable<CartDataEntity>? carts = _cache.Get<IEnumerable<CartDataEntity>>("carts");

            if (carts is null)
            {
                carts = await _FileRepository.ReadJsonFile<CartDataEntity>() ?? Enumerable.Empty<CartDataEntity>();
                _cache.SetIntoCache("carts", carts);
            }

            return carts;
        }

        private CartEntity DataEntityToEntity(CartDataEntity cart,
            IEnumerable<UserEntity> users, IEnumerable<ProductEntity> products)
        {
            List<ProductInUser> productsInUser = new List<ProductInUser>();

            return new CartEntity
            {
                Id = cart.Id,
                Date = cart.Date,
                User = users.FirstOrDefault(x => x.Id == cart.Id) ?? new UserEntity(),
                Products = ProductsInCarToProductsInCarEntity(cart, products)
            };
        }

        private List<ProductInUser> ProductsInCarToProductsInCarEntity(CartDataEntity cart, IEnumerable<ProductEntity> products)
        {
            List<ProductInUser> productsInUser = new List<ProductInUser>();

            foreach (var product in cart.Products)
            {
                productsInUser.Add(new ProductInUser
                {
                    ProductQuantity = product.Quantity,
                    Product = products.FirstOrDefault(x => x.Id == product.ProductId) ?? new ProductEntity()
                });
            }

            return productsInUser;
        }
    }
}
