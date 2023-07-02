using Domain.Entities;

namespace Application.ServicesContracts
{
    public interface ICartService
    {
        Task<IEnumerable<CartEntity>> GetAllCarts();
    }
}
