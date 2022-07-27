namespace CH09_Caching
{
	using System;
	using System.Runtime.Caching;

	internal class InMemoryCache
    {
        private ObjectCache _cache;
        private CacheItemPolicy _policy;

        public InMemoryCache(DateTimeOffset expiryDateTimeOffset)
        {
            _cache = System.Runtime.Caching.MemoryCache.Default;
            _policy = new CacheItemPolicy
            {
                AbsoluteExpiration = expiryDateTimeOffset

            };
        }

        public void AddItem(CacheItem cacheItem)
        {
            _cache.Add(cacheItem, _policy);
        }

        public void AddItem(string key, object value, string regionName = null)
        {
            _cache.Add(key, value, _policy, regionName);
        }

        public object GetItem(string key, string regionName = null)
        {
            return _cache.Get(key, regionName);
        }

        public void SetItem(string key, object value, string regionName = null)
        {
            _cache.Set(key, value, _policy, regionName);
        }

        public void RemoveItem(string key, string regionName = null)
        {
            _cache.Remove(key, regionName);
        }

        public void PrintAllCacheEntriesToConsole()
        {
            Console.WriteLine("Cached Entries:");
            foreach (var item in _cache)
                Console.WriteLine($"- Cached Entry: {item.Key}");
        }
    }
}
