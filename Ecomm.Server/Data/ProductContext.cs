using Microsoft.EntityFrameworkCore;
using Ecomm.Server.Models;

namespace Ecomm.Server.Data
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Table-Per-Hierarchy for User
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<AdminUser>("Admin")
                .HasValue<CustomerUser>("Customer");

            // Configure Table-Per-Hierarchy for Payment
            modelBuilder.Entity<Payment>()
                .HasDiscriminator<string>("PaymentType")
                .HasValue<PayPalPayment>("PayPal")
                .HasValue<CreditCardPayment>("CreditCard");
        }
    }
}
