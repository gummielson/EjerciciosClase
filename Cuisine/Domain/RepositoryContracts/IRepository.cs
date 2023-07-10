namespace Data.Repositories
{
    public interface IRepository
    {
        Task<IEnumerable<T>> GetAll<T>(string jsonName);
    }
}