namespace CH09_gRpcWeb.Shared
{
	using System.Runtime.Serialization;

	[DataContract]
	public class GrpcWebResponse
	{
		[DataMember(Order = 1)]
		public int NewId { get; set; }

		[DataMember(Order = 2)]
		public string NewName { get; set; }

		[DataMember(Order = 3)]
		public string NewDescription { get; set; }
	}
}
