namespace CH03_StringsAreImmutable
{
    using System;

    class Program
    {
        static void Main(string[] _)
        {
            Console.WriteLine("Chapter 3: Strings are immutable");
            var greeting1 = "Hello, world!";
            var greeting2 = greeting1;
            Console.WriteLine($"greeting1={greeting1}");
            Console.WriteLine($"greeting2={greeting2}");
            greeting1 += " Isn't life grand!";
            Console.WriteLine($"greeting1={greeting1}");
            Console.WriteLine($"greeting1={greeting2}");
        }
    }
}
