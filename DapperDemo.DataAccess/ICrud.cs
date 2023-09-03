namespace DapperDemo.DataAccess;

public interface ICrud<T>
{
    public bool Insert(T data);
    public bool Update(T data);
    public bool Delete(T data);
    public IEnumerable<T>? FindAll();
    public T? FindById(int id);
}