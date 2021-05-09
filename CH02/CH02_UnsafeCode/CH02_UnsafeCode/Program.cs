namespace CH02_UnsafeCode
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            // Array added to the heap.
            int[] array = new int[5] { 5, 4, 3, 2, 1 };
            Console.WriteLine(array[4]);

            unsafe
            {
                int* pointer = stackalloc int[5];
                int* cpointer = pointer;
                cpointer += 50;
                Console.WriteLine(*cpointer);
            }

            int value = 10;

            Console.WriteLine(Add(value));

            unsafe
            {
                Add(&value);
                Console.WriteLine(value);
                fixed (int* arrayPointer = array)
                {
                    PrintArrayContents(arrayPointer, array.Length);

                    int* pointerToArray = stackalloc int[100];
                    Console.WriteLine(pointerToArray[99]);
                    Console.WriteLine(pointerToArray[100]);

                    try
                    {
                        Integers integers;
                        integers.I = 5;
                        integers.J = 5;
                        PrintIntegers(&integers);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Console.ReadKey();
        }

        private static int Add(int value)
        {
            return ++value;
        }

        private static unsafe void Add(int* address)
        {
            *address = *address + *address;
        }

        private static unsafe void PrintArrayContents(int* array, int arrayLength)
        {
            // Correct code.
            for (var index = 0; index < arrayLength; index++)
            {
                Console.WriteLine($"[1] Array value at location {index}: {*(array + index)}");
                Console.WriteLine($"[2] Array value at location {index}: {array[index]}");
            }
            // Incorrect code. No ArrayIndexOutOfBoundsException is raised. So, be careful!
            for (var index = 0; index < arrayLength + 10; index++)
            {
                Console.WriteLine($"[1] Array value at location {index}: {*(array + index)}");
                Console.WriteLine($"[2] Array value at location {index}: {array[index]}");
            }
        }

        private static unsafe void PrintIntegers(Integers* integers)
        {
            Console.WriteLine($"{(*integers).I} + {(*integers).J} = {(*integers).I + (*integers).J}");
            Console.WriteLine($"{integers->I} + {integers->J} = {integers->I + integers->J}");
        }
    }
}