using CH10_DataAccessBenchmarks.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH10_DataAccessBenchmarks.Data
{
    public class DapperDotNet : IDisposable
    {
        private bool isDisposed = false;
        private IDbConnection _dbConnection;
        public DapperDotNet(string connection)
        {
            SimpleCRUD
                    .SetDialect(SimpleCRUD.Dialect.SQLServer);
            _dbConnection = new SqlConnection(connection);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
                return;
            if (disposing)
                _dbConnection.Dispose();
            isDisposed = true;
        }

    public int ExecuteNonQuery(string sql)
    {
        try
        {
            _dbConnection.Open();
            return _dbConnection.Execute(sql);
        }
        finally
        {
            _dbConnection.Close();
        }
    }

    public void ExecuteNonQuery(SqlCommandModel model)
    {
        try
        {
            _dbConnection.Open();
            var parameters = new DynamicParameters();
            foreach (
             SqlCommandParameterModel parameter in
             model.CommandParameters
         )
                parameters.Add(
                    parameter.ParameterName,
                    parameter.Value
                );
            _dbConnection.Query(
            model.CommandText,
            parameters,
            commandType: CommandType.StoredProcedure
        );
        }
        finally
        {
            _dbConnection.Close();
        }
    }

    public T ExecuteScalar<T>(string sql)
    {
        try
        {
            _dbConnection.Open();
            return _dbConnection.ExecuteScalar<T>(sql);
        }
        finally
        {
            if (_dbConnection != null
             && _dbConnection.State
                 == ConnectionState.Open)
                _dbConnection.Close();
        }
    }

    public string ExecuteScalarSP(SqlCommandModel model)
    {
        try
        {
            _dbConnection.Open();
            var parameters = new DynamicParameters(); parameters.Add(
  model.CommandParameters[0]
   .ParameterName,
model.CommandParameters[0].Value
);
            return _dbConnection.Query<Product>(
             model.CommandText,
             parameters,
             commandType: CommandType.StoredProcedure
         ).First().ProductName;
        }
        finally
        {
            if (
             _dbConnection != null
             && _dbConnection.State
                 == ConnectionState.Open)
                _dbConnection.Close();
        }
    }

    public IEnumerator<T> ExecuteReader<T>(string sql)
     where T : class
    {
        try
        {
            _dbConnection.Open();
            return _dbConnection.Query<T>(sql)
             .GetEnumerator();
        }
        finally
        {
            if (_dbConnection != null
             && _dbConnection.State
                 == ConnectionState.Open)
                _dbConnection.Close();
        }
    }

    public IEnumerator<Product> ExecuteReaderSP<Product>(
     SqlCommandModel model
)
    {
        try
        {
            _dbConnection.Open();
            var parameters = new DynamicParameters();
            foreach (SqlCommandParameterModel parameter
             in model.CommandParameters) parameters.Add(
parameter.ParameterName,
parameter.Value
);
            return _dbConnection.Query<Product>(
                model.CommandText,
                parameters,
                commandType: CommandType.StoredProcedure
            ).GetEnumerator();
        }
        finally
        {
            if (_dbConnection != null
             && _dbConnection.State
             == ConnectionState.Open)
                _dbConnection.Close();
        }
    }

    public string GetProductNameSP(string productName)
    {
        try
        {
            _dbConnection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@ProductName", productName);
            return _dbConnection.Query<Product>(
             $"GetProductName",
             parameters,
             commandType: CommandType.StoredProcedure
         ).First().ProductName;
        }
        finally
        {
            if (_dbConnection != null
             && _dbConnection.State
             == ConnectionState.Open)
                _dbConnection.Close();
        }
    }

}

}