namespace CH08_FileAndStreamIO
{
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Order;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Text;

	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.Declared)]
	[RankColumn]
	public class LocalStorage
	{
		private Hanssens.Net.LocalStorage _storage;

		public LocalStorage()
		{
			_storage = new Hanssens.Net.LocalStorage();
		}
		public int ItemCount() => _storage.Count;
		
		public void ClearInMemoryContents()
		{
			_storage.Clear();
		}

		public void DeletePersistedFile()
		{
			_storage.Destroy();
		}

		public void Load()
		{
			_storage.Load();
		}

		public void Persist()
		{
			_storage.Persist();
		}

		public void Set(string key, object value) => _storage.Store(key, value);

		public void Set<T>(string key, T value) 
		{
			_storage.Store<T>(key, value);
		}

		public object Get(string key)
		{
			return _storage.Get(key);
		}

		public T Get<T>(string key)
		{
			return _storage.Get<T>(key);
		}

		public IEnumerable<T> Query<T>(string key, Func<T, bool> predicate = null)
		{
			if (predicate == null)
				return _storage.Query<T>(key);
			return _storage.Query<T>(key, predicate);
		}
	}
}
