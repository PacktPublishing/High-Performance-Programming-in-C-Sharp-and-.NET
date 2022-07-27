namespace CH07_LinqPerformance
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
    public class IEnumerableVsIEnumerator
    {
        private List<int> _years;

        public IEnumerableVsIEnumerator()
        {
            _years = new List<int>
            {
                1970,
                1971,
                1972,
                1973,
                1974,
                1975,
                1976,
                1977,
                1978,
                1979
            };
        }

        public void IterateEnumerator1970To1975()
        {
            var years = _years.GetEnumerator();
            while (years.MoveNext())
            {
                Debug.WriteLine(years.Current);
                if (years.Current > 1975)
                {
                    IterateEnumberator1976To1979(years);
                    break;
                }
            }
        }

        public void IterateEnumberator1976To1979(IEnumerator<int> years)
        {
            while (years.MoveNext())
            {
                Debug.WriteLine(years.Current);
            }
        }

        [Benchmark]
        public void BenchmarkIEnumerable()
        {
            IEnumerable<int> enumerable = (IEnumerable<int>)_years;
            foreach (int i in enumerable)
                Debug.WriteLine(i);
        }

        [Benchmark]
        public void BenchmarkIEnumerator()
        {
            IEnumerator<int> enumerator = _years.GetEnumerator();
            while (enumerator.MoveNext())
                Debug.WriteLine(enumerator.Current);
        }
    }
}