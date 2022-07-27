using CH12_ResponsiveASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Text;

namespace CH12_ResponsiveASPNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMemoryCache _memoryCache;
        private IDistributedCache _distributedCache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public string Index()
        {
            DateTime memoryCacheTime = GetMemoryCacheTime();
            string data = GetDistributedCacheString();
            return $"Current Time: {DateTime.UtcNow.ToLocalTime()}\nMemory Cache Time: {memoryCacheTime}\nDistributed Cache String: {data}";
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

        private DateTime GetMemoryCacheTime()
        {
            DateTime currentTime;
            bool alreadyExists = _memoryCache.TryGetValue("CachedTime", out currentTime);
            if (!alreadyExists)
            {
                currentTime = DateTime.UtcNow.ToLocalTime();
                _memoryCache.Set(
                "CachedTime",
                currentTime, MemoryCacheEntryExtensions.SetSlidingExpiration(
                     new MemoryCacheEntryOptions()
                     {
                         SlidingExpiration
                             = TimeSpan.FromMinutes(5)
                     },
                        TimeSpan.FromMinutes(5)
                 ));
            }
            return currentTime;
        }

        private static string Base64Encode(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);
        }

        public static string Base64Decode(string text)
        {
            byte[] bytes = Convert.FromBase64String(text);
            return Encoding.UTF8.GetString(bytes);
        }

        private string GetDistributedCacheString()
        {
            string data = _distributedCache.GetString("StringValue");
            if (data == null)
            {
                data = Base64Encode($"Hello, World! {DateTime.UtcNow.ToLocalTime()}");
                _distributedCache.Set("StringValue",
                Convert.FromBase64String(data),
               new DistributedCacheEntryOptions()
               {
                   AbsoluteExpiration
                        = DateTime.UtcNow.AddMinutes(10),
               });
                data = Base64Decode(data);
            }
            return data;
        }

    }
}
