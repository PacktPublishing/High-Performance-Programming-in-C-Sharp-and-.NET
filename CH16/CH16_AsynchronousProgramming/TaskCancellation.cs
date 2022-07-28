namespace CH16_AsynchronousProgramming;

using System.Text;

internal class TaskCancellation
{
    private const string _website = "https://docs.microsoft.com";
    private static readonly CancellationTokenSource _cancellationTokenSource = new();

    private static readonly HttpClient HttpClient = new()
    {
        MaxResponseContentBufferSize = 1000000
    };

    public static async Task Start()
    {
        Console.WriteLine("Task started.");

        try
        {
            _cancellationTokenSource.CancelAfter(3000);
            string websiteText = await ReturnWebsiteTextAsync().ConfigureAwait(false);
            Console.WriteLine(websiteText);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\nThe task has timed out and been cancelled.\n");
        }
        finally
        {
            _cancellationTokenSource.Dispose();
        }

        Console.WriteLine("Task completed.");
    }

    private static async Task<string> ReturnWebsiteTextAsync()
    {
        HttpResponseMessage response = await HttpClient
            .GetAsync(_website, _cancellationTokenSource.Token)
            .ConfigureAwait(false);
        byte[] contentAsByteArray = await response.Content
            .ReadAsByteArrayAsync(_cancellationTokenSource.Token)
            .ConfigureAwait(false);
        return Encoding.ASCII.GetString(contentAsByteArray);
    }
}
