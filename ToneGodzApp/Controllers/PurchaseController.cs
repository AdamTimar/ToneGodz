using System.Text;
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

[Route("[controller]")]
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

    public PurchaseController(ILogger<HomeController> logger, AppDbContext context, IEmailSenderService emailSenderService,
     StripeService stripeService, ICustomerService customerService, IConfiguration configuration,
    IBackgroundJobClient backgroundJobClient, IPaymentService paymentService)
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
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var customer = await _customerService.GetCustomerByEmail(User.Identity.Name);
        if (customer != null)
        {
            return Inertia.Render("Purchase/AlreadyPurchased");
        }

        var newCustomer = await _stripeService.CreateCustomerAsync(User.Identity.Name);

        var price = _configuration["Stripe:Price"];
        try
        {
            Price priceObj = _priceService.Get(price);
            // Create a payment link
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                    {
                        new SessionLineItemOptions
                        {
                            Price = price,

                            Quantity = 1,
                        
                            // Replace with your price I
                        },
                    },
                Mode = "payment",
                SuccessUrl = _configuration["AppUrl"] + "/Purchase/ProcessPayment?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = _configuration["AppUrl"],
                Customer = newCustomer.Id,
                BillingAddressCollection = "required",
                PaymentIntentData = new SessionPaymentIntentDataOptions
                {
                    CaptureMethod = "automatic"
                }
            };


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
    [Route("Success")]
    public async Task<IActionResult> Success()
    {
        return Inertia.Render("Purchase/Success");
    }


    [HttpGet]
    [Route("ProcessPayment")]
    public async Task<IActionResult> Purchase(string session_id)
    {
        var session = await _sessionService.GetAsync(session_id);

        if (session == null)
        {
            return NotFound("Session not found");
        }

        if (await _context.Payments.AnyAsync(p => p.SessionId == session_id))
        {
            return Conflict("Session id already used");
        }

        var customer = await _stripeCustomerService.GetAsync(session.CustomerId);

        await _context.AddAsync(new CustomerEntity { Email = customer.Email });

        _backgroundJobClient.Enqueue(() => _paymentService.AddPayment(session, customer.Email));

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return RedirectToAction("Success");
    }

}



