using BenchmarkDotNet.Running;
using CH16_AsynchronousProgramming;

Console.WriteLine("CH13 - Asynchronous Programming");

//var summary = BenchmarkRunner.Run<Benchmarks>();

// TaskCancellation.Start().GetAwaiter();

FileReadWriteAsync.WriteTextAsync().GetAwaiter();
string data = FileReadWriteAsync.ReadTextAsync().GetAwaiter().GetResult();
Console.WriteLine(data);
  
Console.ReadLine();
