namespace CH10_DataAccessBenchmarks.Reflection
{
	using System.Data.Common;
	using System.Reflection;

	internal class Properties
	{
		public static int GetFieldCount(DbDataRecord record)
		{
			return GetValue<int, DbDataRecord>(record, "FieldCount");
		}

		//public static PropertyInfo[] GetProperties<T>(T source, BindingFlags bindingFlags)
		//{
		//	return source.GetType().GetProperties(bindingFlags);
		//}

		public static PropertyInfo GetProperty<T>(string name)
		{
			return typeof(T).GetProperty(name);
		}

		public static T GetValue<T, U>(U source, string name)
		{
			return (T)GetProperty<U>(name).GetValue(source);
		}
	}
}
