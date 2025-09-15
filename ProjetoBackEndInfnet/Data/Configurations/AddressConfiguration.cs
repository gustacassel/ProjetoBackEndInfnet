using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Data.Configurations;

public sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Street)
               .HasMaxLength(40)
               .IsRequired();

        builder.Property(a => a.Number)
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(a => a.Neighborhood)
               .HasMaxLength(30)
               .IsRequired();

        builder.Property(a => a.City)
               .HasMaxLength(30)
               .IsRequired();

        builder.Property(a => a.State)
               .HasMaxLength(2)
               .IsRequired();

        builder.Property(a => a.ZipCode)
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(a => a.Complement)
               .HasMaxLength(15);
    }
}