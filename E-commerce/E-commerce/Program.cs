using Application.ClienteService;
using Application.Interfaces;
using Application.Service;
using Domain.Interfaces;
using Infraestrutucture.ClienteRepository;
using Infraestrutucture.DataBaseCliente;
using Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddSingleton<IDataBase, DataBase>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IValidacoesService, ValidacoesService>();
builder.Services.AddAutoMapper(cfg => { }, typeof(CadastroClienteProfile).Assembly);





builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
