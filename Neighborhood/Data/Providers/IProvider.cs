namespace Data.Provider
{
    public interface IProvider
    {
        Task<T> GetAll<T>(string jsonName);
    }
}