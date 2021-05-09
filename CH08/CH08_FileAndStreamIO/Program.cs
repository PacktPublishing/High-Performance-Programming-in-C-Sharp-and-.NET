using CH08_FileAndStreamIO.Serialization;
using System;
using System.Linq;
using BenchmarkDotNet.Running;
using CH08_FileAndStreamIO;

namespace CH08_FileAndStreamIO
{
	class Program
	{
		static void Main(string[] args)
		{
			RunLocalStorageTest();
		}

		static void RunLocalStorageTest()
		{
			var localStorage = new LocalStorage();
			localStorage.ClearInMemoryContents();
			localStorage.DeletePersistedFile();
			Console.WriteLine($"Local StorageCount: {localStorage.ItemCount()}");
			localStorage.Persist();
			localStorage.Set("int", 1234567);
			int localInt = localStorage.Get<int>("int");
			localStorage.Set("double", 0.123456789);
			double localDouble = localStorage.Get<double>("double");
			localStorage.Set("string", "Beans, eggs, battered fish, and fries.");
			string localString = localStorage.Get<string>("string");
			localStorage.Set("string", "Sausage, eggs, plum tomatoes, and hash browns.");
			localString = localStorage.Get<string>("string");
			localStorage.Set<string[]>("string[]", new string[] {
				"The rain in Spain falls mainly on the plains.",
				"The Sun in Australia is very hot and burns!"
			});
			var data = localStorage.Query<string>(
					"string[]",
					x => x.Contains("Australia")
				).FirstOrDefault();
			Console.WriteLine($"Local StorageCount: {localStorage.ItemCount()}");
		}
	}
}
