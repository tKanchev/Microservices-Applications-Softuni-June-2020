using Invoices.Identity.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Invoices.Identity.Database
{
    public class InvoicesIdentityDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<RoleUser> RoleUsers { get; set; }

        public InvoicesIdentityDbContext(DbContextOptions<InvoicesIdentityDbContext> options)
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
