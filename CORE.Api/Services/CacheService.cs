using CORE.Commons.Tools;
using EasyCaching.Core;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CORE.Api.Services
{
    public class CacheService<T> : ICacheService<T> where T : class
    {
        private readonly IOptions<GlobalSettings> settings;
        private readonly IEasyCachingProvider _distributedCache;
        private readonly IEasyCachingProviderFactory _cachingProviderFactory;

        public CacheService(IEasyCachingProviderFactory cachingProviderFactory, IOptions<GlobalSettings> options)
        {
            settings = options;
            _cachingProviderFactory = cachingProviderFactory;
            _distributedCache = _cachingProviderFactory.GetCachingProvider(settings.Value.DataBaseName);
        }
        public T GetCacheService(string cacheKey)
        {
            var dataResponse = _distributedCache.Get<T>(cacheKey).Value;
            return dataResponse;
        }
        public List<T> GetAllCacheService(string cacheKeyPrefix)
        {
            var roulettes = _distributedCache.GetByPrefix<T>(cacheKeyPrefix);
            if (roulettes.Values.Count == 0)
            {
                return new List<T>();
            }
            return new List<T>(roulettes.Select(x => x.Value.Value));
        }

        public T SetCacheService(string cacheKey,string id, T objectSetCache)
        {
            _distributedCache.Set($"{cacheKey}{id}", objectSetCache, TimeSpan.FromDays(settings.Value.ExpireDays));
            return objectSetCache;
        }
    }
}
