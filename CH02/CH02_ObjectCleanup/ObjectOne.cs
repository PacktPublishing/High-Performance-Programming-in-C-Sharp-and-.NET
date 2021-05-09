using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CH02_ObjectCleanup
{
    public class ObjectOne : DisposableBase
    {
        ~ObjectOne()
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
                Console.WriteLine("Object one is being disposed.");
            }
            _disposed = true;
        }
    }
}
