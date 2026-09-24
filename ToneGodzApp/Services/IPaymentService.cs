using Stripe.Checkout;

namespace ToneGodzApp.Services
{
    public interface IPaymentService
    {
        public Task AddPayment(Session session, string email, int productId);
    }
}