using Microsoft.AspNetCore.Http;

namespace KitchenBook.Infrastructure.Auxiliary;

public static class AddingToken
{
    public static void AppendTokenToCookies(this HttpResponse HttpContext, string token)
    {
        HttpContext.Cookies.Append("Token", token);
    }
}
