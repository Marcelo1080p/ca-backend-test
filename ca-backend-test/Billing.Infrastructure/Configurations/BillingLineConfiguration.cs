using Billing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BillingLineEntityConfiguration : IEntityTypeConfiguration<BillingLineEntity>
{
    public void Configure(EntityTypeBuilder<BillingLineEntity> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Description).IsRequired();
        builder.Property(l => l.Quantity).IsRequired();
        builder.Property(l => l.UnitPrice).IsRequired();
        builder.Property(l => l.Subtotal).IsRequired();

        builder.HasOne(l => l.Product)
            .WithMany()
            .HasForeignKey(l => l.ProductId);

        builder.HasOne(l => l.Billing)
            .WithMany(b => b.Lines)
            .HasForeignKey(l => l.BillingId);
    }
}
