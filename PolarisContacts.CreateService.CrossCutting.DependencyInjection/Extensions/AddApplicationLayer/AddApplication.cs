using Microsoft.Extensions.DependencyInjection;
using PolarisContacts.CreateService.Application.Interfaces.Services;
using PolarisContacts.CreateService.Application.Services;

namespace PolarisContacts.CreateService.CrossCutting.DependencyInjection.Extensions.AddApplicationLayer;

public static partial class AddApplicationLayerExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services) =>
        services.AddScoped<IUsuarioService, UsuarioService>()
                .AddScoped<IContatoService, ContatoService>();

    public static IServiceCollection AddApplication(this IServiceCollection services) => services
        .AddServices();
}
