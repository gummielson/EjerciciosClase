using Data.DataEntities;

namespace Data.ProviderContracts
{
    public interface ICartProvider
    {
        Task<IEnumerable<CartDataEntity>> GetAllCarts();
    }
}