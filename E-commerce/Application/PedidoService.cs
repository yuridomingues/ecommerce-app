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


    public Pedido BuscarPedido(int id)
    {
        return pedidoRepository.BuscarPedido(id);
    }


    public void AlterarEndereco(EnderecoDTO novoEndereco, int id)
    {

        var endereco = mapper.Map<Endereco>(novoEndereco);

        pedidoRepository.AlterarEndereco(endereco, id);
    }


}
