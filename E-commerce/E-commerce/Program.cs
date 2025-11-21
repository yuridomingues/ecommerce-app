using Application.ClienteService;
using Application.Interfaces;
using Application.Service;
using Domain.Interfaces;
using Infraestrutucture.ClienteRepository;
using Infraestrutucture.DataBaseCliente;
using Application.Mappings;
using Microsoft.Extensions.DependencyInjection;
using Application.EnderecoMappings;
using Application.EnderecoService;
using Infraestrutucture.EnderecoRepository;
using Application.EnderecoInterfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddSingleton<IClienteDataBase, ClienteDataBase>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IValidacoesService, ValidacoesClienteService>();
builder.Services.AddAutoMapper(cfg => { }, typeof(ClienteProfile).Assembly);
builder.Services.AddAutoMapper(cfg => { }, typeof(EnderecoProfile).Assembly);

builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IEnderecoValidacoes, EnderecoValidacoes>();






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
