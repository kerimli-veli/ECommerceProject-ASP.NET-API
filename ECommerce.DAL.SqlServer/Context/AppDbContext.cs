using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DAL.SqlServer.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customers> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
}
