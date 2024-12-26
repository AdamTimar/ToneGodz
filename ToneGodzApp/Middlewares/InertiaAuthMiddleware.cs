namespace ToneGodzApp.Middlewares
{
    using InertiaCore;
    using InertiaCore.Utils;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using ToneGodzApp.Data.Models;

    public class InertiaAuthMiddleware
    {
        private readonly RequestDelegate _next;
        public InertiaAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {
            // Retrieve userName from the authenticated user (if any)
            if (context.Request.Path.StartsWithSegments("/login") && context.Request.Method == "POST")
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<UserEntity>>();
                var userName = context.User?.Identity?.IsAuthenticated == true
                ? context.User.Identity.Name
                : null;

                if (!string.IsNullOrEmpty(userName))
                {
                    // Retrieve the user using UserManager to get the User ID
                    var user = await userManager.FindByNameAsync(userName);
                    if (user != null)
                    {
                        // Share the authenticated user data with InertiaJS globally
                        Inertia.Share("auth", new
                        {
                            Email = user.Email,   // Share the user's email
                            Id = user.Id          // Share the user's ID
                        });
                    }
                }

                // Call the next middleware in the pipeline
                await _next(context);
            }
        }
    }

}