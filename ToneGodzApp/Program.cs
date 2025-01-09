using Hangfire;
using Hangfire.MySql;
using Hangfire.SqlServer;
using InertiaCore;
using InertiaCore.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using ToneGodzApp.Data;
using ToneGodzApp.Data.Models;
using ToneGodzApp.Filters;
using ToneGodzApp.Services;

var builder = WebApplication.CreateBuilder(args);

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
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});

var environment = builder.Environment.EnvironmentName;
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (environment == "Development")
    {
        options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));
    }
    else if (environment == "Production")
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
    else
    {
        throw new Exception($"Unsupported environment: {environment}");
    }
});

builder.Services.AddHangfire(config =>
{
    if (environment == "Development")
    {
        config.UseStorage(
            new MySqlStorage(builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlStorageOptions
                {
                    JobExpirationCheckInterval = TimeSpan.FromHours(1)
                })
            );
        config.UseSerializerSettings(new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
    }
    else if (environment == "Production")
    {
        config.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
        {
            JobExpirationCheckInterval = TimeSpan.FromHours(1),
            InactiveStateExpirationTimeout = TimeSpan.FromDays(1)
        });
        config.UseSerializerSettings(new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
    }
    else
    {
        throw new Exception($"Unsupported environment: {environment}");
    }
});

builder.Services.AddHangfireServer();

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
builder.Services.AddScoped<ICustomerService, TGCustomerService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

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
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("HasAccess", policy =>
    {
        policy.RequireAssertion(async context =>
        {
            var httpContext = context.Resource as HttpContext;
            if (httpContext == null)
            {
                return false;
            }

            var logger = httpContext.RequestServices.GetRequiredService<ILoggerFactory>()
                                                   .CreateLogger("HasAccessPolicy");

            var cache = httpContext.RequestServices.GetRequiredService<IMemoryCache>();

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

            if (cache.TryGetValue($"HasAccess:{user.Id}", out bool cachedHasAccess) && cachedHasAccess)
            {
                return true;
            }

            var dbContext = httpContext.RequestServices.GetRequiredService<AppDbContext>();

            var hasAccess = await dbContext.Customers.AnyAsync(x => x.Email == user.Email);
            if (!hasAccess)
            {
                var requestedUrl = httpContext.Request.Path + httpContext.Request.QueryString;

                httpContext.Session.SetString("RedirectFromUrl", requestedUrl);
            }

            cache.Set($"HasAccess:{user.Id}", hasAccess, TimeSpan.FromHours(1));

            return hasAccess;
        });
    });
});


builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
                o.TokenLifespan = TimeSpan.FromHours(3));

builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowProductionFrontend",
                policy =>
                {
                    policy.WithOrigins("https://zackelekes-001-site1.ltempurl.com",
                    "https://tonegodz.com")  // Add your production domain
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
        });
var app = builder.Build();

app.UseCors("AllowProductionFrontend");

app.UseSession();
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    await ContextSeed.SeedRolesAsync(userManager, roleManager);
    await ContextSeed.SeedAdminAsync(userManager, roleManager, builder.Configuration);
}

app.UseInertia();

if (!app.Environment.IsDevelopment())
{
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
    var userName = context.User?.Identity?.IsAuthenticated == true
       ? context.User.Identity.Name
       : null;

    if (userName != null)
    {
        var userManager = context.RequestServices.GetRequiredService<UserManager<UserEntity>>();
        var user = await userManager.FindByEmailAsync(userName);
        if (user != null)
        {
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

    await next();
});

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    // Authorization: Only allow users who are authenticated and authorized (e.g., "Admin" role)
    Authorization = new[] { new HangfireDashboardAuthorizationFilter() }
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Lifetime.ApplicationStarted.Register(() =>
{
    using var scope = app.Services.CreateScope();
    var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
    recurringJobManager.AddOrUpdate<TGCustomerService>(
    "get-customers-job",
    customerService => customerService.GetCustomersFromStripe(),
     Cron.Daily(5, 0),
    TimeZoneInfo.FindSystemTimeZoneById("America/New_York")
    );
});

app.Run();


