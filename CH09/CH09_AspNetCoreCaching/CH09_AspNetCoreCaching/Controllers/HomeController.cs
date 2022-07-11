using CH09_AspNetCoreCaching.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Caching.Memory;

namespace CH09_AspNetCoreCaching.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void SetCache(string key, object value)
        {
            var cachedEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(20));
            _memoryCache.Set(key, value, cachedEntryOptions);
        }
    }
}