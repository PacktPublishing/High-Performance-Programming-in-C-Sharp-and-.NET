namespace CH02_PythonIntegration
{
    using System;
    using IronPython.Hosting;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to be printed from Python: ");
            var input = Console.ReadLine();
            var python = Python.CreateEngine();
            try
            {
                python.Execute("print('From Python: " + input + "')");
                python.ExecuteFile("welcome.py");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
