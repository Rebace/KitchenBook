﻿using KitchenBook.Domain.UserModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.OperationalInsights.Models;
using Newtonsoft.Json;

namespace KitchenBook.Infrastructure.Web;

public class UserAuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IUserRepository _userRepository;

    public UserAuthenticationMiddleware(RequestDelegate next, IUserRepository userRepository)
    {
        _next = next;
        _userRepository = userRepository;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.Value.ToLower() == "/user/login"
            || context.Request.Path.Value.ToLower() == "/user/register"
            || context.Request.Path.Value.ToLower() == "/recipe/get-all")
        {
            await _next(context);
            return;
        }

        string login = context.Request.Cookies["Login"];
        if (login == null)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsync("");
            return;
        }

        string token = context.Request.Cookies["Token"];
        if (token == null)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsync("");
            return;
        }

        User user = await _userRepository.GetByLogin(login);

        if (user.Token != token)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsync("");
        }
    }
}
