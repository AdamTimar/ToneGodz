using Microsoft.AspNetCore.Identity;
using Stripe;
using Stripe.Checkout;
using ToneGodzApp.Data;
using ToneGodzApp.Data.Models;

namespace ToneGodzApp.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly StripeService _stripeService;
        private readonly AppDbContext _context;
        private readonly SessionService _sessionService;
        private readonly PaymentIntentService _paymentIntentService;
        private readonly UserManager<UserEntity> _userManager;
        private readonly ILogger<PaymentService> _logger;
        public PaymentService(AppDbContext context, StripeService stripeService, UserManager<UserEntity> userManager, ILogger<PaymentService> logger)
        {
            _context = context;
            _stripeService = stripeService;
            _sessionService = new SessionService(_stripeService.GetClient());
            _paymentIntentService = new PaymentIntentService(_stripeService.GetClient());
            _userManager = userManager;
            _logger = logger;
        }
        public async Task AddPayment(Session session, string email)
        {
            var sessionDetails = _sessionService.Get(session.Id, new SessionGetOptions
            {
                Expand = new List<string> { "line_items" }
            });

            //var user = await _userManager.FindByEmailAsync(email);

            var payment = await _paymentIntentService.GetAsync(session.PaymentIntentId);

            await _context.Payments.AddAsync(new PaymentEntity { Amount = sessionDetails.AmountTotal.Value / 100, Currency = sessionDetails.Currency, PaymentIntentId = sessionDetails.PaymentIntentId, SessionId = session.Id, Email = email, Date = payment.Created });

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}