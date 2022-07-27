
using CH14_Multithreading;

//ThreadCreationWithNoParameters();
//ThreadCreationWithParameters();
//BackgroundThread();
//ForegroundThread();
//UsingAThreadPool();
//SyncrhonousThreadCancelation();
ScheduleThreadWithoutParameters();
ScheduleThreadWithParameters();

// See: https://www.bing.com/search?q=how+to+improve+c%23+multithreading+performance&cvid=fe129561e8564f0bae6d42433b9fcac4&aqs=edge..69i57.10959j0j4&FORM=ANAB01&PC=U531

ThreadPool.SetMinThreads(25, 25);
static void ThreadCreationWithNoParameters()
{
    Console.WriteLine("-- Executing Method: ThreadCreationWithNoParameters() --");
    ForegroundThread();
    BackgroundThread();
    UsingAThreadPool();
}

static void ThreadCreationWithParameters()
{
    Console.WriteLine("-- Executing Method: ThreadCreationWithParameters() --");
    int result = 0;
    Thread thread = new Thread(() => { result = Add(1, 2); });
    thread.Start();
    thread.Join();
    Console.WriteLine($"The addition of 1 plus 2 is {result}." +
        $"");
}

static int Add(int a, int b)
{
    return a + b;
}

static void ForegroundThread()
{
    Console.WriteLine("-- Executing Method: ForegroundThread() --");
    var foregroundThread = new Thread(ForegroundThreadWorkerMethod);
    foregroundThread.Start();
}

static void ForegroundThreadWorkerMethod()
{
    Console.WriteLine("-- Executing Method: ForegroundThreadWorkerMethod() --");
}

static void BackgroundThread()
{
    Console.WriteLine("-- Executing Method: BackgroundThread() --");
    var backgroundThread = new Thread(BackgroundThreadWorkerMethod);
    backgroundThread.IsBackground = true;
    backgroundThread.Start();
}

static void BackgroundThreadWorkerMethod()
{
    Console.WriteLine("-- Executing Method: BackgroundThreadWorkerMethod() --");
    ThreadCreationWithParameters();

}
static void UsingAThreadPool()
{
    Console.WriteLine("-- Executing Method: UsingAThreadPool() --");
    ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolWorkerMethod));
    Console.WriteLine("-- Main thread does some work then sleeps --");
    Thread.Sleep(1000);
    Console.WriteLine("-- Main thread exits --");
}

static void ThreadPoolWorkerMethod(object _)
{
    Console.WriteLine("-- Executing Method: ThreadPoolWorkerMethod() --");
}

static void SyncrhonousThreadCancelation()
{
    TimeSpan timeoutTimeSpan = TimeSpan.FromMilliseconds(750);
    bool callResult = TryCallWithTimeout(
        SleepyMethod,
        timeoutTimeSpan,
        out int result
    );
    Console.WriteLine($"SleepyMethod() {(callResult ? "Executed" : "Cancelled")}");
}

static int SleepyMethod(CancellationToken ct)
{
    for (var i = 0; i < 10; i++)
    {
        Thread.Sleep(TimeSpan.FromMilliseconds(500));
        // co-operative cancellation implies periodically check IsCancellationRequested
        if (ct.IsCancellationRequested) { throw new TaskCanceledException(); }
    }
    return 1234567890; // the result
}

static bool TryCallWithTimeout<TResult>(
      Func<CancellationToken, TResult> function,
      TimeSpan timeout,
      out TResult result
)
{
    // Request cancellation after a duration of 'timeout'
    var cancellationTokentSource = new CancellationTokenSource(timeout);
    try
    {
        result = function(cancellationTokentSource.Token);
        return true;
    }
    catch (TaskCanceledException)
    {
    }
    finally
    {
        cancellationTokentSource.Dispose();
    }
    result = default;
    return false;
}

static void ScheduleThreadWithoutParameters()
{
    Job job = new();
    Thread thread = new Thread(new ThreadStart(job.Execute));
    thread.Start();
}

static void ScheduleThreadWithParameters()
{
    Job job = new();
    var thread1 = new Thread(new ParameterizedThreadStart(job.PrintMessage));
    var thread2 = new Thread(new ParameterizedThreadStart(job.PrintMessage));
    thread1.Start("Hello, world!");
    thread2.Start("Goodbye, world!");
}