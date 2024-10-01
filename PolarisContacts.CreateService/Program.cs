using PolarisContacts.CreateService.CrossCutting.DependencyInjection;
using Prometheus;
using System.Diagnostics;

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

// Adiciona o middleware do Prometheus para métricas
app.UseHttpMetrics();

// Métricas personalizadas
var requestCounter = Metrics.CreateCounter("myapp_http_requests_total", "Total number of HTTP requests received");
var responseLatency = Metrics.CreateHistogram("myapp_http_response_latency_seconds", "HTTP response latency in seconds");

// Métricas de uso de CPU e memória
var cpuUsageGauge = Metrics.CreateGauge("myapp_cpu_usage_total", "Total CPU usage of the application");
var memoryUsageGauge = Metrics.CreateGauge("myapp_memory_usage_bytes", "Total memory usage of the application in bytes");

// Atualizar métricas de CPU e memória a cada requisição
var process = Process.GetCurrentProcess();

app.Use(async (context, next) =>
{
    // Incrementar o contador de requisições
    requestCounter.Inc();

    // Iniciar a medição de latência
    var stopwatch = Stopwatch.StartNew();

    // Executar a próxima parte do pipeline
    await next.Invoke();

    // Parar a medição de latência
    stopwatch.Stop();
    responseLatency.Observe(stopwatch.Elapsed.TotalSeconds);

    // Atualizar métricas de uso de CPU e memória
    cpuUsageGauge.Set(process.TotalProcessorTime.TotalMilliseconds / Environment.ProcessorCount);
    memoryUsageGauge.Set(process.WorkingSet64);
});

app.MapMetrics(); // Rota para as métricas do Prometheus

// Mapeia os controladores
app.MapControllers();

app.Run();

public partial class Program { }
