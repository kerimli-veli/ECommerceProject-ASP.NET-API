using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DAL.SqlServer.Context;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Employee> Employees { get; set; }

}
