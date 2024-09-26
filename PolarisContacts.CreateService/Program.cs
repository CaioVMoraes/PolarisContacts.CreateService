using PolarisContacts.CreateService.CrossCutting.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configuração de ambiente
builder.Host.ConfigureAppConfiguration((context, config) =>
{
    var env = context.HostingEnvironment;

    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
});

// Adiciona serviços ao container
builder.Services.RegisterServices();

// Adiciona suporte para controladores e filtros de autenticação
builder.Services.AddControllers(options =>
{
    // Adiciona o filtro globalmente, exceto em ambientes de teste
    //if (!builder.Environment.IsEnvironment("Test"))
    //{
    //    options.Filters.Add(new AuthenticationFilterAttribute());
    //}
});

// Swagger para documentação
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapeia os controladores
app.MapControllers();

app.Run();

public partial class Program { }
