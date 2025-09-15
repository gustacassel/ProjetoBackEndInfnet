using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Data.Configurations;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.OrderDate)
               .IsRequired();

        builder.Property(o => o.Status)
               .HasMaxLength(20)
               .IsRequired();

        builder.HasOne(o => o.User)
               .WithMany(u => u.Orders)
               .HasForeignKey(o => o.UserId);

        builder.HasOne(o => o.Address)
               .WithMany()
               .HasForeignKey(o => o.AddressId);

        builder.HasMany(o => o.OrderItems)
               .WithOne(oi => oi.Order!)
               .HasForeignKey(oi => oi.OrderId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(o => o.Payment)
               .WithOne(p => p.Order)
               .HasForeignKey<Payment>(p => p.OrderId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}