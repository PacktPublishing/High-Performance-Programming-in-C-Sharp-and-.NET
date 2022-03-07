namespace CH13_CQRSPattern
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! This is a most simple example of CQRS in action.");
            ExecuteCommand();
            Console.WriteLine($"The current date and time is: {ExecuteQuery()}.");
        }


        private static void ExecuteCommand()
        {
            new CQRSBasedClass().SleepCommand(1000);
        }

        private static DateTime ExecuteQuery()
        {
            return new CQRSBasedClass().DateTimeQuery();
        }

    }
}
