using Invoices.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoices.Data.Configurations
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder
               .Property(p => p.Amount)
               .HasColumnType("decimal(18,4)");

            builder
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
