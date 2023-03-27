using Infrastructure.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using TTUtils;

namespace Infrastructure.Services
{
    public class AtlasCacheManager : ICacheManager
    {
        protected readonly ConcurrentDictionary<string, ICache> Caches;

        public AtlasCacheManager()
        {
            Caches = new ConcurrentDictionary<string, ICache>();
        }

        private readonly static Lazy<ICache> lazyDefaultCache = new Lazy<ICache>(() => InitializeDefaultMemoryCache());

        private static ICache InitializeDefaultMemoryCache()
        {
            var memoryCache = new AtlasMemoryCache(CacheItemKeys.Default);
            return memoryCache;
        }

        public ICache Default
        {
            get
            {
                if (Caches.TryGetValue(CacheItemKeys.Default, out ICache cache) == true)
                {
                    return cache;
                }

                return lazyDefaultCache.Value;
            }
        }

        public IReadOnlyList<ICache> GetAllCaches()
        {
            return Caches.Values.ToImmutableList();
        }

        public ICache GetCache(string key)
        {
            if (Caches.TryGetValue(key, out ICache cache) == true)
            {
                return cache;
            }

            return null as ICache;
        }

        public bool TryGetCache(string key, out ICache cache)
        {
            return Caches.TryGetValue(key, out cache);
        }
    }
}
