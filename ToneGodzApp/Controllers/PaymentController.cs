using System.Text;
using InertiaCore;
using Microsoft.AspNetCore.Authorization;
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

[AllowAnonymous]
[Route("[controller]")]
public class PaymentController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;
    private readonly StripeService _stripeService;
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly UserManager<UserEntity> _userManager;
    private readonly IMemoryCache _cache;
    private readonly IEmailSenderService _emailSenderService;

    public PaymentController(ILogger<HomeController> logger, AppDbContext context,
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

    // [HttpGet]
    // public async Task<IActionResult> Index()
    // {


    // }


}

