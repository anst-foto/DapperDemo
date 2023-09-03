using DapperDemo.Model;

namespace DapperDemo.DataAccess;

public class TableUsers : BaseTable<User>, ICrud<User>
{
    public TableUsers(string connectionString) : base(connectionString)
    {
    }

    public bool Insert(User data)
    {
        var sql = $"INSERT INTO table_users(first_name, last_name, email) VALUES ('{data.FirstName}', '{data.LastName}', '{data.Email}')";
        return Execute(sql);
    }

    public bool Update(User data)
    {
        var sql = $"UPDATE table_users SET first_name = '{data.FirstName}', last_name = '{data.LastName}', email = '{data.Email}' WHERE id = {data.Id}";
        return Execute(sql);
    }

    public bool Delete(User data)
    {
        return false;
    }

    public IEnumerable<User>? FindAll()
    {
        var sql = "SELECT * FROM table_users";
        return FindAll(sql);
    }

    public User? FindById(int id)
    {
        var sql = $"SELECT * FROM table_users WHERE id = {id}";
        return FindSingle(sql);
    }
}