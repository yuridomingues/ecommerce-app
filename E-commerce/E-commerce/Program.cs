using Application.CarrinhoInterfaces;
using Application.CarrinhoService;
using Application.ClienteService;
using Application.Dtos;
using Application.EnderecoInterfaces;
using Application.EnderecoMappings;
using Application.EnderecoService;
using Application.Interfaces;
using Application.Mappings;
using Application.Service;
using Domain.Entities;
using Domain.Interfaces;
using Infraestrutucture.ClienteDataBase;
using Infraestrutucture.ClienteRepository;
using Infraestrutucture.ProdutoRepository;
using Microsoft.Extensions.DependencyInjection;
using Application.ProdutoInterface;
using Application.Services;
using Infraestrutucture.DataBaseCarrinho;
using Infraestrutucture.CarrinhoRepository;
using Application.CarrinhoMappings;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddSingleton<IClienteDataBase, ClienteDataBase>();
builder.Services.AddSingleton<IClienteRepository, ClienteRepository>();
builder.Services.AddSingleton<IClienteService, ClienteService>();
builder.Services.AddSingleton<IValidacoesService, ValidacoesClienteService>();
builder.Services.AddAutoMapper(cfg => { }, typeof(ClienteProfile).Assembly);
builder.Services.AddAutoMapper(cfg => { }, typeof(EnderecoProfile).Assembly);
builder.Services.AddAutoMapper(cfg => { }, typeof(CarrinhoProfile).Assembly);

builder.Services.AddSingleton<IEnderecoService, EnderecoService>();
builder.Services.AddSingleton<IEnderecoValidacoes, EnderecoValidacoes>();
builder.Services.AddSingleton<IProdutoRepository, ProdutoRepository>();
builder.Services.AddSingleton<ICarrinhoService, CarrinhoService>();
builder.Services.AddSingleton<IProdutoService, ProdutoService>();
builder.Services.AddSingleton<IDataBaseCarrinho, DataBaseCarrinho>();
builder.Services.AddSingleton<ICarrinhoRepository, CarrinhoRepository>();
builder.Services.AddSingleton<IValidarCarrinho, ValidarCarrinho>();
















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
