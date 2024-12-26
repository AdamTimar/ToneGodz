using Microsoft.AspNetCore.Identity;
using ToneGodzApp.Data.Models;

namespace ToneGodzApp.Services
{
    public interface IUserService
    {
        public Task<bool> UserHasAccess(string email);
    }
}