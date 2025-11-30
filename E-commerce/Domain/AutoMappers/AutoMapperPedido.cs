using AutoMapper;
using Domain.DTOs;
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
