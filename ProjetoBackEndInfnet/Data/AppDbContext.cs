using Microsoft.EntityFrameworkCore;
using ProjetoBackEndInfnet.Data.Configurations;
using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Data;

public sealed class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}