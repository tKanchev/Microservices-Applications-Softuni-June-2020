using Invoices.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoices.Data.Configurations
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder
                .Property(i => i.Amount)
                .HasColumnType("decimal(18,4)");

            builder
                .Property(i => i.Number)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(i => i.User)
                .WithMany(u => u.Invoices)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
