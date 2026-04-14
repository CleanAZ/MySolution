using Microsoft.EntityFrameworkCore;
using MySolution.Domain.Orders;
using MySolution.Domain.Clients;
namespace MySolution.Infrastructure;
public class AppDbContext:DbContext
{
     public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<QueMessage> QueMessages => Set<QueMessage>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Client> Clients => Set<Client>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly);
    }
}