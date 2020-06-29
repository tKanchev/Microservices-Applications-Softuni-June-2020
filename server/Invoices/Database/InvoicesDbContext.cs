using Invoices.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Invoices.Database
{
    public class InvoicesDbContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public InvoicesDbContext(DbContextOptions<InvoicesDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
