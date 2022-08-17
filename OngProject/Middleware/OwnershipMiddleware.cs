using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OngProject.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class OwnershipMiddleware
    {
        private readonly RequestDelegate _next;

        public OwnershipMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var method = httpContext.Request.Method;
            var actualPath = httpContext.Request.Path.Value;  //  /api/{controller}/{id}
            var path = "/api/User/";
            if (actualPath.Contains(path))
            {
                if ((HttpMethods.IsDelete(method) || HttpMethods.IsPatch(method)))
                {
                    var role = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                    var claimId = httpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                    var idquery = actualPath.Remove(0, path.Length);   // Dejo solo el id de la direccion de la request
                    if (idquery != claimId && role != "Administrador")
                    {
                        httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;   
                        return;
                    }
                }
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class OwnershipMiddlewareExtensions
    {
        public static IApplicationBuilder UseOwnershipMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OwnershipMiddleware>();
        }
    }
}
