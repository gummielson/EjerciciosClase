namespace Domain.RepositoryContracts
{
    public interface IRepository
    {
        Task<T> GetAll<T>(string jsonName);
    }
}
