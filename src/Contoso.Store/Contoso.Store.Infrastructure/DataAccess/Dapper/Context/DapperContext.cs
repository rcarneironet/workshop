using Contoso.Store.Shared.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Contoso.Store.Infrastructure.DataAccess.Dapper.Context
{
    //Garbage Collector: Processo que faz gerenciamento de memoria
    public class DapperContext : IDisposable
    {
        public SqlConnection Connection { get; set; }
        public DapperContext()
        {
            Connection = new SqlConnection(ConnectionStringHelper.ConnectionString);
            Connection.Open();
        }
        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }
        }
    }
}
