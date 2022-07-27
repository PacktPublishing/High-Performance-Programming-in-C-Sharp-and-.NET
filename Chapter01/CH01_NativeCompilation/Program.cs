using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace CH01_NativeCompilation
{
    class Program
    {
        private static string _baseDirectory = string.Empty;
        private static string _sourceExtension = string.Empty;
        private static string _destinationExtension = string.Empty;

        static void Main(string[] args)
        {
            Console.Write("Enter Source Directory: ");
            _baseDirectory = Console.ReadLine();
            Console.Write("Enter Source Extension: ");
            _sourceExtension = Console.ReadLine();
            Console.Write("Enter Destination Extension: ");
            _destinationExtension = Console.ReadLine();
            new Program().BatchConvert();
        }

        private void BatchConvert()
        {
            var directory = new DirectoryInfo(_baseDirectory);
            ProcessFolder(directory);
        }

        private void ProcessFolder(DirectoryInfo directoryInfo)
        {
            Console.WriteLine($"Processing Directory: {directoryInfo.FullName}");
            var fileInfos = directoryInfo.EnumerateFiles();
            var directorieInfos = directoryInfo.EnumerateDirectories();

            foreach (var fileInfo in fileInfos)
                if (fileInfo.Extension.Replace(".", "") == _sourceExtension)
                    ConvertFile(fileInfo);

            foreach (var dirInfo in directorieInfos)
                ProcessFolder(dirInfo);
        }

        private void ConvertFile(FileInfo fileInfo)
        {
            var timeout = 10000;
            var source = $"\"{fileInfo.FullName}\"";
            var destination = $"\"{fileInfo.FullName.Replace(_sourceExtension, _destinationExtension)}\"";

            if (File.Exists(fileInfo.FullName.Replace(_sourceExtension, _destinationExtension)))
            {
                Console.WriteLine($"Unprocessed: {fileInfo.FullName}");
                return;
            }

            Console.WriteLine($"Converting file: {fileInfo.FullName} from {_sourceExtension} to {_destinationExtension}.");

            using var ffmpeg = new Process
            {
                StartInfo = {
                    FileName = @"C:\Tools\ffmpeg\bin\ffmpeg.exe",
                    Arguments = $"-i {source} {destination}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            ffmpeg.EnableRaisingEvents = false;
            ffmpeg.OutputDataReceived += (s, e) => Debug.WriteLine($"Debug: e.Data");
            ffmpeg.ErrorDataReceived += (s, e) => Debug.WriteLine($@"Error: {e.Data}");
            ffmpeg.Start();
            ffmpeg.BeginOutputReadLine();
            ffmpeg.BeginErrorReadLine();
            ffmpeg.WaitForExit(timeout);
        }
    }
}