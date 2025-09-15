using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Data.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(u => u.Email)
               .HasMaxLength(100)
               .IsRequired();

        builder.HasIndex(u => u.Email)
               .IsUnique();

        builder.Property(u => u.Password)
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(u => u.Role)
               .HasMaxLength(20)
               .IsRequired();

        builder.HasMany(u => u.Addresses)
               .WithOne(a => a.User!)
               .HasForeignKey(a => a.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Orders)
               .WithOne(o => o.User!)
               .HasForeignKey(o => o.UserId);
    }
}