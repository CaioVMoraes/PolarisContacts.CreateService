using Microsoft.Extensions.DependencyInjection;
using PolarisContacts.CreateService.Application.Interfaces.Repositories;
using PolarisContacts.Domain.Settings;
using PolarisContacts.CreateService.Infrastructure.Repositories;
using PolarisContacts.DatabaseConnection;

namespace PolarisContacts.CreateService.CrossCutting.DependencyInjection.Extensions.AddInfrastructureLayer;

public static partial class AddInfrastructureLayerExtensions
{
    public static IServiceCollection AddSettings(this IServiceCollection services) =>
        services.AddBindedSettings<DbSettings>();

    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddTransient<IUsuarioRepository, UsuarioRepository>()
                .AddTransient<IContatoRepository, ContatoRepository>()
                .AddTransient<ITelefoneRepository, TelefoneRepository>()
                .AddTransient<ICelularRepository, CelularRepository>()
                .AddTransient<IEmailRepository, EmailRepository>()
                .AddTransient<IEnderecoRepository, EnderecoRepository>()
                .AddTransient<IDatabaseConnection, PolarisContacts.DatabaseConnection.DatabaseConnection>();

    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services
            .AddSettings()
            .AddRepositories();
}