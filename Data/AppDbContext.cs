using CustomerBalancePlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerBalancePlatform.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.CurrentBalance)
                .HasColumnType("decimal(18,2)");  // Example precision and scale

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");  // Example precision and scale

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Transactions)
                .WithOne(t => t.Customer)
                .HasForeignKey(t => t.CustomerId);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Type)
                .HasConversion<int>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
