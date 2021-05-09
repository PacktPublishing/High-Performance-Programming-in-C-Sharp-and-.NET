namespace CH08_FileAndStreamIO.Serialization
{
	using System;

	[Serializable]
	public class ClassOne
	{
		public int Id { get; set; } = int.MaxValue;
		public string ThisIsAReallyLongFieldName { get; set; } = "The quick brown fox jumped over the lazy dog.";
	}
}
