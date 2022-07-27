namespace CH03_StackAndHeap
{
    using System;
    using System.Diagnostics;
    using System.Security.Cryptography;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;

    class Program
    {
        static void Main(string[] _)
        {
            BenchmarkRunner.Run<BenchmarkTests>();
        }
    }
}
