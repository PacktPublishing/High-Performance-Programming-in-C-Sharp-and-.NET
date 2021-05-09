using System;
using System.IO;
using System.IO.Pipelines;
namespace CH09_TcpClient
{
	using System.Net;
	using System.Net.Sockets;
	using System.Threading.Tasks;

	class Program
	{
		static async Task Main(string[] args)
		{
			Socket clientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
			Console.WriteLine("Connecting to port 7000");
			clientSocket.Connect(new IPEndPoint(IPAddress.Loopback, 7000));
			NetworkStream networkStream = new NetworkStream(clientSocket);
			await Console.OpenStandardInput().CopyToAsync(networkStream);
		}
	}
}
