namespace CH04_Finalization
{
    using System;
    using System.Runtime.InteropServices;

    public class FreeAllocatedMemory : DisposableBase
    {
        private IntPtr _buffer;

        public FreeAllocatedMemory()
        {
            _buffer = Marshal.AllocHGlobal(1000);
        }

        protected override void ReleaseUnmanagedResources()
        {
            base.ReleaseUnmanagedResources();
            Marshal.FreeHGlobal(_buffer);
        }
    }
}
