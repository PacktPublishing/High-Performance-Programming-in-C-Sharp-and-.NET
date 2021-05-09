using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CH02_ObjectCleanup
{
    class ObjectThree : ObjectTwo
    {
        ~ObjectThree()
        {
            Dispose(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                // Free up any managed objects here.
                Console.WriteLine("Object three is being disposed.");
            }
            // Free up any unmanaged objects here.
            Console.WriteLine("Free unmanaged objects.");
            Console.WriteLine("Override a finalizer.");
            Console.WriteLine("Set large fields to null");
            _disposed = true;
        }
    }
}
