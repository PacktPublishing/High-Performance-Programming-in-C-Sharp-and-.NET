namespace CH15_ParallelProgramming
{
    using BenchmarkDotNet.Attributes;
    using Nessos.LinqOptimizer.CSharp;

    public class Benchmarks
    {
        private short[] data;

        [GlobalSetup]
        public void Setup()
        {
            data = new short[short.MaxValue];
            for (short x = 1; x <= data.Length - 1; x++)
            {
                data[x] = x;
            }
        }

        [Benchmark]
        public void StandardForEachLoopExample()
        {
            foreach (int x in data)
                Console.WriteLine($"Item {x}: {x}");
        }


        [Benchmark]
        public void ParallelForEachLoopExample()
        {
            Parallel.ForEach(data, x => {
                Console.WriteLine($"Item {x}: {x}");
            });
        }

        [Benchmark]
        public List<string> UrlDownloader1()
        {
            List<string> urlContent = new();
            HttpClient client = new();

            var urls = new[]
                {
                    "http://google.com",
                    "http://yahoo.com",
                    "http://stackoverflow.com"
                };

            foreach (var url in urls)
            {
                Console.WriteLine($"starting to download {url}");
                string result = client.GetStringAsync(url).GetAwaiter().GetResult();
                urlContent.Add(result);
                Console.WriteLine($"finished downloading {url}");
            }

            client.Dispose();

            return urlContent;
        }

        [Benchmark]
        public List<string> UrlDownloader2()
        {
            List<string> urlContent = new();

            var urls = new[]
                {
                    "http://google.com",
                    "http://yahoo.com",
                    "http://stackoverflow.com"
                };

            var tasks = urls
                .Select(url => Task.Factory.StartNew(
                    state =>
                    {
                        using var client = new HttpClient();
                        var url = (string)state;
                        Console.WriteLine($"starting to download {url}");
                        string result = client.GetStringAsync(url).GetAwaiter().GetResult();
                        urlContent.Add(result);
                        Console.WriteLine($"finished downloading {url}");
                    }, url)
                )
                .ToArray();

            Task.WaitAll(tasks);
            return urlContent;
        }

        [Benchmark]
        public List<string> UrlDownloader3()
        {
            List<string> urlContent = new();
            HttpClient client = new();

            List<string> urls = new()
                {
                    "http://google.com",
                    "http://yahoo.com",
                    "http://stackoverflow.com"
                };

            urls.ForEach(url =>
            {
                Console.WriteLine($"starting to download {url}");
                string result = client.GetStringAsync(url).GetAwaiter().GetResult();
                urlContent.Add(result);
                Console.WriteLine($"finished downloading {url}");
            });

            client.Dispose();

            return urlContent;
        }

        [Benchmark]
        public List<string> UrlDownloader4()
        {
            List<string> urlContent = new();
            HttpClient client = new();

            List<string> urls = new()
            {
                "http://google.com",
                "http://yahoo.com",
                "http://stackoverflow.com"
            };

            Parallel.ForEach(urls, url =>
            {
                Console.WriteLine($"starting to download {url}");
                string result = client.GetStringAsync(url).GetAwaiter().GetResult();
                urlContent.Add(result);
                Console.WriteLine($"finished downloading {url}");
            });

            client.Dispose();

            return urlContent;
        }
    }
}
