namespace CH16_AsynchronousProgramming
{
    using System.Text;

    internal class FileReadWriteAsync
    {
        public static async Task WriteTextAsync()
        {
            string filePath = @"C:\Temp\Greetings.txt";
            string text = "Hello, World!";

            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (FileStream fileStream = new FileStream(
                    filePath,
                    FileMode.Append, 
                    FileAccess.Write, 
                    FileShare.None,
                    bufferSize: 4096, 
                    useAsync: true
                )
            )
            {
                await fileStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }

        public static async Task<string> ReadTextAsync()
        {
            string filePath = @"C:\Temp\Greetings.txt";
            using (FileStream fileStream = new FileStream(
                    filePath,
                    FileMode.Open, 
                    FileAccess.Read, 
                    FileShare.Read,
                    bufferSize: 4096, 
                    useAsync: true
                )
            )
            {
                StringBuilder sb = new StringBuilder();

                byte[] buffer = new byte[0x1000];
                int numRead;
                while ((numRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }

                return sb.ToString();
            }
        }
    }
}
