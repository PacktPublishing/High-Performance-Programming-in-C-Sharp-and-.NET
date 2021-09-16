 namespace CH10_DataAccessBenchmarks
{
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Order;
	using CH10_DataAccessBenchmarks.Configuration;
	using CH10_DataAccessBenchmarks.Data;
	using CH10_DataAccessBenchmarks.Models;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;

	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.Declared)]
	[RankColumn]
	public class BenchmarkTests
	{
		[GlobalSetup]
		public void GlobalSetup()
		{
			InsertProductADNSP();
			InsertProductEFSP();
			InsertProductDDN();
		}

		#region ADO.NET Benchmarks

		[Benchmark]
		public void InsertProductADN()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			AdoDotNetData adnData = new(connectionString);
			adnData.ExecuteNonQuery("INSERT INTO Products (ProductName, CategoryID, SupplierId, Discontinued) VALUES('ADO.NET Product', 1, 1, 0)");
			adnData.Dispose();
		}

		[Benchmark]
		public void InsertProductADNSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			AdoDotNetData aaa = new(connectionString);
			SqlCommandModel model = new()
			{
				CommandText = "InsertProduct",
				CommandType = CommandType.StoredProcedure,
				CommandParameters = new SqlCommandParameterModel[] {
					new SqlCommandParameterModel() { ParameterName = "@ProductName", DataType = DbType.String, Value = "Dapper Product Edited" }
					, new SqlCommandParameterModel() { ParameterName = "@CategoryID", DataType = DbType.Int32, Value = 1 }
					, new SqlCommandParameterModel() { ParameterName = "@SupplierID", DataType = DbType.Int32, Value = 1 }
					, new SqlCommandParameterModel() { ParameterName = "@Discontinued", DataType = DbType.Boolean, Value = false }
				}
			};
			aaa.ExecuteNonQuery(model);
			aaa.Dispose();
		}

		[Benchmark]
		public void ReadScalarProductADN()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			AdoDotNetData adnData = new(connectionString);
			string productName = adnData.ExecuteScalar<string>("SELECT TOP 1 ProductName FROM Products  WHERE ProductName LIKE 'ADO.NET Product%'");
			adnData.Dispose();
		}

		[Benchmark]
		public void ReadScalarProductADNSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			AdoDotNetData aaa = new(connectionString);
			SqlCommandModel model = new SqlCommandModel()
			{
				CommandText = "GetProductName",
				CommandType = CommandType.StoredProcedure,
				CommandParameters = new SqlCommandParameterModel[] {
					new SqlCommandParameterModel() { ParameterName = "@ProductName", DataType = DbType.String, Value = "ADO.NET Product" }
				}
			};
			string productName = aaa.ExecuteScalar<string>(model);
			aaa.Dispose();
		}

		[Benchmark]
		public void ReadFilteredProductADN()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			AdoDotNetData adnData = new(connectionString);
			IEnumerator<Product> data = adnData.ExecuteReader<Product>("SELECT * FROM Products  WHERE ProductName LIKE 'ADO.NET Product'");
			adnData.Dispose();
		}

		[Benchmark]
		public void ReadFilteredProductADNSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			AdoDotNetData aaa = new(connectionString);
			SqlCommandModel model = new SqlCommandModel()
			{
				CommandText = "FilterProducts",
				CommandType = CommandType.StoredProcedure,
				CommandParameters = new SqlCommandParameterModel[] {
					new SqlCommandParameterModel() { ParameterName = "@ProductName", DataType = DbType.String, Value = "ADO.NET Product" }
				}
			};
			var data = aaa.ExecuteReader<dynamic>(model);
			aaa.Dispose();
		}

		[Benchmark]
		public void UpdateProductADN()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			AdoDotNetData adnData = new(connectionString);
			int recordsAffected = adnData.ExecuteNonQuery("UPDATE Products SET ProductName = 'ADO.NET Product - Edited' WHERE ProductName = 'ADO.NET Product'");
			adnData.Dispose();
		}

		[Benchmark]
		public void UpdateProductADNSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			AdoDotNetData aaa = new(connectionString);
			SqlCommandModel model = new()
			{
				CommandText = "UpdateProductName",
				CommandType = CommandType.StoredProcedure,
				CommandParameters = new SqlCommandParameterModel[] {
					new SqlCommandParameterModel() { ParameterName = "@OldProductName", DataType = DbType.String, Value = "ADO.NET Product" }
					, new SqlCommandParameterModel() { ParameterName = "@NewProductName", DataType = DbType.String, Value = "ADO.NET Product - Edited" }
				}
			};
			aaa.ExecuteNonQuery(model);
			aaa.Dispose();
		}

		[Benchmark]
		public void DeleteProductADN()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			AdoDotNetData adnData = new(connectionString);
			int recordsAffected = adnData.ExecuteNonQuery("DELETE FROM Products WHERE ProductName LIKE 'ADO.NET Product%'");
			adnData.Dispose();
		}

		[Benchmark]
		public void DeleteProductADNSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			AdoDotNetData aaa = new(connectionString);
			SqlCommandModel model = new()
			{
				CommandText = "DeleteProduct",
				CommandType = CommandType.StoredProcedure,
				CommandParameters = new SqlCommandParameterModel[] {
					new SqlCommandParameterModel() { ParameterName = "@ProductName", DataType = DbType.String, Value = "ADO.NET Product - Edited" }
				}
			};
			aaa.ExecuteNonQuery(model);
			aaa.Dispose();
		}

		#endregion ADO.NET Benchmarks

		#region Entity Framework Benchmarks

		[Benchmark]
		public void InsertProductEF()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			EntityFrameworkCoreData efData = new(connectionString);
			Product product = new() { ProductName = "EF Product", CategoryID = 1, SupplierID = 1, Discontinued = false };
			efData.Products.Add(product);
			efData.SaveChanges();
			efData.Dispose();
		}

		[Benchmark]
		public void InsertProductEFSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			EntityFrameworkCoreData efData = new(connectionString);
			SqlCommandModel model = new()
			{
				CommandText = "EXEC InsertProduct @ProductName = {0}, @CategoryID = {1}, @SupplierID = {2}, @Discontinued = {3}",
				CommandType = CommandType.StoredProcedure,
				CommandParameters = new SqlCommandParameterModel[] {
					new SqlCommandParameterModel() { ParameterName = "@ProductName", DataType = DbType.String, Value = "Dapper Product Edited" }
					, new SqlCommandParameterModel() { ParameterName = "@CategoryID", DataType = DbType.Int32, Value = 1 }
					, new SqlCommandParameterModel() { ParameterName = "@SupplierID", DataType = DbType.Int32, Value = 1 }
					, new SqlCommandParameterModel() { ParameterName = "@Discontinued", DataType = DbType.Boolean, Value = false }
				}
			};
			efData.ExecuteNonQuerySP(model);
			efData.Dispose();
		}

		[Benchmark]
		public void ReadScalarProductEF()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			EntityFrameworkCoreData efData = new(connectionString);
			string productName = efData.Products.FirstOrDefault(p => p.ProductName.Contains("EF Product")).ProductName;
			efData.Dispose();
		}

		[Benchmark]
		public void ReadScalarProductEFSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			EntityFrameworkCoreData efData = new(connectionString);
			string productName = efData.ExecuteScalarSP("EF Product");
			efData.Dispose();
		}

		[Benchmark]
		public void ReadFilteredProductsEF()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			EntityFrameworkCoreData efData = new(connectionString);
			IEnumerator<Product> products = efData.Products.Where(p => p.ProductName.Contains("EF Product")).GetEnumerator();
			efData.Dispose();
			products.Dispose();
		}

		[Benchmark]
		public void ReadFilteredProductsEFSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			EntityFrameworkCoreData efData = new(connectionString);
			IEnumerator<Product> products = efData.ExecuteReaderSP("EF Product");
			efData.Dispose();
			products.Dispose();
		}

		[Benchmark]
		public void UpdateProductEF()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			EntityFrameworkCoreData efData = new EntityFrameworkCoreData(connectionString);
			IQueryable<Product> products = efData.Products.Where(p => p.ProductName.Contains("EF Product"));
			foreach (Product product in products)
				product.ProductName = "EF Product Edited";
			efData.Products.UpdateRange(products);
			int recordsAffected = efData.SaveChanges();
			efData.Dispose();
		}

		[Benchmark]
		public void UpdateProductEFSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			EntityFrameworkCoreData efData = new(connectionString);
			SqlCommandModel model = new()
			{
				CommandText = "EXEC UpdateProductName @OldProductName = {0}, @NewProductName = {1}",
				CommandType = CommandType.StoredProcedure,
				CommandParameters = new SqlCommandParameterModel[] {
					new SqlCommandParameterModel() { ParameterName = "@OldProductName", DataType = DbType.String, Value = "EF Product" }
					, new SqlCommandParameterModel() { ParameterName = "@NewProductName", DataType = DbType.String, Value = "EF Product - Edited" }
				}
			};
			efData.ExecuteNonQuerySP(model);
			efData.Dispose();
		}

		[Benchmark]
		public void DeleteProductEF()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			EntityFrameworkCoreData efData = new EntityFrameworkCoreData(connectionString);
			IQueryable<Product> products = efData.Products.Where(p => p.ProductName.Contains("EF Product"));
			efData.Products.RemoveRange(products);
			int recordsAffected = efData.SaveChanges();
			efData.Dispose();
		}

		[Benchmark]
		public void DeleteProductEFSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			EntityFrameworkCoreData efData = new(connectionString);
			SqlCommandModel model = new()
			{
				CommandText = "EXEC DeleteProduct @ProductName = {0}",
				CommandType = CommandType.StoredProcedure,
				CommandParameters = new SqlCommandParameterModel[] {
					new SqlCommandParameterModel() { ParameterName = "@NewProductName", DataType = DbType.String, Value = "EF Product - Edited" }
				}
			};
			efData.ExecuteNonQuerySP(model);
			efData.Dispose();
		}

		#endregion Entity Framework Benchmarks

		#region Dapper.NET Benchmarks

		[Benchmark]
		public void InsertProductDDN()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			DapperDotNet ddnData = new(connectionString);
			int recordsAffected = ddnData.ExecuteNonQuery("INSERT INTO Products (ProductName, CategoryID, SupplierId, Discontinued) VALUES('Dapper.NET Product', 1, 1, 0)");
			ddnData.Dispose();
		}

		[Benchmark]
		public void InsertProductDDNSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			DapperDotNet ddnData = new(connectionString);
			SqlCommandModel model = new()
			{
				CommandText = "InsertProduct",
				CommandType = CommandType.StoredProcedure,
				CommandParameters = new SqlCommandParameterModel[] {
						new SqlCommandParameterModel() { ParameterName = "@ProductName", DataType = DbType.String, Value = "Dapper Product" }
						, new SqlCommandParameterModel() { ParameterName = "@CategoryID", DataType = DbType.Int32, Value = 1 }
						, new SqlCommandParameterModel() { ParameterName = "@SupplierID", DataType = DbType.Int32, Value = 1 }
						, new SqlCommandParameterModel() { ParameterName = "@Discontinued", DataType = DbType.Boolean, Value = false }
					}
			};
			ddnData.ExecuteNonQuery(model);
			ddnData.Dispose();
		}

		[Benchmark]
		public void ReadScalarProductDDN()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			DapperDotNet ddnData = new(connectionString);
			string productName = ddnData.ExecuteScalar<string>("SELECT TOP 1 ProductName FROM Products  WHERE ProductName LIKE 'Dapper.NET Product%'");
			ddnData.Dispose();
		}

		[Benchmark]
		public void ReadScalarProductDDNSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			DapperDotNet ddnData = new(connectionString);
			SqlCommandModel model = new()
			{
				CommandText = "GetProductName",
				CommandType = CommandType.StoredProcedure,
				CommandParameters = new SqlCommandParameterModel[] {
					new SqlCommandParameterModel() { ParameterName = "@ProductName", DataType = DbType.String, Value = "Dapper Product" }
				}
			};
			string productName = ddnData.ExecuteScalarSP(model);
			ddnData.Dispose();
		}

		[Benchmark]
		public void ReadFilteredProductsDDN()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			DapperDotNet ddnData = new(connectionString);
			IEnumerator<Product> data = ddnData.ExecuteReader<Product>("SELECT * FROM Products WHERE ProductName LIKE 'Dapper.NET Product%'");
			ddnData.Dispose();
			data.Dispose();
		}

		[Benchmark]
		public void ReadFilteredProductsDDNSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			DapperDotNet ddnData = new(connectionString);
			SqlCommandModel model = new()
			{
				CommandText = "GetProductName",
				CommandType = CommandType.StoredProcedure,
				CommandParameters = new SqlCommandParameterModel[] {
					new SqlCommandParameterModel() { ParameterName = "@ProductName", DataType = DbType.String, Value = "Dapper.NET Product" }
				}
			};
			IEnumerator<Product> products = ddnData.ExecuteReaderSP<Product>(model);
			ddnData.Dispose();
		}

		[Benchmark]
		public void UpdateProductDDN()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			DapperDotNet ddnData = new(connectionString);
			int recordsAffected = ddnData.ExecuteNonQuery("UPDATE Products SET ProductName = 'Dapper.NET Product - Edited' WHERE ProductName = 'Dapper.NET Product'");
			ddnData.Dispose();
		}

		[Benchmark]
		public void UpdateProductDDNSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			DapperDotNet ddnData = new(connectionString);
			SqlCommandModel model = new()
			{
				CommandText = "UpdateProductName",
				CommandType = CommandType.StoredProcedure,
				CommandParameters = new SqlCommandParameterModel[] {
						new SqlCommandParameterModel() { ParameterName = "@OldProductName", DataType = DbType.String, Value = "Dapper.NET Product - Edited" }
						, new SqlCommandParameterModel() { ParameterName = "@NewProductName", DataType = DbType.String, Value = "Dapper.NET Product" }
					}
			};
			ddnData.ExecuteNonQuery(model);
			ddnData.Dispose();
		}

		[Benchmark]
		public void DeleteProductDDN()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			DapperDotNet ddnData = new(connectionString);
			int recordsAffected = ddnData.ExecuteNonQuery("DELETE FROM Products WHERE ProductName LIKE 'Dapper.NET Product%'");
			ddnData.Dispose();
		}

		[Benchmark]
		public void DeleteProductDDNSP()
		{
			string connectionString = SecretsManager.GetSecrets<DatabaseSettings>("ConnectionString");
			DapperDotNet ddnData = new(connectionString);
			SqlCommandModel model = new()
			{
				CommandText = "DeleteProduct",
				CommandType = CommandType.StoredProcedure,
				CommandParameters = new SqlCommandParameterModel[] {
						new SqlCommandParameterModel() { ParameterName = "@ProductName", DataType = DbType.String, Value = "Dapper.NET Product - Edited" }
					}
			};
			ddnData.ExecuteNonQuery(model);
			ddnData.Dispose();
		}

		#endregion Dapper.NET Benchmarks

	}
}
