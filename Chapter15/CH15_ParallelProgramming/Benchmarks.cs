namespace CH15_ParallelProgramming
{
    using BenchmarkDotNet.Attributes;
    using Nessos.LinqOptimizer.CSharp;

    public class Benchmarks
    {
        private Int16[] integers;

        [GlobalSetup]
        public void GlobalSetup()
        {
            integers = new Int16[Int16.MaxValue];
            for (short x = 1; x <= integers.Length - 1; x++)
            {
                integers[x] = x;
            }
        }

        [Benchmark]
        public void StandardForEachLoopExample()
        {
            foreach (int x in integers)
                Console.WriteLine($"Item {x}: {x}");
        }


        [Benchmark]
        public void ParallelForEachLoopExample()
        {
            Parallel.ForEach(integers, x =>
            {
                Console.WriteLine($"Item {x}: {x}");
            });
        }

        [Benchmark]
        public List<string> DownloadWebsites1()
        {
            List<string> websitesContent = new();
            HttpClient httpClient = new();

            string[]? websites = new[]
            {
                "https://docs.microsoft.com",
                "https://ownCloud.com",
                "https://www.oanda.com/uk-en/",
                "https://azure.microsoft.com/en-gb/"
            };

            foreach (string? website in websites)
            {
                Console.WriteLine($"Downloading of {website} content has started.");
                string websiteContent = httpClient.GetStringAsync(website).GetAwaiter().GetResult();
                websitesContent.Add(websiteContent);
                Console.WriteLine($"Downloading of {website} content has finished.");
            }

            httpClient.Dispose();

            return websitesContent;
        }

        [Benchmark]
        public List<string> DownloadWebsites2()
        {
            List<string> websitesContent = new();

            string[]? websites = new[]
                {
                "https://docs.microsoft.com",
                "https://ownCloud.com",
                "https://www.oanda.com/uk-en/",
                "https://azure.microsoft.com/en-gb/"
                };

            Task[]? downloadJobs = websites
                .Select(jobs => Task.Factory.StartNew(
                    state =>
                    {
                        using HttpClient? httpClient = new HttpClient();
                        string? website = state == null ? String.Empty : (string)state;
                        Console.WriteLine($"Downloading of {website} content has started.");
                        string result = httpClient.GetStringAsync(website).GetAwaiter().GetResult();
                        websitesContent.Add(result);
                        Console.WriteLine($"Downloading of {website} content has finished.");
                    }, jobs)
                )
                .ToArray();

            Task.WaitAll(downloadJobs);
            return websitesContent;
        }

        [Benchmark]
        public List<string> DownloadWebsites3()
        {
            List<string> websitesContent = new();
            HttpClient httpClient = new();

            List<string> websites = new()
            {
                "https://docs.microsoft.com",
                "https://ownCloud.com",
                "https://www.oanda.com/uk-en/",
                "https://azure.microsoft.com/en-gb/"
            };

            websites.ForEach(website =>
            {
                Console.WriteLine($"Downloading of {website} content has started.");
                string result = httpClient.GetStringAsync(website).GetAwaiter().GetResult();
                websitesContent.Add(result);
                Console.WriteLine($"Downloading of {website} content has finished.");
            });

            httpClient.Dispose();

            return websitesContent;
        }

        [Benchmark]
        public List<string> DownloadWebsites4()
        {
            List<string> websitesContent = new();
            HttpClient httpClient = new();

            List<string> websites = new()
            {
                "https://docs.microsoft.com",
                "https://ownCloud.com",
                "https://www.oanda.com/uk-en/",
                "https://azure.microsoft.com/en-gb/"
            };

            Parallel.ForEach(websites, website =>
            {
                Console.WriteLine($"Downloading of {website} content has started.");
                string result = httpClient.GetStringAsync(website).GetAwaiter().GetResult();
                websitesContent.Add(result);
                Console.WriteLine($"Downloading of {website} content has finished.");
            });

            httpClient.Dispose();

            return websitesContent;
        }
    }
}
