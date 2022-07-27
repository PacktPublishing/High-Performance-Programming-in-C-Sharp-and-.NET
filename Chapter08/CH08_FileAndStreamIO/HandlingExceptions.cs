using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH08_FileAndStreamIO
{
	public class HandlingExceptions
	{
        public StreamWriter GetStreamWriter(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("Invalid argument. Path is null or empty!");
                return null;
            }

            try
            {
                return new StreamWriter(new FileStream(path, FileMode.CreateNew));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory does not exist.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file or directory does not exist.");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive does not exist.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Supported path length exceeded.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied.");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation cancelled.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                Console.WriteLine("Sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                Console.WriteLine("File already exists.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 87)
            {
                Console.WriteLine("Invalid argument.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 183)
            {
                Console.WriteLine("File or directory already exists.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
            return null;
        }
    }
}
