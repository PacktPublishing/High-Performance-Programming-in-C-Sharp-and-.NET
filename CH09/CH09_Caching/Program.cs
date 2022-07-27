using System;
using System.Runtime.Caching;

namespace CH09_Caching
{
	class Program
	{
		static void Main(string[] args)
        {
            InMemoryCache cache = new(DateTimeOffset.UtcNow.AddMinutes(1));

            cache.AddItem("Item 1", "Value 1");
            cache.AddItem("Item 2", 23.5);
            cache.AddItem("Item 3", DateTime.UtcNow.ToLongDateString());

            cache.PrintAllCacheEntriesToConsole();

            Console.WriteLine($"Item 1: {cache.GetItem("Item 1")}");
            Console.WriteLine($"Item 2: {cache.GetItem("Item 2")}");
            Console.WriteLine($"Item 3: {cache.GetItem("Item 3")}");

            cache.RemoveItem("Item 2");
            cache.SetItem("Item 1", "Salut tout le monde!");

            cache.PrintAllCacheEntriesToConsole();

            Console.WriteLine($"Item 1: {cache.GetItem("Item 1")}");
            Console.WriteLine($"Item 3: {cache.GetItem("Item 3")}");
        }
    }
}
