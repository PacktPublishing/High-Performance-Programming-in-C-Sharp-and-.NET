using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using CH09_gRpcWeb.Client;
using CH09_gRpcWeb.Shared;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components;
using ProtoBuf.Grpc.Client;

namespace CH09_gRpcWeb.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			builder.Services.AddSingleton(services =>
			{
				// Get the service address from appsettings.json
				var config = services.GetRequiredService<IConfiguration>();
				var backendUrl = config["BackendUrl"];

				// If no address is set then fallback to the current webpage URL
				if (string.IsNullOrEmpty(backendUrl))
				{
					var navigationManager = services.GetRequiredService<NavigationManager>();
					backendUrl = navigationManager.BaseUri;
				}

				var httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler());

				return GrpcChannel.ForAddress(
					backendUrl,
					new GrpcChannelOptions
					{
						HttpHandler = httpHandler
					});
			});

			builder.Services.AddTransient<IGrpcWebService>(services =>
			{
				var grpcChannel = services.GetRequiredService<GrpcChannel>();
				return grpcChannel.CreateGrpcService<IGrpcWebService>();
			});

			await builder.Build().RunAsync();
		}
	}
}