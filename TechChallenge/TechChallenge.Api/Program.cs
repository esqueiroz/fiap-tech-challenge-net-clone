using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Prometheus;
using System.Text.Json.Serialization;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infrastructure.Repositories;
using TechChallenge.UseCase.ContatoUseCase.Adicionar;
using TechChallenge.UseCase.ContatoUseCase.Alterar;
using TechChallenge.UseCase.ContatoUseCase.Listar;
using TechChallenge.UseCase.ContatoUseCase.Obter;
using TechChallenge.UseCase.ContatoUseCase.Remover;
using TechChallenge.UseCase.Interfaces;
using TechChallenge.UseCase.RegionalUseCase.Adicionar;
using TechChallenge.UseCase.RegionalUseCase.Alterar;
using TechChallenge.UseCase.RegionalUseCase.Alterar.Validators;
using TechChallenge.UseCase.RegionalUseCase.Listar;
using TechChallenge.UseCase.RegionalUseCase.Obter;
using TechChallenge.UseCase.RegionalUseCase.Remover;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
const string serviceName = "TechChallenge";

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.AddOpenTelemetry(options =>
{
    options
        .SetResourceBuilder(
            ResourceBuilder.CreateDefault()
                .AddService(serviceName))
        .AddConsoleExporter();
});

builder.Services.AddOpenTelemetry()
      .ConfigureResource(resource => resource.AddService(serviceName))
      .WithTracing(tracing => tracing
          .AddAspNetCoreInstrumentation()
          .AddConsoleExporter())
      .WithMetrics(metrics => metrics
          .AddAspNetCoreInstrumentation()
          .AddConsoleExporter());

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("ConnectionString"));
}, ServiceLifetime.Scoped);

builder.Services.AddScoped<IRegionalRepository, RegionalRepository>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();

builder.Services.AddScoped<IAdicionarRegionalUseCase, AdicionarRegionalUseCase>();
builder.Services.AddScoped<IValidator<AdicionarRegionalDto>, AdicionarRegionalValidator>();

builder.Services.AddScoped<IAlterarRegionalUseCase, AlterarRegionalUseCase>();
builder.Services.AddScoped<IValidator<AlterarRegionalDto>, AlterarRegionalValidator>();

builder.Services.AddScoped<IObterRegionalUseCase, ObterRegionalUseCase>();

builder.Services.AddScoped<IListarRegionalUseCase, ListarRegionalUseCase>();

builder.Services.AddScoped<IRemoverRegionalUseCase, RemoverRegionalUseCase>();


builder.Services.AddScoped<IAdicionarContatoUseCase, AdicionarContatoUseCase>();
builder.Services.AddScoped<IValidator<AdicionarContatoDto>, AdicionarContatoValidator>();

builder.Services.AddScoped<IAlterarContatoUseCase, AlterarContatoUseCase>();
builder.Services.AddScoped<IValidator<AlterarContatoDto>, AlterarContatoValidator>();

builder.Services.AddScoped<IObterContatoUseCase, ObterContatoUseCase>();

builder.Services.AddScoped<IListarContatoUseCase, ListarContatosUseCase>();

builder.Services.AddScoped<IRemoverContatoUseCase, RemoverContatoUseCase>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.MapMetrics();

app.Run();

public partial class Program { };
