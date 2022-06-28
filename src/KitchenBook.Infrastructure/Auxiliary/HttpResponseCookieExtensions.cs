using Microsoft.AspNetCore.Http;

namespace KitchenBook.Infrastructure.Auxiliary;

public static class HttpResponseCookieExtensions
{
    public static void AppendTokenToCookies(this HttpResponse httpResponse, string token)
    {
        httpResponse.Cookies.Append("Token", token);
    }

    public static void AppendLoginToCookies(this HttpResponse httpResponse, string login)
    {
        httpResponse.Cookies.Append("Login", login);
    }
}
