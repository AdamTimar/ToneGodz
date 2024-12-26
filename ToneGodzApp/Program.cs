using System.Configuration;
using InertiaCore;
using InertiaCore.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToneGodzApp.Data;
using ToneGodzApp.Data.Models;
using ToneGodzApp.Middlewares;
using ToneGodzApp.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddInertia();

builder.Services.AddViteHelper(options =>
{
    options.PublicDirectory = "wwwroot";
    options.BuildDirectory = "build";
    options.HotFile = "hot";
    options.ManifestFilename = "manifest.json";
});
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
    options.Cookie.IsEssential = true; // Cookie is essential for GDPR compliance
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddIdentity<UserEntity, IdentityRole>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.SignIn.RequireConfirmedAccount = true;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<StripeService>(provider => new StripeService(builder.Configuration["Stripe:SecretKey"]));
builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();
builder.Services.AddHostedService<HostedCustomerService>();

var vimeoToken = builder.Configuration["Vimeo:Token"];
builder.Services.AddHttpClient("Vimeo", client =>
            {
                client.BaseAddress = new Uri("https://api.vimeo.com/");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {vimeoToken}");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

builder.Services.ConfigureApplicationCookie(o =>
            {
                o.LoginPath = "/Account/Login";
                o.ExpireTimeSpan = TimeSpan.FromDays(5);
                o.SlidingExpiration = true;
                o.AccessDeniedPath = "/Account/AccessDenied";
            });

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true; // Ensures session cookie is HTTP-only
    options.Cookie.IsEssential = true; // Makes the session cookie essential for the app to function
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Set the session timeout duration
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("HasAccess", policy =>
    {
        policy.RequireAssertion(async context =>
        {
            // You can get the service provider via HttpContext to resolve the logger
            var httpContext = context.Resource as HttpContext;
            if (httpContext == null)
            {
                return false;
            }

            // Resolve the logger from the HttpContext
            var logger = httpContext.RequestServices.GetRequiredService<ILoggerFactory>()
                                                   .CreateLogger("HasAccessPolicy");
            // Log the start of the process
            // Access the UserManager to get the user
            var userManager = httpContext.RequestServices.GetService<UserManager<UserEntity>>();

            if (userManager == null)
            {
                logger.LogError("UserManager could not be resolved.");
                return false;
            }

            var user = await userManager.GetUserAsync(context.User);

            if (user == null)
            {
                logger.LogWarning("User is null or not authenticated.");
                return false;
            }

            var dbContext = httpContext.RequestServices.GetRequiredService<AppDbContext>();

            var result = await dbContext.Customers.FirstOrDefaultAsync(x => x.Email == user.Email) != null;
            if (!result)
            {
                // Capture the current request URL
                var requestedUrl = httpContext.Request.Path + httpContext.Request.QueryString;

                // Store the original requested URL in the session
                httpContext.Session.SetString("RedirectFromUrl", requestedUrl);
            }

            return result;
        });
    });
});


builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
                o.TokenLifespan = TimeSpan.FromHours(3));
var app = builder.Build();

app.UseSession();
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    // You can now use userManager and roleManager for tasks like seeding users or roles
    await ContextSeed.SeedRolesAsync(userManager, roleManager);
    await ContextSeed.SeedAdminAsync(userManager, roleManager, builder.Configuration);
}

app.UseInertia();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    // Retrieve userId from session (example)
    var userName = context.User?.Identity?.IsAuthenticated == true
       ? context.User.Identity.Name
       : null;

    // Share data with InertiaJS globally

    if (userName != null)
    {
        var userManager = context.RequestServices.GetRequiredService<UserManager<UserEntity>>();
        var user = await userManager.FindByEmailAsync(userName);
        if (user != null)
        {
            // Or using a Dictionary (alternative)
            Inertia.Share(new Dictionary<string, object?>
            {
                ["auth"] = new
                {
                    Id = user.Id,
                    Email = user.Email
                }
            });
        }
    }

    // Call the next middleware in the pipeline
    await next();
});

//app.UseMiddleware<InertiaUserMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

// Change this to app.cshtml for Inertia
app.MapFallbackToFile("index.html");

app.Run();


