namespace CH10_DataAccessBenchmarks
{
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.Reflection;

	public static class Extensions
	{
        public static IEnumerable<T> Query<T>(this SqlConnection cn, string sql)
        {
            Type TypeT = typeof(T);
            ConstructorInfo ctor = TypeT.GetConstructor(Type.EmptyTypes);
            if (ctor == null)
            {
                throw new InvalidOperationException($"Type {TypeT.Name} does not have a default constructor.");
            }
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        T newInst = (T)ctor.Invoke(null);
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string propName = reader.GetName(i);
                            PropertyInfo propInfo = TypeT.GetProperty(propName);
                            if (propInfo != null)
                            {
                                object value = reader.GetValue(i);
                                if (value == DBNull.Value)
                                {
                                    propInfo.SetValue(newInst, null);
                                }
                                else
                                {
                                    propInfo.SetValue(newInst, value);
                                }
                            }
                        }
                        yield return newInst;
                    }
                }
            }
        }
    }
}
