using Invoices.Identity.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoices.Identity.Database.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasAlternateKey(u => u.Email);

            builder
                .HasAlternateKey(u => u.NationalIdentityNumber);

            builder.Property(u => u.NationalIdentityNumber)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Name)
                .IsRequired();

            builder.Property(u => u.PasswordSalt)
                .IsRequired();

            builder.Property(u => u.PasswordHash)
                .IsRequired();
        }
    }
}
