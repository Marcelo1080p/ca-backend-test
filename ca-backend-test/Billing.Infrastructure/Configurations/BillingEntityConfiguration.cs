using Billing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BillingEntityConfiguration : IEntityTypeConfiguration<BillingEntity>
{
    public void Configure(EntityTypeBuilder<BillingEntity> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.InvoiceNumber).IsRequired();
        builder.Property(b => b.Date).IsRequired();
        builder.Property(b => b.DueDate).IsRequired();
        builder.Property(b => b.Currency).IsRequired();


        builder.HasOne(b => b.Customer)
            .WithMany(c => c.Billings)
            .HasForeignKey(b => b.CustomerId);

        builder.HasMany(b => b.Lines)
            .WithOne(l => l.Billing)
            .HasForeignKey(l => l.BillingId);
    }
}
