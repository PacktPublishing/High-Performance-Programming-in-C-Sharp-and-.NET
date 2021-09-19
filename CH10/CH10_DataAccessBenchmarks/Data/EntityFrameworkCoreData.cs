using CH10_DataAccessBenchmarks.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

namespace CH10_DataAccessBenchmarks.Data
{
   public class EntityFrameworkCoreData : DbContext
   {
		private string _connectionString = string.Empty;

		public DbSet<Product> Products { get; set; }

		public EntityFrameworkCoreData(string connectionString) : base(GetOptions(connectionString))
		{
			_connectionString = connectionString;
		}

		private static DbContextOptions GetOptions(string connectionString)
		{
			return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}

		public int ExecuteSQL(string sql)
		{
			return Database.ExecuteSqlRaw(sql, null);
		}

		public int ExecuteNonQuerySP(SqlCommandModel model)
		{
			SqlParameter[] parameters
		 = new SqlParameter[model.CommandParameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				parameters[i] = new SqlParameter(
				model.CommandParameters[i].ParameterName,
			 model.CommandParameters[i].Value
			 );
			}
			if (parameters.Length == 4)
				return Database.ExecuteSqlRaw(
				 model.CommandText, parameters[0],
				 parameters[1], parameters[2],
				 parameters[3]
			 );
			else if (parameters.Length == 2)
				return Database.ExecuteSqlRaw(
					model.CommandText, parameters[0],
					parameters[1]
				);
			else
				return Database.ExecuteSqlRaw(
					model.CommandText, parameters[0]
				);
		}

		public string ExecuteScalarSP(string productName)
		{
			return Products.FromSqlRaw(
				"EXEC FilterProducts @ProductName={0}",
				new SqlParameter()
				{
					ParameterName = "@ProductName",
					Value = productName
				}
				).AsEnumerable().FirstOrDefault().ProductName;
		}

		public IEnumerator<Product> ExecuteReaderSP(string productName)
		{
			return Products.FromSqlRaw(
					"EXEC FilterProducts @ProductName={0}",
					new SqlParameter()
					{
						ParameterName = "@ProductName",
						Value = productName
					}
				 ).GetEnumerator();
		}

	}
}
