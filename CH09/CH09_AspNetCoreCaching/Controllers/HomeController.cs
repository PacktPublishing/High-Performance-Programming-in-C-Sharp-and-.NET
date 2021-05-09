namespace CH09_AspNetCoreCaching.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Threading.Tasks;

	[Route("Home/Index")]
	public class HomeController : Controller
	{
		private IMemoryCache _memoryCache;

		public HomeController(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		public IActionResult Index()
		{
			DateTime whenCached;
			bool exists = _memoryCache.TryGetValue("WhenCached", out whenCached);
			if (!exists)
			{
				Debug.WriteLine("Creating cached entry...");
				whenCached = DateTime.Now;
				SetCache("WhenCached", whenCached);
			}
			else
			{
				DateTime now = DateTime.Now;
				double differenceInSeconds = now.Subtract(whenCached).TotalSeconds;
				if (differenceInSeconds < 20)
				{
					Debug.WriteLine($"Now: {now}, When Cached: {whenCached}, Time Difference (Seconds): {differenceInSeconds}");
					return View(whenCached);
				}
				else
				{
					Debug.WriteLine("Resetting cache...");
					whenCached = DateTime.Now;
					SetCache("WhenCached", whenCached);
				}
			}
			return View(whenCached);
		}

		private void SetCache(string key, object value)
		{
			var cachedEntryOptions = new MemoryCacheEntryOptions()
				.SetSlidingExpiration(TimeSpan.FromSeconds(20));
			_memoryCache.Set(key, value, cachedEntryOptions);
		}
	}
}
