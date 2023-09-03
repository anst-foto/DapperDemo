namespace DapperDemo.Model;

public class Account
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
    public bool IsActive { get; set; }
}