namespace CH03_DynamicPerformance
{
    using System;
    using System.Diagnostics;
    using System.Security.Cryptography;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;

    class Program
    {
#pragma warning disable IDE0051 // Remove unused private members
        dynamic _dynamicType;
#pragma warning restore IDE0051 // Remove unused private members

        static void Main(string[] _)
        {
            BenchmarkRunner.Run<BenchmarkTests>();
        }
    }
}
