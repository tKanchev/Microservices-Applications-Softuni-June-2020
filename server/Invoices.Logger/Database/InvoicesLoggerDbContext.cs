using Invoices.Logger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Invoices.Logger.Database
{
    public class InvoicesLoggerDbContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }

        public InvoicesLoggerDbContext(DbContextOptions<InvoicesLoggerDbContext> options)
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
