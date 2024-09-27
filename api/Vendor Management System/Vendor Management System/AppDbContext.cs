using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Vendor_Management_System.Models;
namespace Vendor_Management_System
{
    public class AppDbContext : DbContext
    {
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<InvoiceView> InvoiceView { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
        }
        public AppDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }
    }
}
