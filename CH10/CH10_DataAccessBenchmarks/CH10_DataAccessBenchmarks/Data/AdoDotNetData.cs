namespace CH10_DataAccessBenchmarks.Data
{
	using CH10_DataAccessBenchmarks.Models;
	using CH10_DataAccessBenchmarks.Reflection;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Data.Common;
	using System.Data.SqlClient;
	using System.Reflection;

	internal class AdoDotNetData : IDisposable
	{
		private readonly SqlConnection _sqlConnection;
		private bool _isDisposed;

		public AdoDotNetData(string connectionString)
		{
			_sqlConnection = new SqlConnection(connectionString);
		}

		internal int ExecuteNonQuery(string sql)
		{
			try
			{
				_sqlConnection.Open();
				return new SqlCommand(sql, _sqlConnection)
					.ExecuteNonQuery();
			}
			finally
			{
				_sqlConnection.Close();
			}
		}

		internal void ExecuteNonQuery(SqlCommandModel model)
		{
			SqlCommand sqlCommand = new (model.CommandText, _sqlConnection);
			sqlCommand.CommandType = model.CommandType;
			foreach (SqlCommandParameterModel parameter in model.CommandParameters)
				sqlCommand.Parameters.Add(new SqlParameter()
				{
					ParameterName = parameter.ParameterName,
					DbType = parameter.DataType,
					Value = parameter.Value
				});
			_sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			_sqlConnection.Close();
		}

		internal T ExecuteScalar<T>(string sql)
		{
			try
			{
				_sqlConnection.Open();
				return (T)new SqlCommand(sql, _sqlConnection)
					.ExecuteScalar();
			}
			finally
			{
				_sqlConnection.Close();
			}
		}

		internal T ExecuteScalar<T>(SqlCommandModel model)
		{
			SqlCommand sqlCommand = new(model.CommandText, _sqlConnection);
			sqlCommand.CommandType = model.CommandType;
			foreach (SqlCommandParameterModel parameter in model.CommandParameters)
				sqlCommand.Parameters.Add(new SqlParameter()
				{
					ParameterName = parameter.ParameterName,
					DbType = parameter.DataType,
					Value = parameter.Value
				});
			_sqlConnection.Open();
			T data = (T)sqlCommand.ExecuteScalar();
			_sqlConnection.Close();
			return data;
		}

		internal IEnumerator<T> ExecuteReader<T>(string sql)
		{
			Type TypeT = typeof(T);
			ConstructorInfo ctor = TypeT.GetConstructor(Type.EmptyTypes);
			if (ctor == null)
			{
				throw new InvalidOperationException($"Type {TypeT.Name} does not have a default constructor.");
			}
			_sqlConnection.Open();

			IEnumerator data = new SqlCommand(sql, _sqlConnection).ExecuteReader().GetEnumerator();
			
			while (data.MoveNext())
			{
				T newInst = (T)ctor.Invoke(null);
				DbDataRecord record = (DbDataRecord)data.Current;
				int fieldCount = Properties.GetFieldCount((DbDataRecord)data.Current);

				for (int i = 0; i < fieldCount; i++)
				{
					string propertyName = record.GetName(i);
					PropertyInfo propertyInfo = TypeT.GetProperty(propertyName);
					if (propertyInfo != null)
					{
						object value = record[i];
						if (value == DBNull.Value)
							propertyInfo.SetValue(newInst, null);
						else
							propertyInfo.SetValue(newInst, value);
					}
				}
				yield return newInst;
			}
		}

		internal IEnumerator<T> ExecuteReader<T>(SqlCommandModel model)
		{
			Type TypeT = typeof(T);
			ConstructorInfo ctor = TypeT.GetConstructor(Type.EmptyTypes);
			if (ctor == null)
			{
				throw new InvalidOperationException($"Type {TypeT.Name} does not have a default constructor.");
			}
			SqlCommand sqlCommand = new(model.CommandText, _sqlConnection);
			sqlCommand.CommandType = model.CommandType;
			foreach (SqlCommandParameterModel parameter in model.CommandParameters)
				sqlCommand.Parameters.Add(new SqlParameter()
				{
					ParameterName = parameter.ParameterName,
					DbType = parameter.DataType,
					Value = parameter.Value
				});
			_sqlConnection.Open();
			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					T newInst = (T)ctor.Invoke(null);
					for (int i = 0; i < reader.FieldCount; i++)
					{
						string propertyName = reader.GetName(i);
						PropertyInfo propertyInfo = TypeT.GetProperty(propertyName);
						if (propertyInfo != null)
						{
							object value = reader[i];
							if (value == DBNull.Value)
								propertyInfo.SetValue(newInst, null);
							else
								propertyInfo.SetValue(newInst, value);
						}
					}
					yield return newInst;
				}
			}
			_sqlConnection.Close();
		}

		public void Dispose()
		{
			Dispose(_isDisposed);
		}

		public void Dispose(bool disposing)
		{
			if (disposing)
			{
				_sqlConnection.Dispose();
				_isDisposed = true;
			}
		}
	}
}
