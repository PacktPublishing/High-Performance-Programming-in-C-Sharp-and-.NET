namespace CH06_Collections.CustomCollections
{
	using System;
	using System.Linq;

	internal static class CollectionExtensions
	{
		public static T[] Append<T>(this T[] array, T item)
		{
			if (array == null)
				return new T[] { item };
			T[] result = new T[array.Length + 1];
			array.CopyTo(result, 0);
			result[array.Length] = item;
			return result;
		}

		public static T Get<T>(this T[] array, int index)
		{
			if (array == null || index < 0)
				return default(T);
			return array[index];
		}

		public static T[] Remove<T>(this T[] array, int index)
		{
			var items = array.ToList();
			items.RemoveAt(index);
			return items.ToArray();
		}
	}
}