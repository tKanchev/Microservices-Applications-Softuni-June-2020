using Invoices.Identity.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoices.Identity.Database.Config
{
    class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .HasAlternateKey(r => r.Name);

            builder
                .Property(r => r.Name)
                .IsRequired();
        }
    }
}
