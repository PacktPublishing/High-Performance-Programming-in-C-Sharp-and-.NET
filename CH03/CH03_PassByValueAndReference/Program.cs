using System;

namespace CH03_PassByValueAndReference
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            Console.WriteLine("Chapter 3: Pass by value and reference");
            Console.WriteLine($"=====================================");
            Console.WriteLine($"int x = 0;");
            AddByValue(x);
            Console.WriteLine($"    AddByValue(x): {x}");
            AddByReference(ref x);
            Console.WriteLine($"AddByReference(x): {x}");
            InParameterModifier();
            OutParameterModifier();
        }

        static void AddByValue(int x)
        {
            x++;
        }

        static void AddByReference(ref int x)
        {
            x++;
        }

        static void InParameterModifier()
        {
            int argument = 13;
            InParameterModifier(argument);
            Console.WriteLine(argument);
        }

        static void InParameterModifier(in int argument)
        {
            // Error CS8331: Cannot assign to variable 'in int'
            // because it is a readonly variable.
            // argument = 47; 
        }

        static void OutParameterModifier()
        {
            int x;
            OutParameterModifier(out x);
            Console.WriteLine($"The value of x is: {x}.");
        }

        static void OutParameterModifier(out int argument)
        {
            argument = 123;
        }
    }
}
