using ECommerce.DAL.SqlServer.Context;
using ECommerce.DAL.SqlServer.UnitOfWork.SqlUnitOfWork;
using ECommerce.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.DAL.SqlServer;

public static class DependencyInjections
{
    public static IServiceCollection AddSqlServerServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<IUnitOfWork , SqlUnitOfWork>(opt =>
        {
            var dbcontext = opt.GetRequiredService<AppDbContext>();
            return new SqlUnitOfWork(connectionString, dbcontext);
        });
        return services;
    }
}
