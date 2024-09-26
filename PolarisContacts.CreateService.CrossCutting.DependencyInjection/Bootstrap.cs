using Microsoft.Extensions.DependencyInjection;
using PolarisContacts.CreateService.CrossCutting.DependencyInjection.Extensions.AddApplicationLayer;
using PolarisContacts.CreateService.CrossCutting.DependencyInjection.Extensions.AddInfrastructureLayer;

namespace PolarisContacts.CreateService.CrossCutting.DependencyInjection;

public static class Bootstrap
{
    public static IServiceCollection RegisterServices(this IServiceCollection services) =>
        services
            .AddInfrastructure()
            .AddApplication();
}
