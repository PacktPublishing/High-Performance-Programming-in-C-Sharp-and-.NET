namespace CH07_LinqPerformance
{
	using BenchmarkDotNet.Running;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	class Program
	{

		static void Main(string[] args)
		{
			BenchmarkRunner.Run<LinqPerformance>();
			//ExtendingLinq extendingLinq = new ExtendingLinq();
			//extendingLinq.PrintJsonData();
			//extendingLinq.PrintObjectData();
			//extendingLinq.SerializeDeserialize();
		}

		private static void IEnumerableVsIEnumeratorExample()
		{
			IEnumerableVsIEnumerator eve = new IEnumerableVsIEnumerator();
			eve.IterateEnumerator1970To1975();
		}
	}
}
