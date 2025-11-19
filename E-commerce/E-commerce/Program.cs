using Application;
using Domain;
using Domain.Interface;
using Infraestrutucture.Repository;
using Infraestrutucture.DataBasePedido;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Configuração do AutoMapper
builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<Domain.AutoMappers.AutoMapperPedido>();
    cfg.AddProfile<Domain.AutoMappers.AutoMapperEndereco>();
});

builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddSingleton<IDataBasePedido, DataBasePedido>(); 


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
