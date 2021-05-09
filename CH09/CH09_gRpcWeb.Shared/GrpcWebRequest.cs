namespace CH09_gRpcWeb.Shared
{
	using System.Runtime.Serialization;

	[DataContract]
	public class GrpcWebRequest
	{
		[DataMember(Order = 1)]
		public int Id { get; set; }

		[DataMember(Order = 2)]
		public string Name { get; set; }

		[DataMember(Order = 3)]
		public string Description { get; set; }
	}
}
