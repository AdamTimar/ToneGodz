
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

        public async Task<CustomerEntity> GetCustomerByEmail(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task GetCustomersFromStripe()
        {
            var stripeCustomers = await _stripeService.GetCustomers();
            foreach (var stripeCustomer in stripeCustomers)
            {
                await AddCustomerIfNotExistsAsync(new CustomerEntity { Email = stripeCustomer.Email });
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            var customersToAdd = new[]
            {
                new CustomerEntity { Email = "flemming@sweetsilencestudios.com"  },
                new CustomerEntity { Email = "baracx@gmail.com" },
                new CustomerEntity { Email = "antonioguitars@gmail.com" },
                new CustomerEntity { Email = "carl@10fold.dk"},
                new CustomerEntity { Email = "nicolasboriew@gmail.com" },
                new CustomerEntity { Email = "tamastar2099@hotmail.com" },
                new CustomerEntity { Email = "leon.lundqvist06@gmail.com"  },
                new CustomerEntity { Email = "joebarresi@mac.com"},
                new CustomerEntity { Email = "elekesizsak@gmail.com" },
                new CustomerEntity { Email = "timaradam19@gmail.com" },
                new CustomerEntity { Email = "kor@milliomosegyetem.com" },
            };

            foreach (var customer in customersToAdd)
            {
                await AddCustomerIfNotExistsAsync(customer);
            }

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
                   && c.Email != "elekesizsak@gmail.com" && c.Email != "timaradam19@gmail.com"
                   && c.Email != "kor@milliomosegyetem.com")
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

        private async Task AddCustomerIfNotExistsAsync(CustomerEntity customer)
        {
            var exists = await _context.Customers
                .AsNoTracking()
                .AnyAsync(c => c.Email == customer.Email);

            if (!exists)
            {
                await _context.Customers.AddAsync(customer);
            }
            else
            {
                Console.WriteLine($"Customer with email {customer.Email} already exists.");
            }
        }
    }
}
