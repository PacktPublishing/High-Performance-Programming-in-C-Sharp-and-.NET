namespace CH08_FileAndStreamIO
{
	using System;
	using System.IO;
	using System.Text;
	using System.Threading.Tasks;

	internal class AsyncFileAccess
	{
		public async Task WriteTextToFileAsync(string text, string path)
		{
			byte[] encodeText = Encoding.Unicode.GetBytes(text);
			using var fileStream = new FileStream(
				path, 
				FileMode.Create, 
				FileAccess.Write, 
				FileShare.None, 
				bufferSize: 4096, 
				useAsync: true
			);
			await fileStream.WriteAsync(encodeText, 0, encodeText.Length);
		}

		public async Task<string> ReadTextFromFileAsync(string path)
		{

			StringBuilder sb = new StringBuilder();
			byte[] buffer = new byte[0x1000];
			int numberOfBytesToDecode;

			using var fileStream = new FileStream(
				path,
				FileMode.OpenOrCreate, 
				FileAccess.Read, 
				FileShare.Read,
				bufferSize: 4096, 
				useAsync: true
			);

			while ((numberOfBytesToDecode = await fileStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
			{
				sb.AppendLine(Encoding.Unicode.GetString(buffer, 0, numberOfBytesToDecode));
			}

			return sb.ToString();
		}

		public void DemonstrateAsyncFileOps()
		{
			WriteTextToFileAsync(
				"Supercalifragilisticexpialidocius", @"C:\Temp\film.txt"
			).GetAwaiter().GetResult();
			string text = ReadTextFromFileAsync(
				@"C:\Temp\film.txt"
			).GetAwaiter().GetResult();
			Console.WriteLine($"The Text written was: {text}");
		}
	}
}
