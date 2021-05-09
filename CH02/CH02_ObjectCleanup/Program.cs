using System;

namespace CH02_ObjectCleanup
{
    class Program
    {
        static void Main(string[] _)
        {
            var objectThree = new ObjectThree();
            objectThree.Dispose();
        }
    }
}
