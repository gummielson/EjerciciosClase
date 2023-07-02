using Domain.Entities;

namespace Application.ServicesContracts
{
    public interface ICartService
    {
        Task<IEnumerable<CartEntity>> GetAllCarts();
        Task Delete(int id);
        Task DeleteProductInCarts(int idProduct);
        Task DeleteCartFromUser(int idUser);
    }
}
