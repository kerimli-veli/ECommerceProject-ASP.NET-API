using ECommerce.DAL.SqlServer.Context;
using ECommerce.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.DAL.SqlServer;

public static class DependencyInjections
{
    public static IServiceCollection AddSqlServer(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    
        return services;
    }
}
