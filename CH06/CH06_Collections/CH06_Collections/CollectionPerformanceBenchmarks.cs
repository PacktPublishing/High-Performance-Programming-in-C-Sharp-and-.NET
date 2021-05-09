namespace CH06_Collections
{
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Order;
	using CH06_Collections.Models;
	using System.Collections;
	using System.Collections.Generic;

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class CollectionPerformanceBenchmarks
    {
        private const int RECORD_COUNT = 1000000;

        [Benchmark]
        public void ArrayListIntsBenchmarkTest()
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < RECORD_COUNT; i++)
            {
                arrayList.Add(i + 1);
            }
        }

        [Benchmark]
        public void GenericArrayListIntsBenchmarkTest()
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < RECORD_COUNT; i++)
            {
                arrayList.Add(i + 1);
            }
        }

        [Benchmark]
        public void GenericListIntsBenchmarkTest()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < RECORD_COUNT; i++)
            {
                list.Add(i + 1);
            }
        }

        [Benchmark]
        public void NativeArrayIntsBenchmarkTest()
        {
            int[] intArray = new int[RECORD_COUNT];
            for (int i = 0; i < RECORD_COUNT; i++)
            {
                intArray[i] = i + 1;
            }
        }

        [Benchmark]
        public void ArrayListObjectsBenchmarkTest()
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < RECORD_COUNT; i++)
            {
                arrayList.Add(new Item(i));
            }
        }

        [Benchmark]
        public void GenericListObjectsBenchmarkTest()
        {
            List<Item> list = new List<Item>();
            for (int i = 0; i < RECORD_COUNT; i++)
            {
                list.Add(new Item(i));
            }
        }

        [Benchmark]
        public void NativeArrayObjectsBenchmarkTest()
        {
            Item[] itemArray = new Item[RECORD_COUNT];
            for (int i = 0; i < RECORD_COUNT; i++)
            {
                itemArray[i] = new Item(i);
            }
        }

        [Benchmark]
        public void ArrayListStructsBenchmarkTest()
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < RECORD_COUNT; i++)
            {
                arrayList.Add(new Product(i));
            }
        }

        [Benchmark]
        public void GenericListStructsBenchmarkTest()
        {
            List<Product> list = new List<Product>();
            for (int i = 0; i < RECORD_COUNT; i++)
            {
                list.Add(new Product(i));
            }
        }

        [Benchmark]
        public void NativeArrayStructsBenchmarkTest()
        {
            Product[] itemArray = new Product[RECORD_COUNT];
            for (int i = 0; i < RECORD_COUNT; i++)
            {
                itemArray[i] = new Product(i);
            }
        }
    }
}