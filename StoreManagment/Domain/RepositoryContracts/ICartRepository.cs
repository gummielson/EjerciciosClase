using Domain.Entities;

namespace Domain.RepositoryContracts
{
    public interface ICartRepository
    {
        //Task<IEnumerable<CartEntity>> GetAllCarts();
        Task SaveDataInFile();
    }
}
