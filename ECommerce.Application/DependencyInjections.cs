using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace ECommerce.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
