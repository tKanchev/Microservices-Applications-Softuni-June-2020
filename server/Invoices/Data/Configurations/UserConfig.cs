using Invoices.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoices.Data.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.Invoices)
                .WithOne(i => i.User);

            builder
                .HasMany(u => u.Payments)
                .WithOne(i => i.User);

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
