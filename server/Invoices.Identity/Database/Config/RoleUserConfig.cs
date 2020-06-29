using Invoices.Identity.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoices.Identity.Database.Config
{
    public class RoleUserConfig : IEntityTypeConfiguration<RoleUser>
    {
        public void Configure(EntityTypeBuilder<RoleUser> builder)
        {
            builder
                .HasKey(ru => new { ru.RoleId, ru.UserId });

            builder
                .HasOne(ru => ru.Role)
                .WithMany(r => r.RoleUsers)
                .HasForeignKey(ru => ru.RoleId);

            builder
                .HasOne(ru => ru.User)
                .WithMany(u => u.RoleUsers)
                .HasForeignKey(ru => ru.UserId);
        }
    }
}
