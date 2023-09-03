using DapperDemo.Model;

namespace DapperDemo.DataAccess;

public class TableRoles : BaseTable<Role>, ICrud<Role>
{
    public TableRoles(string connectionString) : base(connectionString)
    {
    }


    public bool Insert(Role data)
    {
        var sql = $"INSERT INTO table_roles(name) VALUES ('{data.Name}')";
        return Execute(sql);
    }

    public bool Update(Role data)
    {
        var sql = $"UPDATE table_roles SET name = '{data.Name}' WHERE id = {data.Id}";
        return Execute(sql);
    }

    public bool Delete(Role data)
    {
        return false;
    }

    public IEnumerable<Role>? FindAll()
    {
        var sql = "SELECT * FROM table_roles";
        return FindAll(sql);
    }

    public Role? FindById(int id)
    {
        var sql = $"SELECT * FROM table_roles WHERE id = {id}";
        return FindSingle(sql);
    }
}