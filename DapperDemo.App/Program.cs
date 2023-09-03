using DapperDemo.App;
using DapperDemo.DataAccess;
using DapperDemo.Model;

var db = new DataBase(@"Data Source=D:\Programming\DapperDemo\DapperDemo.SQL\accounts.db;");
var accounts = db.Accounts.FindAll();

if (accounts is null)
{
    CLI.PrintError("Ошибка получения данных из БД");
    return;
}

var repeat = true;
Account currentAccount = null;
do
{
    var login = CLI.InputString("Введите логин: ");
    var password = CLI.InputString("Введите пароль: ");

    foreach (var account in accounts)
    {
        if (account.Login == login && account.Password == password && account.IsActive)
        {
            repeat = false;
            currentAccount = account;
            break;
        }
    }
} while (repeat);

CLI.PrintInfo("Вы успешно авторизовались!");

var currentUser = db.Users.FindById(currentAccount.Id);
CLI.PrintInfo($"{currentUser.LastName} {currentUser.FirstName}, добро пожаловать!");

var currentRole = db.Roles.FindById(currentAccount.RoleId);
switch (currentRole.Name)
{
    case "admin":
        PrintAll();
        return;
    case "user":
        //PrintOne(currentAccount);
        CLI.PrintInfo($"{currentAccount.Id}:\t{currentUser.LastName} {currentUser.FirstName}\t{currentAccount.Login}\t{currentAccount.Password}\t{currentRole.Name}");
        return;
}

return;

void PrintAll()
{
    var accounts = db.Accounts.FindAll();
    var users = db.Users.FindAll();

    var u = accounts.Zip(users);

    foreach (var tuple in u)
    {
        var account = tuple.First;
        var user = tuple.Second;
        var role = db.Roles.FindById(account.RoleId).Name;
        CLI.PrintInfo($"{account.Id}:\t{user.LastName} {user.FirstName}\t\t\t{account.Login}\t{account.Password}\t{role}");
    }
}

void PrintOne(Account account)
{
    var user = db.Users.FindById(account.Id);
    var role = db.Roles.FindById(account.RoleId).Name;
    
    CLI.PrintInfo($"{account.Id}:\t{user.LastName} {user.FirstName}\t\t\t{account.Login}\t{account.Password}\t{role}");
}