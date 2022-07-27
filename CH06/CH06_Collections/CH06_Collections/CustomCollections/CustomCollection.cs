namespace CH06_Collections.CustomCollections
{
	using System.Collections;

	public class CustomCollection : CollectionBase
	{
		public void Add(object item)
		{
			InnerList.Add(item);
		}

		public void Remove(object item)
		{
			InnerList.Remove(item);
		}

		public new void Clear()
		{
			InnerList.Clear();
		}

		public new int Count()
		{
			return InnerList.Count;
		}
	}
}
