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
	public class GettingFileSizes
	{
		public const string DIRECTORY = @"C:\Windows\System32\";

		[Benchmark]
		public int GetDirectorySizeUsingGetFileSystemInfos()
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(DIRECTORY);
			FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos();

			int directorySize = 0;
			for (int i = 0; i < fileSystemInfos.Length; i++)
			{
				FileInfo fileInfo = fileSystemInfos[i] as FileInfo;
				if (fileInfo != null)
					directorySize += (int)fileInfo.Length;
			}
			return directorySize;
		}

		[Benchmark]
		public int GetDirectorySizeUsingArrayAndFileInfo()
		{
			string[] files = Directory.GetFiles(DIRECTORY);
			int directorySize = 0;
			for (int i = 0; i < files.Length; i++)
			{
				directorySize += (int)(new FileInfo(files[i]).Length);
			}
			return directorySize;
		}
	}
}
