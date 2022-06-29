namespace KitchenBook.Api.MessageContracts.UserModel;

public class UserDto
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public UserDto(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
