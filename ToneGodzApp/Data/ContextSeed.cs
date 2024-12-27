using Microsoft.AspNetCore.Identity;
using ToneGodzApp.Data.Models;

namespace ToneGodzApp.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("User"));
        }

        public static async Task SeedAdminAsync(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var adminUser = new UserEntity
            {
                UserName = "elekesizsak@gmail.com",
                Email = "elekesizsak@gmail.com",
                EmailConfirmed = true,
                TermsOfUseAccepted = true,
            };
            if (userManager.Users.All(u => u.Id != adminUser.Id))
            {
                var user = await userManager.FindByEmailAsync(adminUser.Email);
                if (user == null)
                {
                    var result = await userManager.CreateAsync(adminUser, configuration["AdminPassword"]);
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }

            }
        }
    }
}