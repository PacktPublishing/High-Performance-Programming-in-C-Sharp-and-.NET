namespace CH04_Finalization
{
    using System;

    public class DisposableBase : IDisposable
    {
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        public void Dispose()
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
                GC.SuppressFinalize(this);
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
            ReleaseManagedResources();
            ReleaseUnmanagedResources();
        }

        protected virtual void ReleaseManagedResources()
        {

        }

        protected virtual void ReleaseUnmanagedResources()
        {

        }
    }
}
