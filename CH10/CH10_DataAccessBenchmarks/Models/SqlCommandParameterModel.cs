using System.Data;

namespace CH10_DataAccessBenchmarks.Models
{
    public class SqlCommandParameterModel
    {
        public string ParameterName { get; set; }
        public DbType DataType { get; set; }
        public dynamic Value { get; set; }
    }
}
