using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToneGodzApp.Data.Models;

namespace ToneGodzApp.Data
{
    public class AppDbContext : IdentityDbContext<UserEntity>
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserEntity>()
                .Ignore(u => u.PhoneNumber);
            builder.Entity<UserEntity>()
                .Ignore(u => u.PhoneNumberConfirmed);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
            }
        }
    }
}