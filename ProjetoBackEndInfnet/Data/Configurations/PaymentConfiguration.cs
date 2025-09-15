using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Data.Configurations;

public sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.TotalAmount)
               .IsRequired();

        builder.Property(p => p.PaymentMethod)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(p => p.PaymentDate)
               .IsRequired();

        builder.HasOne(p => p.Order)
               .WithOne(o => o.Payment)
               .HasForeignKey<Payment>(p => p.OrderId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}