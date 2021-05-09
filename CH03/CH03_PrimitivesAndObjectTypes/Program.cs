namespace CH03_PrimitivesAndObjectTypes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    class Program
    {
        static void Main(string[] _)
        {
            Print("Chapter 3: Primitives and object types");
            PrintValueTypes();
            PrintReferenceTypes();
            BenchmarkDataTypes();
        }

        #region Print and Benchmark Methods

        static void PrintValueTypes()
        {
            PrintBoolData();
            PrintByteData();
            PrintSByteData();
            PrintCharData();
            PrintDateTimeData();
            PrintDecimalData();
            PrintDoubleData();
            PrintFloatData();
            PrintIntData();
            PrintUIntData();
            PrintLongData();
            PrintULongData();
            PrintShortData();
            PrintEnumData();
            PrintStructData();
            PrintValueTupleData();
        }

        static void PrintReferenceTypes()
        {
            PrintObjectData();
            PrintStringData();
            PrintDelegateData();
        }

        static void BenchmarkDataTypes()
        {
            long a = 0, b = 0, c = 0, d = 0, e = 0;

            for (var i = 1; i <= 10000; i++)
            {
                a += ElapsedTicks<int>();
                b += ElapsedTicks<long>();
                c += ElapsedTicks<float>();
                d += ElapsedTicks<double>();
                e += ElapsedTicks<decimal>();
            }
            Print($"    Elapsed Time (int): {a / 10000}");
            Print($"   Elapsed Time (long): {b / 10000}");
            Print($"  Elapsed Time (float): {c / 10000}");
            Print($" Elapsed Time (double): {d / 10000}");
            Print($"Elapsed Time (decimal): {e / 10000}");

            BenchmarkObjects();
            BenchmarkStructs();
        }

        #endregion Print and Benchmark Methods

        #region Support Methods

        static unsafe string GetBitCount<T>() where T : unmanaged
        {
            int eightbits = 8;
            int bitCount = sizeof(T) * eightbits;
            return bitCount == 1 ? "1-bit" : $"{bitCount}-bits";
        }

        static unsafe string GetSizeOf<T>() where T : unmanaged
        {
            var size = sizeof(T);
            return size == 1 ? $"{size} byte" : $"{size} bytes";
        }

        static string GetWhetherSignedOrUnsigned(double value)
        {
            return value < 0 ? "Signed" : "Unsigned";
        }

        static string IsNullable<T>()
        {
            var type = typeof(T);
            var isNullable = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
            return isNullable ? "Yes" : "No";
        }

        static void Print(string message)
        {
            Console.WriteLine(message);
        }

        static long ElapsedTicks<T>()
        {
            T value;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 1; i <= 10000; i++)
            {
                value = (T)Convert.ChangeType(i, typeof(T));
            }
            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }

        #endregion Suport Methods

        #region Value Type Print Data Methods

        static void PrintBoolData()
        {
            var sb = new StringBuilder();
            sb.AppendLine("\n=== bool data start ===");
            sb.AppendLine($"Type: {typeof(bool).FullName}");
            sb.AppendLine($"True String: {bool.TrueString}");
            sb.AppendLine($"False String: {bool.FalseString}");
            sb.AppendLine($"Size: {GetBitCount<bool>()}");
            sb.AppendLine($"Is Nullable: {IsNullable<bool?>()}");
            sb.AppendLine($"Notes: Literal values: true, false.");
            sb.AppendLine($"Default Value: {default(bool)}");
            sb.AppendLine($"Nominal Storage Allocation: {GetSizeOf<bool>()}.");
            sb.AppendLine($"== bool data end ===");
            Console.WriteLine(sb.ToString());
        }

        static void PrintByteData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== byte data start ===");
            sb.AppendLine($"Type: {typeof(byte).FullName}");
            sb.AppendLine($"Min Value: {byte.MinValue}");
            sb.AppendLine($"Max Value: {byte.MaxValue}");
            sb.AppendLine($"Size: {GetBitCount<byte>()}");
            sb.AppendLine($"Integer Type: {GetWhetherSignedOrUnsigned(byte.MinValue)}");
            sb.AppendLine($"Is Nullable: {IsNullable<byte?>()}");
            sb.AppendLine($"Default Value: {default(byte)}");
            sb.AppendLine($"Nominal Storage Allocation: {GetSizeOf<byte>()}.");
            sb.AppendLine($"=== byte data end ===");
            Console.WriteLine(sb.ToString());
        }

        static void PrintSByteData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== sbyte data start ===");
            sb.AppendLine($"Type: {typeof(sbyte).FullName}");
            sb.AppendLine($"Min Value: {sbyte.MinValue}");
            sb.AppendLine($"Max Value: {sbyte.MaxValue}");
            sb.AppendLine($"Size: {GetBitCount<sbyte>()}");
            sb.AppendLine($"Integer Type: {GetWhetherSignedOrUnsigned(sbyte.MinValue)}");
            sb.AppendLine($"Is Nullable: {IsNullable<sbyte?>()}");
            sb.AppendLine($"Default Value: {default(sbyte)}");
            sb.AppendLine($"Nominal Storage Allocation: {GetSizeOf<sbyte>()}.");
            sb.AppendLine($"=== byte data end ===");
            Console.WriteLine(sb.ToString());
        }

        static void PrintCharData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== byte data start ===");
            sb.AppendLine($"Type: {typeof(char).FullName}");
            int min = char.MinValue;
            int max = char.MaxValue;
            sb.AppendLine($"Min Value: {min} - \\u{min:x4}");
            sb.AppendLine($"Max Value: {max} - \\u{max:x4}");
            sb.AppendLine($"Size: {GetBitCount<char>()}");
            sb.AppendLine($"Integer Type: {GetWhetherSignedOrUnsigned(char.MinValue)}");
            sb.AppendLine($"Is Nullable: {IsNullable<char?>()}");
            sb.AppendLine($"Default Value: {default(char)}");
            sb.AppendLine($"Nominal Storage Allocation: {GetSizeOf<char>()}.");
            sb.AppendLine($"=== char data end ===");
            Console.WriteLine(sb.ToString());
        }

        static void PrintDateTimeData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== DateTime data start ===");
            sb.AppendLine($"Type: {typeof(DateTime).FullName}");
            sb.AppendLine($"Min Value: {DateTime.MinValue} - {DateTime.MinValue.Ticks}");
            sb.AppendLine($"Max Value: {DateTime.MaxValue} - {DateTime.MaxValue.Ticks}");
            sb.AppendLine($"Size: {GetBitCount<DateTime>()}");
            sb.AppendLine($"Integer Type: {GetWhetherSignedOrUnsigned(DateTime.MinValue.Ticks)}");
            sb.AppendLine($"Is Nullable: {IsNullable<DateTime?>()}");
            sb.AppendLine($"Default Value: {default(DateTime)}");
            sb.AppendLine($"Nominal Storage Allocation: {GetSizeOf<DateTime>()}.");
            sb.AppendLine($"=== DateTime data end ===");
            Console.WriteLine(sb.ToString());
        }

        static void PrintDecimalData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== decimal data start ===");
            sb.AppendLine($"Type: {typeof(decimal).FullName}");
            sb.AppendLine($"Min Value: {decimal.MinValue}");
            sb.AppendLine($"Max Value: {decimal.MaxValue}");
            sb.AppendLine($"Size: {GetBitCount<decimal>()}");
            sb.AppendLine($"Integer Type: {GetWhetherSignedOrUnsigned((double)decimal.MinValue)}");
            sb.AppendLine($"Is Nullable: {IsNullable<decimal?>()}");
            sb.AppendLine($"Default Value: {default(decimal)}");
            sb.AppendLine($"Nominal Storage Allocation: {GetSizeOf<decimal>()}.");
            sb.AppendLine($"=== decimal data end ===");
            Console.WriteLine(sb.ToString());
        }

        static void PrintDoubleData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== double data start ===");
            sb.AppendLine($"Type: {typeof(double).FullName}");
            sb.AppendLine($"Min Value: {double.MinValue}");
            sb.AppendLine($"Max Value: {double.MaxValue}");
            sb.AppendLine($"Size: {GetBitCount<double>()}");
            sb.AppendLine($"Integer Type: {GetWhetherSignedOrUnsigned(double.MinValue)}");
            sb.AppendLine($"Is Nullable: {IsNullable<double?>()}");
            sb.AppendLine($"Default Value: {default(double)}");
            sb.AppendLine($"Nominal Storage Allocation: {GetSizeOf<double>()}.");
            sb.AppendLine($"=== double data end ===");
            Console.WriteLine(sb.ToString());
        }

        static void PrintFloatData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== float data start ===");
            sb.AppendLine($"Type: {typeof(float).FullName}");
            sb.AppendLine($"Min Value: {float.MinValue}");
            sb.AppendLine($"Max Value: {float.MaxValue}");
            sb.AppendLine($"Size: {GetBitCount<float>()}");
            sb.AppendLine($"Integer Type: {GetWhetherSignedOrUnsigned(float.MinValue)}");
            sb.AppendLine($"Is Nullable: {IsNullable<float?>()}");
            sb.AppendLine($"Default Value: {default(float)}");
            sb.AppendLine($"Nominal Storage Allocation: {GetSizeOf<float>()}.");
            sb.AppendLine($"=== float data end ===");
            Console.WriteLine(sb.ToString());
        }

        static void PrintIntData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== int data start ===");
            sb.AppendLine($"Type: {typeof(int).FullName}");
            sb.AppendLine($"Min Value: {int.MinValue}");
            sb.AppendLine($"Max Value: {int.MaxValue}");
            sb.AppendLine($"Size: {GetBitCount<int>()}");
            sb.AppendLine($"Integer Type: {GetWhetherSignedOrUnsigned(int.MinValue)}");
            sb.AppendLine($"Is Nullable: {IsNullable<int?>()}");
            sb.AppendLine($"Default Value: {default(int)}");
            sb.AppendLine($"Nominal Storage Allocation: {GetSizeOf<int>()}.");
            sb.AppendLine($"=== int data end ===");
            Print(sb.ToString());
        }

        static void PrintUIntData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== uint data start ===");
            sb.AppendLine($"Type: {typeof(uint).FullName}");
            sb.AppendLine($"Min Value: {uint.MinValue}");
            sb.AppendLine($"Max Value: {uint.MaxValue}");
            sb.AppendLine($"Size: {GetBitCount<uint>()}");
            sb.AppendLine($"Integer Type: {GetWhetherSignedOrUnsigned(uint.MinValue)}");
            sb.AppendLine($"Is Nullable: {IsNullable<uint?>()}");
            sb.AppendLine($"Default Value: {default(uint)}");
            sb.AppendLine($"Nominal Storage Allocation: {GetSizeOf<uint>()}.");
            sb.AppendLine($"=== uint data end ===");
            Print(sb.ToString());
        }

        static void PrintLongData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== long data start ===");
            sb.AppendLine($"Type: {typeof(long).FullName}");
            sb.AppendLine($"Min Value: {long.MinValue}");
            sb.AppendLine($"Max Value: {long.MaxValue}");
            sb.AppendLine($"Size: {GetBitCount<long>()}");
            sb.AppendLine($"Integer Type: {GetWhetherSignedOrUnsigned(long.MinValue)}");
            sb.AppendLine($"Is Nullable: {IsNullable<long?>()}");
            sb.AppendLine($"Default Value: {default(long)}");
            sb.AppendLine($"Nominal Storage Allocation: {GetSizeOf<long>()}.");
            sb.AppendLine($"=== long data end ===");
            Print(sb.ToString());
        }

        static void PrintULongData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== ulong data start ===");
            sb.AppendLine($"Type: {typeof(ulong).FullName}");
            sb.AppendLine($"Min Value: {ulong.MinValue}");
            sb.AppendLine($"Max Value: {ulong.MaxValue}");
            sb.AppendLine($"Size: {GetBitCount<ulong>()}");
            sb.AppendLine($"Integer Type: {GetWhetherSignedOrUnsigned(ulong.MinValue)}");
            sb.AppendLine($"Is Nullable: {IsNullable<ulong?>()}");
            sb.AppendLine($"Default Value: {default(ulong)}");
            sb.AppendLine($"Nominal Storage Allocation: {GetSizeOf<ulong>()}.");
            sb.AppendLine($"=== ulong data end ===");
            Print(sb.ToString());
        }

        static void PrintShortData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== short data start ===");
            sb.AppendLine($"Type: {typeof(short).FullName}");
            sb.AppendLine($"Min Value: {short.MinValue}");
            sb.AppendLine($"Max Value: {short.MaxValue}");
            sb.AppendLine($"Size: {GetBitCount<short>()}");
            sb.AppendLine($"Integer Type: {GetWhetherSignedOrUnsigned(short.MinValue)}");
            sb.AppendLine($"Is Nullable: {IsNullable<short?>()}");
            sb.AppendLine($"Default Value: {default(short)}");
            sb.AppendLine($"Nominal Storage Allocation: {GetSizeOf<short>()}.");
            sb.AppendLine($"=== short data end ===");
            Print(sb.ToString());
        }

        enum SampleEnum { }

        static void PrintEnumData()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== enum data start ===");
            sb.AppendLine($"Type: {typeof(SampleEnum).FullName}");
            sb.AppendLine($"Size: {GetBitCount<SampleEnum>()}");
            sb.AppendLine($"Is Nullable: {IsNullable<SampleEnum?>()}");
            sb.AppendLine($"Default Value: {default(SampleEnum)}");
            sb.AppendLine($"Nominal Storage Allocation: {GetSizeOf<SampleEnum>()}.");
            sb.AppendLine($"=== enum data end ===");
            Print(sb.ToString());
        }

        struct SampleStruct
        {
            private int _id;
            private string _name;
        }

        static void PrintStructData()
        {
            var size = Marshal.SizeOf(typeof(SampleStruct));
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== struct data start ===");
            sb.AppendLine($"Type: {typeof(SampleStruct).FullName}");
            sb.AppendLine($"Size: {size * 8} bits");
            sb.AppendLine($"Is Nullable: {IsNullable<SampleStruct?>()}");
            sb.AppendLine($"Default Value: {default(SampleStruct)}");
            sb.AppendLine($"Nominal Storage Allocation: {size} bytes.");
            sb.AppendLine($"=== struct data end ===");
            Print(sb.ToString());
        }

        static void PrintValueTupleData()
        {
            unsafe
            {
                var defaultValueTupleSize = sizeof(ValueTuple);
                var valueTupleTripleDoubleSize = sizeof(ValueTuple<double, double, double>);
                var sb = new StringBuilder();
                sb.AppendLine($"\n=== ValueTuple data start ===");
                sb.AppendLine($"Type: {typeof(ValueTuple).FullName}");
                sb.AppendLine($"Default ValueTuple Size: {defaultValueTupleSize * 8} bits");
                sb.AppendLine($"Triple Double ValueTuple Size: {valueTupleTripleDoubleSize * 8} bits");
                sb.AppendLine($"Is Nullable: {IsNullable<ValueTuple?>()}");
                sb.AppendLine($"Default Value: {default(ValueTuple)}");
                sb.AppendLine($"Nominal Storage Allocation: {defaultValueTupleSize} bytes.");
                sb.AppendLine($"Triple Double Nominal Storage Allocation: {valueTupleTripleDoubleSize} bytes.");
                sb.AppendLine($"=== ValueTuple data end ===");
                Print(sb.ToString());
            }
        }

        #endregion Value Type Print Data Methods

        #region Reference Type Print Data Methods

        private static readonly XmlSerializer _serializer = new XmlSerializer(typeof(List<object>));

        public static long SerializeObject(object obj)
        {
            using (var stream = new MemoryStream())
            {
                _serializer.Serialize(stream, obj);
                stream.Position = 0;
                return stream.Length;
            }
        }

        [DataContract]
        class Product
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string Description { get; set; }
        }

        static void PrintObjectData()
        {
            var product = new Product()
            {
                Name = "Crisps",
                Description = "Salt & Vinegar"
            };

            var json = new DataContractJsonSerializer(typeof(Product));
            long size;

            using (var ms = new MemoryStream())
            {
                json.WriteObject(ms, product);
                ms.Position = 0;
                size = ms.Length;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"\n=== object data start ===");
            sb.AppendLine($"Type: {typeof(Product).FullName}");
            sb.AppendLine($"Default object Size: {size * 8} bits");
            sb.AppendLine($"Is Nullable: Yes");
            sb.AppendLine($"Nominal Storage Allocation: {size} bytes.");
            sb.AppendLine($"=== object data end ===");
            Print(sb.ToString());
        }

        static void PrintStringData()
        {
            var text = "Hello, World!";
            var size = text.Length * 2;
            var sb = new StringBuilder();
            sb.AppendLine($"\n=== string data start ===");
            sb.AppendLine("C# uses Unicode which is 2 bytes per character.");
            sb.AppendLine($"Type: {typeof(Product).FullName}");
            sb.AppendLine($"Default object Size: {size * 8} bits");
            sb.AppendLine($"Is Nullable: Yes");
            sb.AppendLine($"Nominal Storage Allocation: {size} bytes.");
            sb.AppendLine($"=== string data end ===");
            Print(sb.ToString());
        }

        delegate string Message();

        static string SayHello()
        {
            return "Hola!";
        }

        static string SayGoodbye()
        {
            return "Tarah!";
        }
        
        static void PrintDelegateData()
        {
            var hi = new Message(SayHello);
            var bye = new Message(SayGoodbye);
            Print(hi());
            Print(bye());

            var sb = new StringBuilder();
            sb.AppendLine($"\n=== string data start ===");

            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                unsafe
                {
                    try
                    {
                        var rt = type.GetTypeInfo().AsType();
                        var sz = rt.IsSerializable;
                        if (sz)
                        {
                            Print(rt.Name);
                            if (rt.FullName == "CH03_PrimitivesAndObjectTypes.Program+Message")
                            {
                                var objectSerialize = new ObjectSerialize
                                {
                                    Object = rt
                                };
                                using var ms = new MemoryStream();
                                using var xw = XmlWriter.Create(ms);
                                var submit = new XmlSerializer(typeof(ObjectSerialize));
                                submit.Serialize(xw, objectSerialize);
                                ms.Position = 0;
                                var size = ms.Length;
                                sb.AppendLine($"{rt.FullName} is {size} bytes ({size * 8} bits) in size.");
                                sb.AppendLine($"Base Type: {rt.BaseType.FullName}");
                            }
                        }
                    }
                    catch { }
                }
            }
            
            sb.AppendLine($"=== string data end ===");
            Print(sb.ToString());
        }

        #endregion Reference Type Print Data Methods

        #region Benchmarking Methods

        private static void BenchmarkObjects()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            const int count = 1000000;
            IPoint[] points = new IPoint[count];

            for (int i = 0; i < count; i++)
                points[i] = new PointObject(i + 0.1, i + 1.1);

            stopwatch.Stop();
            Print($" Elapsed Time (object): {stopwatch.ElapsedTicks}");
            GC.Collect();
        }

        private static void BenchmarkStructs()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            const int count = 1000000;
            IPoint[] points = new IPoint[count];
            
            for (int i = 0; i < count; i++)
                points[i] = new PointStruct(i + 0.1, i + 1.1);

            stopwatch.Stop();
            Print($" Elapsed Time (struct): {stopwatch.ElapsedTicks}");
            GC.Collect();
        }

        #endregion Benchmarking Methods
    }
}
