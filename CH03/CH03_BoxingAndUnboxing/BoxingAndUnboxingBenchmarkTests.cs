namespace CH03_BoxingAndUnboxing
{
    using System;
    using System.Diagnostics;
    using System.Security.Cryptography;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;

    public class BoxingAndUnboxingBenchmarkTests
    {
        [Benchmark]
        public void NonBoxingUnboxingTest()
        {
            int z = 0, a = 4, b = 4;
            z = a + b;
        }

        [Benchmark]
        public void BoxingUnboxingTest()
        {
            object a = 4, b = 4;
            int z;
            z = (int)a + (int)b;
        }
    }
}
