namespace Application;
using Domain.Interface;
using Domain;
using Domain.DTOs;
using AutoMapper;

public class PedidoService
{
    
    private readonly IPedidoRepository pedidoRepository;
    private readonly IMapper mapper;

    public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
    {
        this.pedidoRepository = pedidoRepository;
        this.mapper = mapper;
    }


    public void CriarPedido(PedidoDTO novoPedido)
    {
        var pedido = mapper.Map<Pedido>(novoPedido);

        pedidoRepository.CriarPedido(pedido);
    }


    public void FinalizarPedido(PedidoDTO pedidoFinalizado)
    {

        var pedido = mapper.Map<Pedido>(pedidoFinalizado);

        pedidoRepository.FinalizarPedido(pedido);
    }


    public void ExcluirPedido(PedidoDTO pedidoExcluido)
    {

        var pedido = mapper.Map<Pedido>(pedidoExcluido);

        pedidoRepository.ExcluirPedido(pedidoExcluido.Id);
    }


    public List<PedidoDTO> ListarPedidos()
    {
        var pedidos = pedidoRepository.ListarPedidos();

        return mapper.Map<List<PedidoDTO>>(pedidos);
    }


    public PedidoDTO BuscarPedido(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new Exception("Id inválido");
        }

        var pedido = pedidoRepository.BuscarPedido(id);

        return mapper.Map<PedidoDTO>(pedido); 
    }


    public void AlterarEndereco(EnderecoDTO novoEndereco, Guid id)
    {

        if (id == Guid.Empty)
        {
            throw new Exception("Id inválido");
        }

        var endereco = mapper.Map<Endereco>(novoEndereco);

        pedidoRepository.AlterarEndereco(endereco, id);
    }


}
