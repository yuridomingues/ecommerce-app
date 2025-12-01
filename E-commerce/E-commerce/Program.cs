using Application.CarrinhoInterfaces;
using Application.Services;
using Application.Interfaces;
using Application.Mappings;
using Application.EnderecoInterfaces;
using Application.EnderecoMappings;
using Application.CarrinhoMappings;
using Application.ProdutoInterface;
using Application.Service;
using Domain.Interfaces;
using Domain.Interface;
using Infraestrutucture.ClienteDataBase;
using Infraestrutucture.ClienteRepository;
using Infraestrutucture.ProdutoRepository;
using Infraestrutucture.DataBaseCarrinho;
using Infraestrutucture.CarrinhoRepository;
using Infraestrutucture.DataBasePedido;
using Infraestrutucture.Repository;
using Application.ClienteService;
using Application.EnderecoService;
using Application.CarrinhoService;
using Application;
using Domain.Services;


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

// Pedido services
builder.Services.AddSingleton<IDataBasePedido, DataBasePedido>();
builder.Services.AddSingleton<IPedidoRepository, PedidoRepository>();
builder.Services.AddSingleton<ICalculadoraFrete, FreteExpresso>();
builder.Services.AddSingleton<PedidoService>();
















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
