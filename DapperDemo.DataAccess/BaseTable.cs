using Dapper;
using Microsoft.Data.Sqlite;

namespace DapperDemo.DataAccess;

public class BaseTable<T>
{
    protected readonly SqliteConnection Db;

    public BaseTable(string connectionString)
    {
        Db = new SqliteConnection(connectionString);
    }

    protected IEnumerable<T>? ExecuteWithResult(string sql)
    {
        Db.Open();

        var result = Db.Query<T>(sql);
        
        Db.Close();

        return result;
    }

    protected bool ExecuteWithNotResult(string sql)
    {
        Db.Open();

        var result = Db.Execute(sql);
        
        Db.Close();

        return result != 0;
    }
}