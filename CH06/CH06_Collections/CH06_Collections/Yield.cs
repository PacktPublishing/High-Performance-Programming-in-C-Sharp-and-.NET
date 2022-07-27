namespace CH06_Collections
{
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Order;
	using System;
	using System.Collections.Generic;

	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.Declared)]
	[RankColumn]
	public class Yield
	{
		public void YieldSample()
		{
			DoCountdown();
			PrintMonthsOfYear();
			DoBreakIteration();
		}

		private void DoCountdown()
		{
			foreach (int x in Countdown())
				Console.WriteLine(x);
		}

		private IEnumerable<int> Countdown()
		{
			for (int x = 10; x >= 0; x--)
				yield return x;
		}

		private void PrintMonthsOfYear()
		{
			foreach (Month month in new Months().MonthsOfYear)
				Console.WriteLine($"{month.Name} is month {month.MonthOfYear} of the year.");
		}

		private void DoBreakIteration()
		{
			foreach (int x in BreakIteration())
				Console.WriteLine($"Line {x}:");
		}

		private IEnumerable<int> BreakIteration()
		{
			int x = 0;
			while (x < 20)
			{
				if (x < 15)
					yield return x;
				else
					yield break;
				x++;
			}
		}

		[Benchmark]
		public void GetValuesBenchmark()
		{
			var data = GetValues();
		}

		[Benchmark]
		public void GetValuesYieldBenchmark()
		{
			var data = GetValuesYield();
		}

		public IEnumerable<long> GetValues()
		{
			List<long> list = new List<long>();
			for (long i = 0; i < 1000000; i++)
				list.Add(i);
			return list;
		}

		public IEnumerable<long> GetValuesYield()
		{
			for (long i = 0; i < 1000000; i++)
				yield return i;
		}
	}
}
