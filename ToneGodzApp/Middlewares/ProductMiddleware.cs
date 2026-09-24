using Microsoft.EntityFrameworkCore;
using ToneGodzApp.Data;

namespace ToneGodzApp.Middlewares
{
    public class ProductMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProductMiddleware> _logger;

        public ProductMiddleware(
            RequestDelegate next,
            ILogger<ProductMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(
            HttpContext context,
            AppDbContext db)
        {
            var slug = context.Request.RouteValues["slug"]?.ToString();


            if (!string.IsNullOrEmpty(slug))
            {
                var productEntity = await db.Products
                    .FirstOrDefaultAsync(p => p.Slug == slug);

                if (productEntity == null)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    return;
                }

                context.Items["Product"] = productEntity;
            }

            await _next(context);
        }
    }
}
