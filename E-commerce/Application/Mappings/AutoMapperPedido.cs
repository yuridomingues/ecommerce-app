using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace Domain.AutoMappers;

public class AutoMapperPedido : Profile
{
    public AutoMapperPedido()
    {
        CreateMap<Pedido, PedidoDTO>().ReverseMap();
        CreateMap<Carrinho, PedidoDTO>();
    }
}
