using Data.DataEntities;

namespace Data.ProviderContracts
{
    public interface IProductProvider
    {
        Task<IEnumerable<ProductDataEntity>> GetAllProducts();
    }
}
