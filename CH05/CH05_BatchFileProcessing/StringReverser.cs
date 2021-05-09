namespace CH05_BatchFileProcessing
{
	using System;

    internal class StringReverser
    {
        private readonly string _original;

        public StringReverser(string original)
        {
            _original = original;
        }

		public string Reverse()
		{
			char[] charArray = _original.ToCharArray();
			string stringResult = null;

			for (int i = charArray.Length; i > 0; i--)
			{
				stringResult += charArray[i - 1];
			}
			return stringResult;
		}

		// Fixed reverse method that improves performance.
		//public string Reverse()
		//{
		//	char[] charArray = _original.ToCharArray();
		//	Array.Reverse(charArray);
		//	return new string(charArray);
		//}
	}
}
