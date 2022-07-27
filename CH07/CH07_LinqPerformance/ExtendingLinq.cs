namespace CH07_LinqPerformance
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public interface Predicate<T>
	{
		bool match(T item);
	}

	internal class ExtendingLinq
	{
		private List<Person> _people = new List<Person>();

		public delegate bool Predicate<T>(T obj);

		public ExtendingLinq()
		{
			AddPeople();
		}

		private void AddPeople()
		{
			_people.Add(new Person("Alpha", "Beta"));
			_people.Add(new Person("Chi", "Delta"));
			_people.Add(new Person("Epsilon", "Phi"));
			_people.Add(new Person("Gamma", "iota"));
			_people.Add(new Person("Kappa", "Lambda"));
			_people.Add(new Person("Mu", "Nu"));
			_people.Add(new Person("Omicron", "Pi"));
			_people.Add(new Person("Theta", "Rho"));
			_people.Add(new Person("Sigma", "Tau"));
			_people.Add(new Person("Upsilon", "Omega"));
			_people.Add(new Person("Xi", "Psi"));
			_people.Add(new Person("Zeta", "Iota"));
			_people.Add(new Person("Alpha", "Omega"));
			_people.Add(new Person("Omega", "Chi"));
			_people.Add(new Person("Sigma", "Tau"));
		}

		public void PrintJsonData()
		{
			_people.PrintJsonData();
		}

		public void PrintObjectData()
		{
			Console.WriteLine("######################################################");
			_people.PrintObjectData<Person>("FullName");
		}

		public void SerializeDeserialize()
		{
			List<Person> people = DeserializeFromJson(SerializeToJson());
			Console.WriteLine($"Number of People: {people.Count}");
		}

		public string SerializeToJson()
		{
			return _people.SerializeList();
		}

		public List<Person> DeserializeFromJson(string json)
		{
			return json.DeserializeList<Person>().ToList();
		}

		public IList<T> Filter<T>(IList<T> source, Predicate<T> predicate)
		{
			List<T> ret = new List<T>();
			foreach (T item in source)
			{
				if (predicate(item))
				{
					ret.Add(item);
				}
			}
			return ret;
		}

		public void Closures()
		{
			
		}
	}
}
