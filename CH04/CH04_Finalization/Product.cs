namespace CH04_Finalization
{
    using System;
    using System.ComponentModel.DataAnnotations;

    internal class Product : DisposableBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

        private string _cleanUpMethod;

        public Product(string cleanUpMethod)
        {
            Console.WriteLine("Product constructor.");
            _cleanUpMethod = cleanUpMethod;
        }

        ~Product()
        {
            Console.WriteLine($"Product finalizer: {_cleanUpMethod}.");
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Unit Price: {UnitPrice}";
        }

        protected override void ReleaseManagedResources()
        {
            base.ReleaseManagedResources();
            Console.WriteLine("Releasing managed resources.");
        }

        protected override void ReleaseUnmanagedResources()
        {
            base.ReleaseUnmanagedResources();
            Console.WriteLine("Releasing unmanaged resources.");
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(object);
        }
    }
}
