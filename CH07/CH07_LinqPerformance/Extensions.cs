namespace CH07_LinqPerformance
{
	using Newtonsoft.Json;
	using Newtonsoft.Json.Serialization;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public static class Extensions
	{
		public static string SerializeList<T>(this IEnumerable<T> list)
		{
			return JsonConvert.SerializeObject(list);
		}

		public static IEnumerable<T> DeserializeList<T>(this string json)
		{
			return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
		}

		public static void PrintJsonData<T>(this IEnumerable<T> list)
		{
			list.SerializeList().WriteLine();
		}

		public static void PrintObjectData<T>(this IEnumerable<T> list, string propertyName)
		{
			List<T> data = list.ToList();
			foreach(var t in data)
				t
					.GetType()
					.GetProperty(propertyName)
					.GetValue(t, null)
					.WriteLine();
		}

		public static void WriteLine(this object item)
		{
			Console.WriteLine(item);
		}

		public static T LastItem<T>(this IEnumerable<T> enumerable)
		{
			if (enumerable is IList<T> list)
				return list[list.Count - 1];
			T item = default(T);
			foreach (T record in enumerable)
				item = record;
			return item;
		}

		public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
		{
			if (source == null) throw new Exception("Argument Null Exception: source");
			IList<TSource> list = source as IList<TSource>;
			if (list != null)
			{
				if (list.Count > 0) return list[0];
			}
			else
			{
				using (IEnumerator<TSource> e = source.GetEnumerator())
				{
					if (e.MoveNext()) return e.Current;
				}
			}
			return default(TSource);
		}

		public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			if (source == null) throw new Exception("Argument Null Exception: source");
			if (predicate == null) throw new Exception("Argument Null Exception: predicate");
			foreach (TSource element in source)
			{
				if (predicate(element)) return element;
			}
			return default(TSource);
		}

		public static bool Between(this string name, char firstLetter, char lastLetter)
		{
			char letter = char.Parse(name.Substring(0, 1));
			return letter >= firstLetter && letter <= lastLetter;
		}
	}
}
