using System.Text;
using System.Text.Json;
using Hangfire;
using InertiaCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Stripe;
using Stripe.Checkout;
using ToneGodzApp.Data;
using ToneGodzApp.Data.Models;
using ToneGodzApp.Models;
using ToneGodzApp.Services;

namespace ToneGodzApp.Controllers;

[Route("cliff-burton-special")]
public class CliffBurtonSpecialController : Controller
{
    private readonly ILogger<CliffBurtonSpecialController> _logger;


    public CliffBurtonSpecialController(ILogger<CliffBurtonSpecialController> logger, AppDbContext context, IEmailSenderService emailSenderService,
     StripeService stripeService, ICustomerService customerService, IConfiguration configuration,
    IBackgroundJobClient backgroundJobClient, IPaymentService paymentService, IMemoryCache cache)
    {
        _logger = logger;
    }

    [HttpGet]
    //[Authorize]
    public async Task<IActionResult> Index()
    {
        return Inertia.Render("CliffBurtonSpecial/Index");
    }
}



