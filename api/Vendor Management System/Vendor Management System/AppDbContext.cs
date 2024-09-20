using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace Vendor_Management_System
{
    public class AppDbContext : DbContext
    {
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Currency> Currency { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public AppDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }
    }
}
