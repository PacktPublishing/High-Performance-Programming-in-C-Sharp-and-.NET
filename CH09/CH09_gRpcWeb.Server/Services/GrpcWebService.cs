namespace CH09_gRpcWeb.Server.Services
{
	using CH09_gRpcWeb.Shared;
	using System.Threading.Tasks;

	public class GrpcWebService : IGrpcWebService
	{
		public Task<GrpcWebResponse> DoWork(GrpcWebRequest request)
		{
			return Task.FromResult(new GrpcWebResponse()
			{
				NewId = request.Id,
				NewName = request.Name,
				NewDescription = request.Description
			});
		}
	}
}
