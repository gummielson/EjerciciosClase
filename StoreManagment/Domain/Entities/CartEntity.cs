using Domain.Entities;

namespace Domain.Entities
{
    public class CartEntity
    {
        public int Id { get; set; }
        public UserEntity User { get; set; } = new UserEntity();
        public DateTime Date { get; set; }
        public IEnumerable<ProductInUser> Products { get; set; } = Enumerable.Empty<ProductInUser>();
        public class ProductInUser
        {
            public ProductEntity Product { get; set; } = new ProductEntity();
            public int ProductQuantity { get; set; } 
        }

    }
}
