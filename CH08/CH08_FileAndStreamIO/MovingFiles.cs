namespace CH08_FileAndStreamIO
{
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Order;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Text;

	[MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Declared)]
	[RankColumn]
	public class MovingFiles
	{
		private Dictionary<string, FileInfo> _cache;

		private const string SOURCE_DIRECTORY = @"C:\Temp\Source\";
		private const string DESTINATION_DIRECTORY = @"C:\Temp\Destination\";
		private const string FILENAME = "Moonshine-3.0.0.exe";

		[GlobalSetup]
		public void PreloadFilesAndCacheThem()
		{
			var files = new DirectoryInfo(SOURCE_DIRECTORY).GetFileSystemInfos();
			_cache = new Dictionary<string, FileInfo>();
			foreach (var f in files) 
			{
				_cache.Add(f.FullName, f as FileInfo);
			}
		}

		[Benchmark]
		public void FileCopy()
		{
			PreMoveCheck();
			File.Copy($"{SOURCE_DIRECTORY}{FILENAME}", $"{DESTINATION_DIRECTORY}{FILENAME}");
		}

		[Benchmark]
		public void FileInfoMoveTo()
		{
			PreMoveCheck();
			FileInfo fileinfo = new FileInfo($"{SOURCE_DIRECTORY}{FILENAME}");
			fileinfo.MoveTo($"{DESTINATION_DIRECTORY}{FILENAME}");
		}

		[Benchmark]
		public void FileInfoReadCacheAndMoveTo()
		{
			PreMoveCheck();
			FileInfo fileInfo = _cache[$"{SOURCE_DIRECTORY}{FILENAME}"];
			if (fileInfo.Exists)
				fileInfo.MoveTo($"{DESTINATION_DIRECTORY}{FILENAME}");
		}

		[GlobalCleanup]
		public void PreMoveCheck()
		{
			if (File.Exists($"{SOURCE_DIRECTORY}{FILENAME}"))
				if (File.Exists($"{DESTINATION_DIRECTORY}{FILENAME}"))
				{
					File.Delete($"{DESTINATION_DIRECTORY}{FILENAME}");
				}
			if (!File.Exists($"{SOURCE_DIRECTORY}{FILENAME}") && File.Exists($"{DESTINATION_DIRECTORY}{FILENAME}"))
			{

				FileInfo fileinfo = new FileInfo($"{DESTINATION_DIRECTORY}{FILENAME}");
				fileinfo.MoveTo($"{SOURCE_DIRECTORY}{FILENAME}");
			}
		}
	}
}
