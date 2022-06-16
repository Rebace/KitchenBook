using System.Runtime.Serialization;

namespace KitchenBook.Api.MessageContracts;

[DataContract]
public class RegisterDto
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
}
