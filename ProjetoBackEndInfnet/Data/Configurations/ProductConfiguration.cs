using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Data.Configurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Description)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(p => p.Price)
               .IsRequired();

        builder.Property(p => p.MeasureUnit)
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(p => p.QuantityInStock)
               .IsRequired();

        builder.Property(p => p.Active)
               .IsRequired();
    }
}