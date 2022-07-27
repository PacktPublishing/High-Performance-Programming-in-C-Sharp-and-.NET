using System;

namespace CH04_Finalization
{

    using System;

    class Program
    {
        private static Product _product;

        static void Main(string[] _)
        {
            Finalization();
            Disposing();
            UsingDispose();
            using (FreeAllocatedMemory memoryAllocDealloc = new FreeAllocatedMemory())
            {

            }
        }

        private static void Finalization()
        {
            Console.WriteLine("--- Finalization ---");
            InstantiateObject("Finalization");
            PrintObjectData();
            RemoveObjectReference();
            RunGarbageCollector();
            InstantiateLocalObject("Finalization");
            RunGarbageCollector();
            DisplayGeneration(_product);
            RemoveObjectReference();
            RunGarbageCollector();
        }

        private static void Disposing()
        {
            Console.WriteLine("--- Disposing ---");
            InstantiateObject("Disposing");
            PrintObjectData();
            DisposeOfObject();
            InstantiateLocalObject("Disposing");
            DisplayGeneration(_product);
            DisposeOfObject();
            RunGarbageCollector();
        }

        private static void InstantiateObject(string cleanUpMethod)
        {
            Console.WriteLine("Instantiating Product.");
            _product = new Product(cleanUpMethod)
            {
                Id = 1,
                Name = "Polly Parrot",
                Description = "Cudly child's toy.",
                UnitPrice = 7.99M
            };
        }

        private static void PrintObjectData()
        {
            Console.WriteLine(_product.ToString());
        }

        private static void RemoveObjectReference()
        {
            _product = null;
        }

        private static void DisposeOfObject()
        {
            _product.Dispose();
        }

        private static void RunGarbageCollector()
        {
            GC.Collect();
        }

        private static void InstantiateLocalObject(string cleanUpMethod)
        {
            Product product = new Product(cleanUpMethod)
            {
                Id = 2,
                Name = "Cute Kittie",
                Description = "Cudly child's toy.",
                UnitPrice = 5.75M
            };
            DisplayGeneration(product);
            _product = product;
        }

        private static void DisplayGeneration(Product product)
        {
            Console.WriteLine($"local product: generation {GC.GetGeneration(product)}");
        }

        private static void UsingDispose()
        {
            Console.WriteLine("--- UsingDispose() ---");
            using (Product product = new Product("using")
                {
                    Id = 2,
                    Name = "Cute Kittie",
                    Description = "Cudly child's toy.",
                    UnitPrice = 5.75M
                }
            )
            {
                DisplayGeneration(product);
            }
        }
    }
}
