namespace CH06_Collections
{
	using System;

	internal class Indexers
	{
		private string[] _items;

		public Indexers(int size)
		{
			_items = new string[size];
		}

		public string this[int index]
		{
			get
			{
				if (IsValidIndex(index))
					return _items[index];
				else
					return string.Empty;
			}
			set
			{
				if (IsValidIndex(index))
					_items[index] = value;
			}
		}

		private bool IsValidIndex(int index)
		{
			return index > -1 && index < _items.Length;
		}

		public int this[string item]
		{
			get
			{
				return Array.IndexOf(_items, item);
			}
		}
	}
}
