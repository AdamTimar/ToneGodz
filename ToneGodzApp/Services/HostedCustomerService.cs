
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToneGodzApp.Data;
using ToneGodzApp.Data.Models;

namespace ToneGodzApp.Services
{
    public class HostedCustomerService : IHostedService
    {
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<HostedCustomerService> _logger;

        public HostedCustomerService(IServiceScopeFactory scopeFactrory, ILogger<HostedCustomerService> logger)
        {
            _scopeFactory = scopeFactrory;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(
            new TimerCallback(AddCustomersFromStripe),
            null,
            TimeSpan.Zero,
            TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async void AddCustomersFromStripe(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var stripeService = scope.ServiceProvider.GetRequiredService<StripeService>();

                var stripeCustomers = await stripeService.GetCustomers();
                foreach (var stripeCustomer in stripeCustomers)
                {
                    var customer = await context.Customers.FirstOrDefaultAsync(c => c.Email == stripeCustomer.Email);
                    if (customer == null)
                    {
                        context.Customers.Add(new CustomerEntity { Email = stripeCustomer.Email });
                    }
                }

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

                context.Customers.Add(new CustomerEntity { Email = "flemming@sweetsilencestudios.com" });
                context.Customers.Add(new CustomerEntity { Email = "baracx@gmail.com" });
                context.Customers.Add(new CustomerEntity { Email = "antonioguitars@gmail.com" });
                context.Customers.Add(new CustomerEntity { Email = "carl@10fold.dk" });
                context.Customers.Add(new CustomerEntity { Email = "nicolasboriew@gmail.com" });
                context.Customers.Add(new CustomerEntity { Email = "tamastar2099@hotmail.com" });
                context.Customers.Add(new CustomerEntity { Email = "leon.lundqvist06@gmail.com" });
                context.Customers.Add(new CustomerEntity { Email = "joebarresi@mac.com" });
                context.Customers.Add(new CustomerEntity { Email = "elekesizsak@gmail.com" });
                context.Customers.Add(new CustomerEntity { Email = "timaradam19@gmail.com" });

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

                foreach (var c in context.Customers)
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
                            context.Entry(c).State = EntityState.Deleted;
                        }
                    }
                }
                //context.Customers.Add(new CustomerEntity { Email = "flemming@sweetsilencestudios.com" });
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

        }
    }
}
