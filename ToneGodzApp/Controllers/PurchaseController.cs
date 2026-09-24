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

[Route("{slug}/[controller]")]
public class PurchaseController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;
    private readonly StripeService _stripeService;
    private readonly IEmailSenderService _emailSenderService;
    private readonly ICustomerService _customerService;
    private readonly PriceService _priceService;
    private readonly SessionService _sessionService;
    private readonly IConfiguration _configuration;
    private readonly CustomerService _stripeCustomerService;
    private readonly IPaymentService _paymentService;
    private readonly IBackgroundJobClient _backgroundJobClient;

    private readonly IMemoryCache _cache;

    public PurchaseController(ILogger<HomeController> logger, AppDbContext context, IEmailSenderService emailSenderService,
     StripeService stripeService, ICustomerService customerService, IConfiguration configuration,
    IBackgroundJobClient backgroundJobClient, IPaymentService paymentService, IMemoryCache cache)
    {
        _logger = logger;
        _context = context;
        _configuration = configuration;
        _emailSenderService = emailSenderService;
        _stripeService = stripeService;
        _customerService = customerService;
        _paymentService = paymentService;
        _priceService = new PriceService(_stripeService.GetClient());
        _sessionService = new SessionService(_stripeService.GetClient());
        _stripeCustomerService = new CustomerService(_stripeService.GetClient());
        _backgroundJobClient = backgroundJobClient;
        _cache = cache;
    }



    [HttpGet("Success")]
    public async Task<IActionResult> Success()
    {
        return Inertia.Render("Purchase/Success");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var product = HttpContext.Items["Product"] as ProductEntity;

        var customer = await _customerService.GetCustomerByEmailAndProductId(User.Identity?.Name, product.Id);

        if (customer != null)
        {
            return Inertia.Render("Purchase/AlreadyPurchased");
        }

        try
        {
            var priceId = product.StripePriceId;

            // Optional: verify that the Stripe price exists
            var priceService = new PriceService(_stripeService.GetClient());
            var price = priceService.Get(priceId);

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
            {
                "card"
            },

                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    Price = priceId,
                    Quantity = 1,
                }
            },

                Mode = "payment",

                SuccessUrl =
                    _configuration["AppUrl"] + "/" + product.Slug +
                    "/Purchase/ProcessPayment?session_id={CHECKOUT_SESSION_ID}",

                CancelUrl = _configuration["AppUrl"],

                BillingAddressCollection = "required",

                PaymentIntentData = new SessionPaymentIntentDataOptions
                {
                    CaptureMethod = "automatic"
                },

                AllowPromotionCodes = true
            };


            var newCustomer =
                await _stripeService.CreateCustomerAsync(User.Identity.Name);

            options.Customer = newCustomer.Id;


            var service = new SessionService(_stripeService.GetClient());
            var session = service.Create(options);

            return Redirect(session.Url);
        }
        catch (StripeException e)
        {
            return BadRequest($"Error generating payment link: {e.Message}");
        }
    }


    [HttpGet]
    [Route("ProcessPayment")]
    public async Task<IActionResult> Purchase(string session_id)
    {
        var session = await _sessionService.GetAsync(session_id, new SessionGetOptions
        {
            Expand = new List<string> { "line_items" },
        });

        if (session == null)
        {
            return NotFound("Session not found");
        }

        if (await _context.Payments.AnyAsync(p => p.SessionId == session_id))
        {
            return Conflict("Session id already used");
        }

        Customer customer;
        if (session.CustomerId != null)
        {
            customer = await _stripeCustomerService.GetAsync(session.CustomerId);
        }
        else
        {
            customer = await _stripeCustomerService.CreateAsync(new CustomerCreateOptions
            {
                Email = session.CustomerDetails?.Email,
            });
        }


        var priceId = session.LineItems.Data.FirstOrDefault()?.Price?.Id;
        var product = await _context.Products.FirstOrDefaultAsync(p => p.StripePriceId == priceId);

        await _context.AddAsync(new CustomerEntity { Email = customer.Email, ProductId = product.Id });

        _backgroundJobClient.Enqueue(() => _paymentService.AddPayment(session, customer.Email, product.Id));

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        if (User.Identity.IsAuthenticated)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            if (user != null)
            {
                var hasAccess = false;
                var hasCliffBurtonSpecialAccess = false;

                switch (product.Slug)
                {
                    case "flemming-rasmussen":
                        hasAccess = true;
                        break;
                }
                switch (product.Slug)
                {
                    case "cliff-burton-special":
                        hasCliffBurtonSpecialAccess = true;
                        break;
                }

                var userData = new
                {
                    Id = user.Id,
                    Email = user.Email,
                    HasAccess = hasAccess,
                    HasCliffBurtonSpecialAccess = hasCliffBurtonSpecialAccess
                };

                HttpContext.Session.SetString("UserData", System.Text.Json.JsonSerializer.Serialize(userData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
                _cache.Set("UserData", userData, TimeSpan.FromHours(1));
            }
        }
        return RedirectToAction("Success", new { slug = product.Slug });
    }
}



