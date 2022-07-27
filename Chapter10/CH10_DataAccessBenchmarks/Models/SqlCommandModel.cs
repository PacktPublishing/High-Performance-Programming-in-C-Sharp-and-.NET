using System.Data;

namespace CH10_DataAccessBenchmarks.Models
{
    public class SqlCommandModel
    {
        public string CommandText { get; set; }
        public CommandType CommandType { get; set; }
        public SqlCommandParameterModel[] CommandParameters { get; set; }
    }
}
