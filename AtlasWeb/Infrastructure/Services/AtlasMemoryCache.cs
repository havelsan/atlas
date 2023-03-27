using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using TTUtils;

namespace Infrastructure.Services
{
    public class AtlasMemoryCache : ICache, IDisposable
    {
        private MemoryCache _memoryCache;

        private bool _disposed = false;

        public AtlasMemoryCache(string name)
        {
            _memoryCache = new MemoryCache(new OptionsWrapper<MemoryCacheOptions>(new MemoryCacheOptions()));
        }

        public string Name { get; }
        public TimeSpan DefaultSlidingExpireTime { get; set; }
        public TimeSpan? DefaultAbsoluteExpireTime { get; set; }

        public void Clear()
        {
            _memoryCache.Dispose();
            _memoryCache = new MemoryCache(new OptionsWrapper<MemoryCacheOptions>(new MemoryCacheOptions()));
        }

        public bool TryGetValue(string key, out object value)
        {
            return _memoryCache.TryGetValue(key, out value);
        }

        public object GetOrDefault(string key)
        {
            return _memoryCache.Get(key);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void Set(string key, object value, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null)
        {
            if (value == null)
            {
                throw new TTException("Can not insert null values to the cache!");
            }

            if (absoluteExpireTime != null)
            {
                _memoryCache.Set(key, value, DateTimeOffset.Now.Add(absoluteExpireTime.Value));
            }
            else if (slidingExpireTime != null)
            {
                _memoryCache.Set(key, value, slidingExpireTime.Value);
            }
            else if (DefaultAbsoluteExpireTime != null)
            {
                _memoryCache.Set(key, value, DateTimeOffset.Now.Add(DefaultAbsoluteExpireTime.Value));
            }
            else
            {
                _memoryCache.Set(key, value, DefaultSlidingExpireTime);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_memoryCache != null)
                        _memoryCache.Dispose();
                    // ...
                }

                // Now disposed of any unmanaged objects
                // ...

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Destructor
        ~AtlasMemoryCache()
        {
            Dispose(false);
        }
    }
}
