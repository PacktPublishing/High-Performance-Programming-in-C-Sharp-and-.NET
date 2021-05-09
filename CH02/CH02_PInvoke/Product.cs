namespace CH02_PInvoke
{
	using System.Runtime.InteropServices;

	[StructLayout(LayoutKind.Sequential)]
	public struct Product
	{
		public int Id;
        [MarshalAs(UnmanagedType.BStr)]
        public string Name;
    }
}