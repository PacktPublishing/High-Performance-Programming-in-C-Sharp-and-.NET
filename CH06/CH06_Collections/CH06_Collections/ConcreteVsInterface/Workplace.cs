namespace CH06_Collections.ConcreteVsInterface
{
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Engines;
	using BenchmarkDotNet.Order;
	using CH06_Collections.Models;
	using System.Collections.Generic;
	using System.Threading;

	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class Workplace
	{
		[Benchmark]
        public void InterfaceWorker()
		{
			IList<Person> person = new List<Person>();
		}

		[Benchmark]
		public void ConcreteWorker()
		{
			List<Person> person = new List<Person>();
		}
    }
}
