using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OngProject.Middleware
{
    public class RoleAutorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleAutorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            bool containsPath = false;
            var method = context.Request.Method;
            var path = context.Request.Path.ToString();
            var role = context.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Role);

            List<string> methods = new()
            {
                "PATCH",
                "PUT",
                "POST",
                "DELETE"
            };
            List<string> paths = new List<string>();
            paths.Add("/activity");
            paths.Add("/activities");
            paths.Add("/category");
            paths.Add("/categories");
            paths.Add("/comments");
            paths.Add("/contacts");
            paths.Add("/member");
            paths.Add("/members");
            paths.Add("/news");
            paths.Add("/organizations");
            paths.Add("/slide");
            paths.Add("/slides");
            paths.Add("/testimonials");
            paths.Add("/user");
            if (methods.Contains(method.ToLower()) && paths.Contains(path.ToLower()))
            {
                if (!context.User.IsInRole("Administrador"))
                {
                    context.Response.StatusCode = 403;
                    return;
                }
            }
            await _next.Invoke(context);

        }
    }
}
