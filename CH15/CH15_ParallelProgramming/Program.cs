using BenchmarkDotNet.Running;

namespace CH15_ParallelProgramming
{
    internal class Program
    {
        static void Main(string[] _)
        {
            //RunSingleProcessorExample();
            //Parallel.For(0, 1000000, x => MultipleProcessorExample(x));
            BenchmarkRunner.Run<Benchmarks>();
        }

        static void RunSingleProcessorExample()
        {
            Thread thread = new(SingleProcessorExample);
            thread.Start();
        }

        static void SingleProcessorExample()
        {
            string output = "Index: ";

            for (int index = 0; index < 1000000; index++)
            {
                Console.WriteLine($"{output}{index}");
            }
            
            Console.ReadKey();
        }

        static void MultipleProcessorExample(int index)
        {
            string output = "Index: ";
            Console.WriteLine($"{output}{index}");
        }
    }
}