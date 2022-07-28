namespace CH15_ParallelProgramming;

using BenchmarkDotNet.Running;

internal class Program
{
    static void Main(string[] _)
    {
        //RunSingleProcessorExample();
        //Parallel.For(0, 1000000, x => MultipleProcessorExample(x));
        //FuncAction();
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

    static void FuncAction()
    {
        int[] numbers = { 15, 10, 12, 17, 11, 13, 16, 14, 18 };
        int additionResult = 0;

        try
        {
            Parallel.ForEach(
                numbers,
                () => 0,
                (number, currentState, addition) =>
                {
                    addition += number;
                    Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}, Number: {number}, Addition: {addition}");
                    return addition;
                },
                (addition) => Interlocked.Add(ref additionResult, addition)
            );
            Console.WriteLine($"Addition Result: {additionResult}");
        }
        catch (AggregateException e)
        {
            Console.WriteLine($"Aggregate Exception: FuncAction.\n{e.Message}");
        }
    }
}