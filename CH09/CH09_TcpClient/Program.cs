using System;
using System.IO;
using System.IO.Pipelines;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

Socket clientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
Console.WriteLine("Connecting to port 7000");
clientSocket.Connect(new IPEndPoint(IPAddress.Loopback, 5396));
NetworkStream networkStream = new NetworkStream(clientSocket);
await Console.OpenStandardInput().CopyToAsync(networkStream);
