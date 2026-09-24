using ToneGodzApp.Data.Models;

namespace ToneGodzApp.Services
{
    public interface ICustomerService
    {
        public Task GetCustomersFromStripe();
        public Task<CustomerEntity> GetCustomerByEmailAndProductId(string email, int productId);
    }
}