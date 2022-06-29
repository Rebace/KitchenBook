using System.Runtime.Serialization;

namespace KitchenBook.Api.MessageContracts;

[DataContract]
public class UpsertUserDto
{
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string? Description { get; set; }
}
