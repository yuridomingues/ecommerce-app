using AutoMapper;
using Domain.DTOs;

namespace Domain.AutoMappers;

public class AutoMapperPedido : Profile
{
    public AutoMapperPedido()
    {
        CreateMap<Pedido, PedidoDTO>().ReverseMap();
    }
}
