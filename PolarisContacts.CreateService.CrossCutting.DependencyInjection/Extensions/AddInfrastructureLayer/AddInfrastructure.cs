using Microsoft.Extensions.DependencyInjection;
using PolarisContacts.CreateService.Application.Interfaces.Repositories;
using PolarisContacts.Domain.Settings;
using PolarisContacts.CreateService.Infrastructure.Repositories;
using PolarisContacts.CreateService.Infrastructure.Messaging;
using PolarisContacts.CreateService.Application.Interfaces.Messaging;

namespace PolarisContacts.CreateService.CrossCutting.DependencyInjection.Extensions.AddInfrastructureLayer;

public static partial class AddInfrastructureLayerExtensions
{
    public static IServiceCollection AddSettings(this IServiceCollection services) =>
        services.AddBindedSettings<DbSettings>()
                .AddBindedSettings<PolarisContacts.Domain.Settings.RabbitMQ>();

    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddTransient<IUsuarioRepository, UsuarioRepository>()
                .AddTransient<IContatoRepository, ContatoRepository>()
                .AddTransient<ITelefoneRepository, TelefoneRepository>()
                .AddTransient<ICelularRepository, CelularRepository>()
                .AddTransient<IEmailRepository, EmailRepository>()
                .AddTransient<IEnderecoRepository, EnderecoRepository>()
                .AddTransient<PolarisContacts.DatabaseConnection.IDatabaseConnection, PolarisContacts.DatabaseConnection.DatabaseConnection>()
                .AddTransient<IRabbitMqProducer, RabbitMqProducer>();

    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services
            .AddSettings()
            .AddRepositories();
}