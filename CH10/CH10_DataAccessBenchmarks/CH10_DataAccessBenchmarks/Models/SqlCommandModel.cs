namespace CH10_DataAccessBenchmarks.Models
{
	using System.Data;

	public class SqlCommandModel
	{
		public string CommandText { get; set; }
		public CommandType CommandType { get; set; }
		public SqlCommandParameterModel[] CommandParameters { get; set; }
	}
}
