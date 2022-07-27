using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CH02_ObjectCleanup
{
    class ObjectTwo : ObjectOne
    {
        ~ObjectTwo()
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
                Console.WriteLine("Object two is being disposed.");
            }
            _disposed = true;
        }
    }
}
