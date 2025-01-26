using System.Text;
using InertiaCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ToneGodzApp.Data;
using ToneGodzApp.Data.Models;
using ToneGodzApp.Models;
using ToneGodzApp.Services;

namespace ToneGodzApp.Controllers;

[Authorize(Roles = "Admin")]
[Route("[controller]")]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly AppDbContext _context;
    private readonly StripeService _stripeService;
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly UserManager<UserEntity> _userManager;
    private readonly IMemoryCache _cache;
    private readonly IEmailSenderService _emailSenderService;

    public AdminController(ILogger<AdminController> logger, AppDbContext context,
    SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, IMemoryCache cache, IEmailSenderService emailSenderService, StripeService stripeService)
    {
        _logger = logger;
        _context = context;
        _signInManager = signInManager;
        _userManager = userManager;
        _cache = cache;
        _emailSenderService = emailSenderService;
        _stripeService = stripeService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var users = _context.Users.Select(u => new
        {
            Id = u.Id,
            Email = u.Email,
            Confirmed = u.EmailConfirmed,
            HasAccess = _context.Customers.Any(c => c.Email == u.Email),
            PurchaseDate = _context.Payments.Where(p => p.UserId == u.Id).Select(p => ((DateTime?)p.Date).Value.ToString("yyyy-MM-dd")).FirstOrDefault()
        }).ToList();

        return Inertia.Render("Admin/Index", new { users = users });
    }
}

