using Domain.Entities;

namespace Domain.RepositoryContracts
{
    public interface ICartRepository
    {
        Task<IEnumerable<CartEntity>> GetAllCarts();
        Task SaveDataInFile();
        Task Delete(int id);
        Task DeleteProductsInCart(int idProduct);
        Task DeleteCartFromUser(int idUser);
        Task InsertCart(CartEntity cart);
    }
}
