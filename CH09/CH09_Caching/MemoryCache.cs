namespace CH09_Caching
{
	using Microsoft.Extensions.Caching.Memory;
	using System;

	internal class MemoryCache<TItem>
	{
		private MemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

		public TItem GetCachedItem(object key, Func<TItem> item)
		{
			TItem cachedItem;
			if (!_memoryCache.TryGetValue(key, out cachedItem))
			{
				//cachedItem = item;
				_memoryCache.Set(key, cachedItem);
			}
			return cachedItem;
		}
	}
}
