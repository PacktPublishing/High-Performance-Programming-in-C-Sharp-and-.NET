namespace CH06_Collections
{
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Order;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Declared)]
    [RankColumn]
    public class ArraysVsCollections
    {
        private int[] array;
        private List<int> collection;

        [GlobalSetup]
        public void GlobalSetup()
        {
            array = new int[1000];
            collection = new List<int>();
            for (int i = 0; i < 1000; i++)
			{
                array[i] = i;
                collection.Add(i);
			}
        }

        [Benchmark]
        public void ArrayAdd1000Logic()
        {
            int[] list = new int[1000];
            for (int i = 0; i < 1000; i++)
                list[i] = i;
        }

        [Benchmark]
        public void CollectionAdd1000Logic()
        {
            IList<int> list = new List<int>();
            for (int i = 0; i < 1000; i++)
                list.Add(i);
        }


        [Benchmark]
        public int ArrayIterationLogic()
        {
            int res = 0;
            for (int i = 0; i < 1000; i++)
                res += array[i];
            return res;
        }

        [Benchmark]
        public int CollectionIterationLogic()
        {
            int res = 0;
            for (int i = 0; i < 1000; i++)
                res += collection[i];
            return res;
        }

        [Benchmark]
        public int ArrayGetElement500Logic()
        {
            return array[500];
        }

        [Benchmark]
        public int CollectionGetElement500Logic()
        {
            return collection[500];
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            // Disposing logic
        }
    }
}
