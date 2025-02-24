
using Stripe;

namespace ToneGodzApp.Services
{
    public class StripeService
    {
        private readonly IStripeClient _client;
        private readonly CustomerService _customerService;
        private readonly PaymentIntentService _paymentIntentService;
        private readonly RefundService _refundService;
        public StripeService(string stripeApiKey)
        {
            _client = new StripeClient(stripeApiKey);
            _customerService = new CustomerService(_client);
            _paymentIntentService = new PaymentIntentService(_client);
            _refundService = new RefundService(_client);
        }

        public IStripeClient GetClient()
        {
            return _client;
        }
        public async Task<List<Customer>> GetCustomers()
        {
            string lastCustomerId = null;
            var customerEmails = new List<Customer>();
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
                if (customers.HasMore)
                {
                    lastCustomerId = customers.ElementAt(customers.Count() - 1).Id;
                }
                else
                {
                    lastCustomerId = null;
                }

                foreach (var customer in customers)
                {
                    if (await GetPaymentIntentByCustomerId(customer.Id) != null)
                    {
                        if (customerEmails.FirstOrDefault(x => x.Email == customer.Email) == null)
                            customerEmails.Add(customer);
                    }
                }
            }
            while (lastCustomerId != null);

            return customerEmails;
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