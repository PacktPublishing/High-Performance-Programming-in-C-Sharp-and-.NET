namespace CH10_DataAccessBenchmarks
{
	using BenchmarkDotNet.Running;

	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<BenchmarkTests>();
		}
	}
}
