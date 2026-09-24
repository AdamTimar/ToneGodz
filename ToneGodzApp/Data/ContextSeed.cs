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

        public static async Task SeedProductsAsync(AppDbContext context, IConfiguration configuration)
        {
            if (!context.Products.Any())
            {
                var products = new List<ProductEntity>
                {
                    new ProductEntity { Name = Data.Enums.ProductType.FLEMMING_RASMUSSEN, Slug = "flemming-rasmussen", StripePriceId = configuration["Stripe:FlemmingRasmussenPriceId"] },
                    new ProductEntity { Name = Data.Enums.ProductType.CLIFFTON_BURTON, Slug = "cliffton-burton-special", StripePriceId = configuration["Stripe:ClifftonBurtonPriceId"] }
                };

                context.Products.AddRange(products);
                await context.SaveChangesAsync();
            }
        }
    }
}