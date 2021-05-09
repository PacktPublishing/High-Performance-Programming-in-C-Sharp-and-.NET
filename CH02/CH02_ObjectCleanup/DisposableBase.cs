using System;

namespace CH02_ObjectCleanup
{
    public abstract class DisposableBase : IDisposable
    {
        protected bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                // Free up any managed objects here.
            }
            // Free up an unmanaged objects here.
            // Set large fields to null.
            _disposed = true;
        }

        ~DisposableBase()
        {
            Dispose(false);
        }
    }
}
