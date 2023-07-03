using Data.DataEntities;
using Data.ProviderContracts;
using Domain.Entities;
using Domain.RepositoryContracts;
using static Data.DataEntities.CartDataEntity;
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

        #region constructor
        public CartRepository(IProvider provider, ICacheRepository cache,
            IProductRepository productRepository, IUserRepository userRepository)
        {
            _provider = provider;
            _cache = cache;
            _FileRepository = new FileRepository("Cart");
            _productRepository = productRepository;
            _userRepository = userRepository;
        }
        #endregion

        #region public methods
        public async Task<IEnumerable<CartEntity>> GetAllCarts()
        {
            List<CartEntity> cartEntities = new List<CartEntity>();
            IEnumerable<CartDataEntity>? carts = await GetData();
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
            await _FileRepository.WriteDataFirst(await _provider.GetAll<CartDataEntity>("Cart"));
        }

        public async Task Delete(int id)
        {
            List<CartDataEntity> carts = (await GetData()).ToList();

            carts.Remove(carts.First(x => x.Id == id));
            await InsertData(carts);
        }

        public async Task DeleteProductsInCart(int idProduct)
        {
            IEnumerable<CartDataEntity> carts = await GetData();

            foreach (CartDataEntity cart in carts)
            {
                if (cart.Products is not null)
                {
                    cart.Products = cart.Products.Where(p => p.ProductId != idProduct).ToArray();
                }
            }

            await InsertData(carts);
        }

        public async Task DeleteCartFromUser(int idUser)
        {
            int idCart = (await GetData()).First(x => x.UserId == idUser).Id;
            await Delete(idCart);
        }

        #endregion

        #region private methods

        private async Task InsertData(IEnumerable<CartDataEntity> carts)
        {
            await _FileRepository.WriteData(carts);
            _cache.SetIntoCache("carts", carts);
        }

        private async Task<IEnumerable<CartDataEntity>> GetData()
        {
            IEnumerable<CartDataEntity>? carts = _cache.Get<IEnumerable<CartDataEntity>>("carts");

            if (carts is null || carts.Count() == 0)
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

            if (cart.Products is not null)
            {
                foreach (var product in cart.Products)
                {
                    productsInUser.Add(new ProductInUser
                    {
                        ProductQuantity = product.Quantity,
                        Product = products.FirstOrDefault(x => x.Id == product.ProductId) ?? new ProductEntity()
                    });
                }
            }

            return productsInUser;
        }
        #endregion
    }
}
