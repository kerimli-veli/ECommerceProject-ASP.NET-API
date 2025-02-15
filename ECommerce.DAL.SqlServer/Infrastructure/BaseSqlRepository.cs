using Microsoft.Data.SqlClient;

namespace ECommerce.DAL.SqlServer.Infrastructure;

public class BaseSqlRepository(string connectionstring)
{
    private readonly string _connectionString = connectionstring;

    protected SqlConnection OpenConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection;
    }



}
