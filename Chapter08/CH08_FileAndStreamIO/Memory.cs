using System;
using System.Collections.Generic;
using System.Linq;
namespace CH08_FileAndStreamIO
{
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Order;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Text;

	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.Declared)]
	[RankColumn]
	public class Memory
	{
		[Benchmark]
		public string ReturnFormattedString()
		{
			return string.Format(
				"{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", 
				"The", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog", "."
			);
		}

		[Benchmark]
		public string ReturnInterpolatedString()
		{
			string thep = "The";
			string quick = "quick";
			string brown = "brown";
			string fox = "fox";
			string jumped = "jumped";
			string over = "over";
			string thel = "the";
			string lazy = "lazy";
			string dog = "dog";
			string period = ".";
			return $"{thep} { quick } { brown } { fox } { jumped } { over } { thel } { dog } { period }";
		}
	}
}
