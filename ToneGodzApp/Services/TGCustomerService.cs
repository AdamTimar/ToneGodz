
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

        public async Task<CustomerEntity> GetCustomerByEmailAndProductId(string email, int productId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email && c.ProductId == productId);
        }

        public async Task GetCustomersFromStripe()
        {
            var stripeCustomersAndPrices = await _stripeService.GetCustomers();
            foreach (var stripeCustomerAndPrice in stripeCustomersAndPrices)
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.StripePriceId == stripeCustomerAndPrice.Item2);
                if (product == null)
                {
                    _logger.LogWarning($"Product with Stripe Price ID {stripeCustomerAndPrice.Item2} not found in the database. Skipping customer {stripeCustomerAndPrice.Item1.Email}.");
                    continue;
                }
                _logger.LogInformation($"Adding customer with email {stripeCustomerAndPrice.Item1.Email} for product {product.Id}");

                await AddCustomerIfNotExistsAsync(new CustomerEntity { Email = stripeCustomerAndPrice.Item1.Email, ProductId = product.Id });

            }



            // foreach (var c in _context.Customers)
            // {
            //     if (c.Email != "flemming@sweetsilencestudios.com" && c.Email != "baracx@gmail.com"
            //        && c.Email != "antonioguitars@gmail.com" && c.Email != "carl@10fold.dk"
            //        && c.Email != "nicolasboriew@gmail.com" && c.Email != "tamastar2099@hotmail.com"
            //        && c.Email != "leon.lundqvist06@gmail.com" && c.Email != "joebarresi@mac.com"
            //        && c.Email != "elekesizsak@gmail.com" && c.Email != "timaradam19@gmail.com"
            //        && c.Email != "kor@milliomosegyetem.com" && c.Email != "unai@cowboymedia.agency")
            //     {
            //         var customer = stripeCustomers.FirstOrDefault(cStripe => cStripe.Email == c.Email);
            //         if (customer == null)
            //         {
            //             _context.Entry(c).State = EntityState.Deleted;
            //         }
            //     }
            // }

            // try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (Exception ex)
            // {
            //     _logger.LogError(ex.Message);
            // }
        }

        private async Task AddCustomerIfNotExistsAsync(CustomerEntity customer)
        {
            var exists = await _context.Customers
                .AsNoTracking()
                .AnyAsync(c => c.Email == customer.Email && c.ProductId == customer.ProductId);

            if (!exists)
            {
                await _context.Customers.AddAsync(customer);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            else
            {
                Console.WriteLine($"Customer with email {customer.Email} already exists.");
            }
        }
    }
}
