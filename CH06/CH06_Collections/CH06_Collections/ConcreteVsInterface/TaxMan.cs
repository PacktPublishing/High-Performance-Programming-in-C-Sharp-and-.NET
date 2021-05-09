namespace CH06_Collections.ConcreteVsInterface
{
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Engines;
	using BenchmarkDotNet.Order;
	using System.Collections.Generic;
	using System.Threading;

	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class TaxMan
	{
		[Benchmark]
		public void BasicRateInterface()
		{
			IList<BasicRate> basicRate = new List<BasicRate>();
		}

		[Benchmark]
		public void BasicRateConcrete()
		{
			List<BasicRate> basicRate = new List<BasicRate>();
		}

		//[Benchmark]
		//public void InterfaceAssignment()
		//{
		//	ITax tax = new IntermediateRate();
		//}

		//[Benchmark]
		//public void AbstractClassAssignment()
		//{
		//	BaseTax tax = new IntermediateRate();
		//}

		//[Benchmark]
		//public void ConcreteClassAssigment()
		//{
		//	IntermediateRate tax = new IntermediateRate();
		//}

		//[Benchmark]
		//public void DynamicAssignment()
		//{
		//	dynamic tax = new IntermediateRate();
		//}

		//[Benchmark]
		//public void VarAssignment()
		//{
		//	var tax = new IntermediateRate();
		//}
	}
}
