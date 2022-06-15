using System.ComponentModel.DataAnnotations;

namespace KitchenBook.Domain.UserModel;

public class User
{
    [Key]
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Login { get; private set; }
    public string Token { get; set; }
    public string Password { get; private set; }
    public string? Description { get; private set; }

    // Workaround for EF
    protected User()
    {
    }

    public User(int id, string name, string login, string password, string description, string token)
    {
        Id = id;
        Name = name;
        Token = token;
        Login = login;
        Password = password;
        Description = description;
    }
}
