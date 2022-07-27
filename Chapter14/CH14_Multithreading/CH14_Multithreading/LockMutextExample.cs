using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_Multithreading
{
    internal class LockMutextExample
    {
        private object _lockObject = new();
        private static readonly Mutex _mutex = new();

        public void UsingLockObject()
        {
            lock(_lockObject)
            {
                // Perform your unsafe code here.
            }
        }

        public void UsingMutext()
        {
            try
            {
                _mutex.WaitOne();
                // ... Do work here ...
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
    }
}
