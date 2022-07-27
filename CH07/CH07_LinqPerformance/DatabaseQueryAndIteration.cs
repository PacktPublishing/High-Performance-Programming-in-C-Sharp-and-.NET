namespace CH07_LinqPerformance
{
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Order;
	using CH07_LinqPerformance.Configuration;
	using CH07_LinqPerformance.Data;
	using CH07_LinqPerformance.Models;
	using Microsoft.Extensions.Options;
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;

	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.Declared)]
	[RankColumn]
	public class DatabaseQueryAndIteration : IDisposable
	{
		private DatabaseContext _context;
		private bool disposedValue;

		[GlobalSetup]
		public void GlobalSetup()
		{
			var connectionString = SecretsManager.GetSecrets<DatabaseSettings>(nameof(DatabaseSettings)).ConnectionString;
			_context = new DatabaseContext(connectionString);
		}

		[Benchmark]
		public void QueryDb()
		{
			var products = (from p in _context.Products
							where p.Id > 1
							select p);
			foreach (var product in products)
				Debug.WriteLine(product.Name);
		}

		[Benchmark]
		public void QueryDbAsList()
		{
			List<Product> products = (from p in _context.Products
							where p.Id > 1
							select p).ToList<Product>();
			foreach (var product in products)
				Debug.WriteLine(product.Name);
		}

		[Benchmark]
		public void QueryDbAsIEnumerable()
		{
			var products = (from p in _context.Products
							where p.Id > 1
							select p).AsEnumerable<Product>();
			foreach (var product in products)
				Debug.WriteLine(product.Name);
		}

		[Benchmark]
		public void QueryDbAsIEnumerator()
		{
			var products = (from p in _context.Products
							where p.Id > 1
							select p).GetEnumerator();
			while (products.MoveNext())
				Debug.WriteLine(products.Current.Name);
		}

		[Benchmark]
		public void QueryDbAsIQueryable()
		{
			var products = (from p in _context.Products
							where p.Id > 1
							select p).AsQueryable<Product>();
			foreach (var product in products)
				Debug.WriteLine(product.Name);
		}

		[GlobalCleanup]
		public void GlobalCleanup()
		{
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_context.Dispose();
				}
				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
