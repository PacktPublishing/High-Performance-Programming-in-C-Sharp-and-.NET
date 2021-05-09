namespace CH06_Collections
{
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Order;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;

	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.Declared)]
	[RankColumn]
	public class Equality
	{
		private List<string> _listOne;
		private List<string> _listTwo;

		private int _value1;
		private int _value2;

		private string _string1;
		private string _string2;

		[GlobalSetup]
		public void GlobalSetup()
		{
			_listOne = new List<string>
			{
				"Alpha", "Beta", "Gamma", "Delta", "Eta", "Theta"
			};
			_listTwo = _listOne;
			_value1 = 123;
			_value2 = _value1;
			_string1 = "Hello, world!";
			_string2 = _string1;
		}

		[Benchmark]
		public void ValueOperatorValue()
		{
			bool value = _value1 == _value2;
		}

		[Benchmark]
		public void ValueEqualsValue()
		{
			bool value = _value1.Equals(_value2);
		}

		[Benchmark]
		public void ReferenceOperatorReference()
		{
			bool value = _listOne == _listTwo;
		}

		[Benchmark]
		public void ReferenceEqualsReference()
		{
			bool value = _listOne.Equals(_listTwo);
		}

		[Benchmark]
		public void StringOpertatorString()
		{
			bool value = _string1 == _string2;
		}

		[Benchmark]
		public void StringEqualsString()
		{
			bool value = _string1.Equals(_string2);
		}
	}
}
