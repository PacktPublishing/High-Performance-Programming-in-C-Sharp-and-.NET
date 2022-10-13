namespace CH06_Collections
{
	using System;
	using System.IO;
	using BenchmarkDotNet.Running;
	using CH06_Collections.ConcreteVsInterface;
	using CH06_Collections.CustomCollections;
	using CH06_Collections.Models;

	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<Yield>();
		}

		private static void IndexerExample()
		{
			Indexers indexers = new Indexers(1000);
			for (int i = 0; i < 1000; i++)
				indexers[i] = $"Item {i}";
			Console.WriteLine($"The item at position 500 is \"{indexers[500]}\".");
			Console.WriteLine($"The index of \"Item 500\" is {indexers["Item 500"]}.");
		}

		private static void Yield()
		{
			var yieldToMe = new Yield();
			yieldToMe.YieldSample();

			int data1Count = 0;
			int data2Count = 0;

			var data1 = yieldToMe.GetValues();

			var data1Enumerator = data1.GetEnumerator();

			while (data1Enumerator.MoveNext())
				data1Count++;

			var data2 = yieldToMe.GetValuesYield();


			var data2Enumerator = data2.GetEnumerator();

			while (data2Enumerator.MoveNext())
				data2Count++;
		}
	}
}
