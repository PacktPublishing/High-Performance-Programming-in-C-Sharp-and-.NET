namespace CH03_DynamicPerformance
{
    using System;
    using System.Diagnostics;
    using System.Security.Cryptography;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;

    public class BenchmarkTests
    {
        [Benchmark]
        public void MeasureVarUsage()
        {
            var x = 3.14159;
        }

        [Benchmark]
        public void MeasureVarDynamicUsage()
        {
            var x = (dynamic)3.14159;
        }

        [Benchmark]
        public void MeasureTypeDynamicUsage()
        {
            double x = (dynamic)3.14159;
        }

        [Benchmark]
        public void MeasureTypeTypeUsage()
        {
            double x = 3.14159;
        }
    }
}
