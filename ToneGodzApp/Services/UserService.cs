
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using ToneGodzApp.Data.Models;

namespace ToneGodzApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly StripeService _stripeService;
        private readonly IMemoryCache _cache;
        public UserService(UserManager<UserEntity> userManager, StripeService stripeService)
        {
            _userManager = userManager;
            _stripeService = stripeService;
        }

        public async Task<bool> UserHasAccess(string email)
        {
            var user = _userManager.FindByEmailAsync(email);
            string cacheKey = $"UserHasAccess-{user.Id}";
            if (!_cache.TryGetValue(cacheKey, out bool hasAccess))
            {
                if (user == null)
                    return false;

                var paymentIntent = await _stripeService.GetPaymentIntentByEmail(email);

                if (paymentIntent != null)
                {
                    _cache.Set(cacheKey, true, TimeSpan.FromDays(1));
                }
            }

            return hasAccess;
        }
    }
}