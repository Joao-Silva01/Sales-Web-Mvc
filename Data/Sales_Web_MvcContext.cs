using Microsoft.EntityFrameworkCore;
using Sales_Web_Mvc.Models;

namespace Sales_Web_Mvc.Data
{
    public class Sales_Web_MvcContext : DbContext
    {
        public Sales_Web_MvcContext (DbContextOptions<Sales_Web_MvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecords { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Seller>().ToTable("Seller");
            modelBuilder.Entity<SalesRecord>().ToTable("SalesRecord");

            modelBuilder.Entity<SalesRecord>()
            .HasOne(f => f.Seller)
            .WithMany(p => p.Sales)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
