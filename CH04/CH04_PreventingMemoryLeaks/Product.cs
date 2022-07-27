using System;

namespace CH04_PreventingMemoryLeaks
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

        public Product()
        {
            Console.WriteLine("Product created.");
        }

        ~Product()
        {
            Console.WriteLine("Product destroyed.");
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Unit Price: {UnitPrice}";
        }
    }
}
