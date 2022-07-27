namespace CH08_FileAndStreamIO.Serialization
{
	using System;

	[Serializable]
	public class ClassTwo
	{
		public byte Id { get; set; } = byte.MaxValue;
		public string Name { get; set; } = "The quick brown fox jumped over the lazy dog";
	}
}
