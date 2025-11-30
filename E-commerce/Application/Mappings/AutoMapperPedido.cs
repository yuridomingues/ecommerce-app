using AutoMapper;
using Application.DTOs;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.AutoMappers;

public class AutoMapperPedido : Profile
{
    public AutoMapperPedido()
    {
        CreateMap<Pedido, Domain.DTOs.PedidoDTO>().ReverseMap();
        CreateMap<Carrinho, Domain.DTOs.PedidoDTO>();
    }
}
