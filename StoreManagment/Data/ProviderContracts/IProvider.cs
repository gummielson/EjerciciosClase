namespace Data.ProviderContracts
{
    public interface IProvider
    {
        Task<IEnumerable<T>> GetAll<T>(string entity);
    }
}