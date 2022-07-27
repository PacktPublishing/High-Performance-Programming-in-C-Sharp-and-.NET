namespace CH02_PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    class Program
    {
        [DllImport("CH02_NativeLibrary.dll",
            CallingConvention = CallingConvention.StdCall
        )]
        public static extern void SendGreeting();
        [DllImport("CH02_NativeLibrary.dll", EntryPoint = "Add",
            CallingConvention = CallingConvention.StdCall
        )]
        public static extern int AddIntegers(int x, int y);
        [DllImport("CH02_NativeLibrary.dll",
            CallingConvention = CallingConvention.StdCall
        )]
        public static extern bool IsLengthGreaterThan5(string value);
        [DllImport("CH02_NativeLibrary.dll",
            CallingConvention = CallingConvention.StdCall
        )]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetName();
        [DllImport("CH02_NativeLibrary.dll",
            CallingConvention = CallingConvention.StdCall
        )]
        public static extern void BuyProduct(Product product);
        [DllImport("CH02_NativeLibrary.dll")]
        public static extern Product CreateProduct();


        static void Main(string[] _)
        {
            SendGreeting();
            Console.WriteLine($"1 + 2 = {AddIntegers(1, 2)}");
            var answer = IsLengthGreaterThan5("C# is awsome!") ? "Yes." : "No.";
            Console.WriteLine($"Is \"C# is awsome!\" > than 5? {answer}");
            Console.WriteLine($"Publisher Name: {GetName()}");
            var product = CreateProduct();
            Console.WriteLine($"Product: {product.Name}");
            BuyProduct(product);
            Console.ReadKey();
        }
    }
}
