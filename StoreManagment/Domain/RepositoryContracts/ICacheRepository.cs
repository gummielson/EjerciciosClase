namespace Data.Repositories
{
    public interface ICacheRepository
    {
        T Get<T>(string key);
        void SetIntoCache<T>(string key, T value);
    }
}