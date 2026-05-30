using Microsoft.EntityFrameworkCore;
using SalesInvoiceExtPdf.Models;

namespace SalesInvoiceExtPdf.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<SalesMaster> SalesMaster { get; set; }

        public DbSet<SalesItems> SalesItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesMaster>()
                .HasMany(x => x.Items)
                .WithOne(x => x.SalesMaster)
                .HasForeignKey(x => x.Sid);

            modelBuilder.Entity<SalesItems>()
                .Property(x => x.Amt)
                .HasPrecision(18, 2);

            modelBuilder.Entity<SalesItems>()
                .Property(x => x.Rate)
                .HasPrecision(18, 4);

            modelBuilder.Entity<SalesMaster>()
                .Property(x => x.DiscPrc)
                .HasPrecision(18, 2);

            modelBuilder.Entity<SalesMaster>()
                .Property(x => x.Shipping)
                .HasPrecision(18, 2);
        }
    }
}
