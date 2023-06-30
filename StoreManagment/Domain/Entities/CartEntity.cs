using Domain.Entities;

namespace Domain.Entities
{
    public class CartEntity
    {
        public UserEntity User { get; set; } = new UserEntity();
        public DateTime Date { get; set; }
        public IEnumerable<ProductInUser> ProductInUserProperty { get; set; } = new List<ProductInUser>();
        public class ProductInUser
        {
            public ProductEntity Product { get; set; } = new ProductEntity();
            public int ProductQuantity { get; set;}
        }

    }
}
