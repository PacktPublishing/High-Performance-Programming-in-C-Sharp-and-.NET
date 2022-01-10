namespace CH16_AsynchronousProgramming
{
    using BenchmarkDotNet.Attributes;

    public class Benchmarks
    {
        //[Benchmark]
        //public static void SychronousMethod()
        //{
        //    LengthyTask();
        //}

        //[Benchmark]
        //public static void TaskMethod()
        //{
        //    Task.Run(new Action(LengthyTask));
        //}

        //[Benchmark]
        //public static void AsynchronousTaskMethod()
        //{
        //    var data = async () => await Task.Run(new Action(LengthyTask));
        //}

        //public static void LengthyTask()
        //{
        //    int y = 0;
        //    for (int x = 0; x < 10; x++)
        //        y++;
        //}

        //public static int LengthyTaskReturnsInt()
        //{
        //    int y = 0;
        //    for (int x = 0; x < 10; x++)
        //        y++;
        //    return y;
        //}

        private async Task<int> TaskOne()
        {
            await Task.Delay(300);
            return 100;
        }

        private async Task<string> TaskTwo()
        {
            await Task.Delay(300);
            return "TaskTwo";
        }

        //[Benchmark]
        //public void GetAwaiterGetResult()
        //{
        //    int value = Task.Run(() => LengthyTaskReturnsInt()).GetAwaiter().GetResult();
        //}

        //[Benchmark]
        //public async Task Result()
        //{
        //    int value = await Task.Run(() => LengthyTaskReturnsInt()).ConfigureAwait(false);
        //}

        //[Benchmark]
        //public void Wait()
        //{
        //    Task.Run(() => LengthyTask()).Wait();
        //}

        //[Benchmark]
        //public void GetAwaiter()
        //{
        //    Task.Run(() => LengthyTask()).GetAwaiter();
        //}

        [Benchmark]
        public async Task SynchronousAwait()
        {
            int intValue = await TaskOne();
            string stringValue = await TaskTwo(); 
        }

        [Benchmark]
        public async Task AsynchynchronousWhenAll()
        {
            var taskOne = TaskOne();
            var taskTwo = TaskTwo();
            await Task.WhenAll(taskOne, taskTwo);
        }
    }
}
