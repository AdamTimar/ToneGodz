
namespace ToneGodzApp.Services
{
    public interface IUserService
    {
        public Task<bool> UserHasAccess(string email);
    }
}