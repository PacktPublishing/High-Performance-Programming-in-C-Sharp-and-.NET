namespace CH04_OutOfMemoryExceptions
{
    using System.Text.RegularExpressions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime;
	using System.Text;

	class Program
    {

        private static string _filename = @"G:\Temp\SampleData.csv";

        static void Main(string[] args)
        {
            //DataExportToCsv();
            //ReadCsvBroken();
            ReadCsvPredictive();
            Console.ReadKey();
        }

        private static void DataExportToCsv()
		{
            int row = 0;

            try
            {
                File.Delete(_filename);
                using (FileStream fs = new FileStream(_filename, FileMode.OpenOrCreate))
				{
                    fs.Write(Encoding.Unicode.GetBytes("Id, Name, Description\n"));
                    for (int i = 0; i <= 491616373; i++)
                    {
                        row = i;
                        Console.WriteLine($"Writing row {row} to CSV data. There are {491616373-row} rows remaining.");
                        fs.Write(Encoding.Unicode.GetBytes($"{i}, Name {i}, Description {i}\n"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DataExportToCsv: {ex.GetBaseException().Message}");
            }
        }

        private static void ReadCsvBroken()
		{
            int row = 0;

            try
            {
                string csv = File.ReadAllText(_filename);
            }
            catch (OutOfMemoryException oomex)
            {
                Console.WriteLine($"ReadCsvBroken: {oomex.GetBaseException().Message}");
            }
        }

        private static void ReadCsvPredictive()
        {
            int row = 0;
            try
            {
                string alphabet = "abcdefghijklmnopqrstuvwxyz";
                using (new MemoryFailPoint(alphabet.Length))
				{
                    string alpha = alphabet;
				}
				FileInfo fi = new FileInfo(_filename);
                int length = unchecked((int)fi.Length);
				using (new MemoryFailPoint(length))
				{
					string csv = File.ReadAllText(_filename);
				}
			}
            catch (OutOfMemoryException oomex)
            {
                Console.WriteLine($"ReadCsvPredictive: {oomex.GetBaseException().Message}");
            }
        }
    }
}
