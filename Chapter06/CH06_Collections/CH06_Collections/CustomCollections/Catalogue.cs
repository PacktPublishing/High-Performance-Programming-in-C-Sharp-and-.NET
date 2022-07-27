using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH06_Collections.CustomCollections
{

	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Engines;
	using BenchmarkDotNet.Order;

	using CH06_Collections.CustomCollections;
	using CH06_Collections.Models;

	using System.Collections;
	using System.Collections.Generic;
	using System.Threading;

	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class Catalogue : ICollection
	{
		private Product[] Products;

		public int Count => Products.Length;

		public bool IsSynchronized => false;

		public object SyncRoot => this;

		public Catalogue()
		{
			Products = Array.Empty<Product>();
		}

		public Catalogue(Product[] products)
		{
			this.Products = products;
		}

		[Benchmark]
		public void Add(Product product)
		{
			Products = Products.Append<Product>(product);
		}

		[Benchmark]
		public Product Get(int index)
		{
			return Products.Get<Product>(index);
		}

		[Benchmark]
		public int IndexOf(string match)
		{
			
			return Array.IndexOf<Product>(
				Products, 
				Products
					.Where(
						p => p.ToString().Contains(match)
					)
					.FirstOrDefault());
		}

		[Benchmark]
		public IEnumerator GetEnumerator()
		{
			return Products.GetEnumerator();
		}

		[Benchmark]
		public void Remove(int index)
		{
			Products = Products.Remove<Product>(index);
		}

		public void CopyTo(Array array, int index)
		{
			foreach(Product product in Products)
			{
				array.SetValue(product, index);
				index++;
			}
		}
	}
}
