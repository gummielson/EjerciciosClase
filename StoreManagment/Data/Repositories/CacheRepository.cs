using Microsoft.Extensions.Caching.Memory;

namespace Data.Repositories
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IMemoryCache _cache;

        public CacheRepository(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void SetIntoCache<T>(string key, T value)
        {
            _cache.Set(key, value, TimeSpan.FromMinutes(5));
        }

        public T Get<T>(string key)
        {
            return _cache.Get<T>(key) ?? default(T);
        }
    }
}
