namespace CH03_StackAndHeap
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Security.Cryptography;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;

    public class BenchmarkTests
    {
        [Benchmark]
        public void ProcessClassNoReferences()
        {
            var _ = new ClassNoReferences(
                1,
                1.50M,
                DateTime.Now
            );
        }

        [Benchmark]
        public void ProcessStructNoReferences()
        {
            var _ = new StructNoReferences(
                1,
                1.50M,
                DateTime.Now
            );
        }

        [Benchmark]
        public void ProcessClassWithReferences()
        {
            var _ = new ClassWithReferences(
                1,
                "The quick brown fox jumped over the lazy dog.",
                1.50M,
                DateTime.Now,
                new Dictionary<string, string>()
            );
        }

        [Benchmark]
        public void ProcessStructWithReferences()
        {
            var _ = new StructWithReferences(
                1,
                "The quick brown fox jumped over the lazy dog.",
                1.50M,
                DateTime.Now,
                new Dictionary<string, string>()
            );
        }
    }
}