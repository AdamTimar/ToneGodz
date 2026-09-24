
using System.Text.Json;
using Stripe;
using Stripe.Checkout;

namespace ToneGodzApp.Services
{
    public class StripeService
    {
        private readonly IStripeClient _client;
        private readonly CustomerService _customerService;
        private readonly PaymentIntentService _paymentIntentService;
        private readonly RefundService _refundService;
        private readonly SessionService _sessionService;
        private readonly ILogger<StripeService> _logger;

        public StripeService(string stripeApiKey, ILogger<StripeService> logger)
        {
            _client = new StripeClient(stripeApiKey);
            _customerService = new CustomerService(_client);
            _paymentIntentService = new PaymentIntentService(_client);
            _refundService = new RefundService(_client);
            _logger = logger;
            _sessionService = new SessionService(_client);
        }

        public IStripeClient GetClient()
        {
            return _client;
        }
        public async Task<List<(Customer, string)>> GetCustomers()
        {
            string lastCustomerId = null;
            var customerEmailsAndPrices = new List<(Customer, string)>();
            CustomerListOptions options;
            do
            {
                if (lastCustomerId == null)
                {
                    options = new CustomerListOptions
                    {
                        Limit = 100,
                    };
                }
                else
                {
                    options = new CustomerListOptions
                    {
                        Limit = 100,
                        StartingAfter = lastCustomerId
                    };
                }
                var customers = await _customerService.ListAsync(options);
                _logger.LogInformation($"Retrieved {customers.Count()} customers from Stripe.");
                if (customers.HasMore)
                {
                    lastCustomerId = customers.ElementAt(customers.Count() - 1).Id;
                }
                else
                {
                    lastCustomerId = null;
                }
                int count = 0;
                foreach (var customer in customers)
                {

                    count++;
                    _logger.LogInformation($"Processing customer: {count}. Email: {customer.Email}, ID: {customer.Id}");
                    var paymentIntent = await GetPaymentIntentByCustomerId(customer.Id);
                    if (paymentIntent != null)
                    {
                        var sessions = await _sessionService.ListAsync(new SessionListOptions
                        {
                            PaymentIntent = paymentIntent.Id,
                            Expand = new List<string> { "data.line_items" }
                        });

                        var session = sessions.FirstOrDefault();
                        if (session == null)
                        {
                            _logger.LogWarning($"No session found for customer {customer.Email} with payment intent {paymentIntent.Id}. Skipping.");
                            continue;
                        }

                        _logger.LogInformation($"Customer: {customer.Email}, PriceId: {JsonSerializer.Serialize(session.LineItems.Data.FirstOrDefault()?.Price?.Id)}");
                        var priceId = session.LineItems?.Data.FirstOrDefault()?.Price?.Id;

                        //get product from priceId
                        if (customerEmailsAndPrices.FirstOrDefault(x => x.Item1.Id == customer.Id && x.Item2 == priceId) == default)
                            customerEmailsAndPrices.Add((customer, priceId));
                    }
                }
            }
            while (lastCustomerId != null);

            return customerEmailsAndPrices;
        }
        public async Task<PaymentIntent?> GetPaymentIntentByCustomerId(string id)
        {
            var customer = await _customerService.GetAsync(id);

            if (customer == null)
                return null;

            var paymentIntentListoptions = new PaymentIntentListOptions
            {
                Customer = customer.Id,
            };

            var paymentIntents = await _paymentIntentService.ListAsync(paymentIntentListoptions);
            _logger.LogInformation($"Fetched {paymentIntents.Count()} payment intents for customer: {customer.Id}");
            if (paymentIntents.Count() == 0)
                return null;

            foreach (var pi in paymentIntents)
            {
                if (pi.Status == "succeeded")
                {
                    var refundListOptions = new RefundListOptions
                    {
                        PaymentIntent = pi.Id
                    };
                    var refunds = await _refundService.ListAsync(refundListOptions);
                    if (refunds.Count() == 0)
                        return pi;
                }
            }

            return null;
        }

        public async Task<Customer> CreateCustomerAsync(string email)
        {
            var options = new CustomerCreateOptions
            {
                Email = email
            };

            var customer = await _customerService.CreateAsync(options);
            return customer;
        }

    }
}