using CH09_GrpcService;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace CH08_GrpcServiceClient
{
	class Program
	{
		static async void Main(string[] args)
		{
			await ExecuteGrpcClient();
		}

		static async Task ExecuteGrpcClient()
		{
			await SingleGrpcMessageResponse();
			await GrpcMessageResponseStream();
		}

		static async Task SingleGrpcMessageResponse()
		{
			GrpcChannel grpcChannel = GrpcChannel.ForAddress("https://localhost:5001");
			Greeter.GreeterClient greeterClient = new Greeter.GreeterClient(grpcChannel);
			HelloReply helloReply = await greeterClient.SayHelloAsync(new HelloRequest
			{
				Name = "gRPC Demonstration!"
			});
			Console.WriteLine($"Message From gRPC Server: {helloReply.Message}");
		}

		static async Task GrpcMessageResponseStream()
		{
			GrpcChannel grpcChannel = GrpcChannel.ForAddress("https://localhost:5001");
			Greeter.GreeterClient greeterClient = new Greeter.GreeterClient(grpcChannel);
			AsyncServerStreamingCall<HelloReply> helloReply = greeterClient.SayHelloStream(new HelloRequest
			{
				Name = "gRPC Streaming Demonstration!"
			});
			
			await foreach (HelloReply item in helloReply.ResponseStream.ReadAllAsync())
			{
				Console.WriteLine(item.Message);
			}
		}
	}
}
