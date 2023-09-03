namespace DapperDemo.DataAccess;

public class DataBase
{
    public TableRoles Roles { get; set; }
    public TableAccounts Accounts { get; set; }
    public TableUsers Users { get; set; }

    public DataBase(string connectionString)
    {
        Roles = new TableRoles(connectionString);
        Accounts = new TableAccounts(connectionString);
        Users = new TableUsers(connectionString);
    }
}