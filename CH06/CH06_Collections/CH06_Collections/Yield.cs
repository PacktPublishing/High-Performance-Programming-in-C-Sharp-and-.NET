namespace CH06_Collections
{
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Order;
	using System;
	using System.Collections.Generic;
	using System.Linq;

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

        public IEnumerable<object[]> GetValues()
        {
            return new List<object[]>
			{
			   new object[] { 1, 2, 3 },
			   new object[] { -1, -2, -3 }
			};
        }

		public IEnumerable<object[]> GetValuesYield ()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { -1, -2, -3 };
        }
    }
}
