using System.Collections.Generic;

namespace CORE.Api.Services
{
    public interface ICacheService<T> where T : class
    {
        T GetCacheService(string cacheKey);
        List<T> GetAllCacheService(string cacheKeyPrefix);
        T SetCacheService(string cacheKey, string id, T objectSetCache);
    }
}
