using Invoices.Management.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Invoices.Management.Database
{
    public class InvoicesManagementDbContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Client> Clients { get; set; }

        public InvoicesManagementDbContext(DbContextOptions<InvoicesManagementDbContext> options)
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
