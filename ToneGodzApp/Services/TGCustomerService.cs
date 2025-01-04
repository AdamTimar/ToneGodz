
using Microsoft.EntityFrameworkCore;
using ToneGodzApp.Data;
using ToneGodzApp.Data.Models;

namespace ToneGodzApp.Services
{
    public class TGCustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TGCustomerService> _logger;
        private readonly StripeService _stripeService;

        public TGCustomerService(AppDbContext context, ILogger<TGCustomerService> logger, StripeService stripeService)
        {
            _context = context;
            _logger = logger;
            _stripeService = stripeService;
        }
        public async Task GetCustomersFromStripe()
        {
            var stripeCustomers = await _stripeService.GetCustomers();
            foreach (var stripeCustomer in stripeCustomers)
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == stripeCustomer.Email);
                if (customer == null)
                {
                    _context.Customers.Add(new CustomerEntity { Email = stripeCustomer.Email });
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            _context.Customers.Add(new CustomerEntity { Email = "flemming@sweetsilencestudios.com" });
            _context.Customers.Add(new CustomerEntity { Email = "baracx@gmail.com" });
            _context.Customers.Add(new CustomerEntity { Email = "antonioguitars@gmail.com" });
            _context.Customers.Add(new CustomerEntity { Email = "carl@10fold.dk" });
            _context.Customers.Add(new CustomerEntity { Email = "nicolasboriew@gmail.com" });
            _context.Customers.Add(new CustomerEntity { Email = "tamastar2099@hotmail.com" });
            _context.Customers.Add(new CustomerEntity { Email = "leon.lundqvist06@gmail.com" });
            _context.Customers.Add(new CustomerEntity { Email = "joebarresi@mac.com" });
            _context.Customers.Add(new CustomerEntity { Email = "elekesizsak@gmail.com" });
            _context.Customers.Add(new CustomerEntity { Email = "timaradam19@gmail.com" });

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            foreach (var c in _context.Customers)
            {
                if (c.Email != "flemming@sweetsilencestudios.com" && c.Email != "baracx@gmail.com"
                   && c.Email != "antonioguitars@gmail.com" && c.Email != "carl@10fold.dk"
                   && c.Email != "nicolasboriew@gmail.com" && c.Email != "tamastar2099@hotmail.com"
                   && c.Email != "leon.lundqvist06@gmail.com" && c.Email != "joebarresi@mac.com"
                   && c.Email != "elekesizsak@gmail.com" && c.Email != "timaradam19@gmail.com")
                {
                    var customer = stripeCustomers.FirstOrDefault(cStripe => cStripe.Email == c.Email);
                    if (customer == null)
                    {
                        _context.Entry(c).State = EntityState.Deleted;
                    }
                }
            }

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
