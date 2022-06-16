using Microsoft.AspNetCore.Http;

namespace KitchenBook.Infrastructure.Auxiliary;

public static class AddingToCookies
{
    public static void AppendTokenToCookies(this HttpResponse HttpContext, string token)
    {
        HttpContext.Cookies.Append("Token", token);
    }

    public static void AppendLoginToCookies(this HttpResponse HttpContext, string login)
    {
        HttpContext.Cookies.Append("Login", login);
    }
}
