using System.Runtime.Serialization;

namespace KitchenBook.Api.MessageContracts;

[DataContract]
public class LoginDto
{
    public string Login { get; set; }
    public string Password { get; set; }
}
