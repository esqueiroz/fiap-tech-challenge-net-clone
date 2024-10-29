using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infrastructure.Repositories;
using TechChallenge.UseCase.Interfaces;
using TechChallenge.UseCase.RegionalUseCase.Adicionar;
using TechChallenge.UseCase.RegionalUseCase.Alterar;
using TechChallenge.UseCase.RegionalUseCase.Alterar.Validators;
using TechChallenge.UseCase.RegionalUseCase.Listar;
using TechChallenge.UseCase.RegionalUseCase.Obter;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("ConnectionString"));
}, ServiceLifetime.Scoped);

builder.Services.AddScoped<IRegionalRepository, RegionalRepository>();

builder.Services.AddScoped<IAdicionarRegionalUseCase, AdicionarRegionalUseCase>();
builder.Services.AddScoped<IValidator<AdicionarRegionalDto>, AdicionarRegionalValidator>();


builder.Services.AddScoped<IAlterarRegionalUseCase, AlterarRegionalUseCase>();
builder.Services.AddScoped<IValidator<AlterarRegionalDto>, AlterarRegionalValidator>();

builder.Services.AddScoped<IObterRegionalUseCase, ObterRegionalUseCase>();
builder.Services.AddScoped<IValidator<ObterRegionalDto>, ObterRegionalValidator>();

builder.Services.AddScoped<IListarRegionalUseCase, ListarRegionalUseCase>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
