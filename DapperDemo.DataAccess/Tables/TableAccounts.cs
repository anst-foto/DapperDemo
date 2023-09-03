using DapperDemo.Model;

namespace DapperDemo.DataAccess.Tables;

public class TableAccounts : BaseTable<Account>, ICrud<Account>
{
    public TableAccounts(string connectionString) : base(connectionString)
    {
    }

    public bool Insert(Account data)
    {
        var sql = $"INSERT INTO table_accounts(login, password, role_id) VALUES ('{data.Login}', '{data.Password}', {data.RoleId})";
        return Execute(sql);
    }

    public bool Update(Account data)
    {
        var sql = $"UPDATE table_accounts SET login = '{data.Login}', password = '{data.Password}', role_id = {data.RoleId}, is_active = {data.IsActive} WHERE id = {data.Id}";
        return Execute(sql);
    }

    public bool Delete(Account data)
    {
        var sql = $"UPDATE table_accounts SET is_active = 0 WHERE id = {data.Id}";
        return Execute(sql);
    }

    public IEnumerable<Account>? FindAll()
    {
        var sql = "SELECT * FROM table_accounts";
        return FindAll(sql);
    }

    public Account? FindById(int id)
    {
        var sql = $"SELECT * FROM table_accounts WHERE id = {id}";
        return FindSingle(sql);
    }
}