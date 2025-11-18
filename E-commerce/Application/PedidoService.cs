namespace Application;
using Domain.Interface;
using Domain;

public class PedidoService
{
    
    private readonly IPedidoRepository pedidoRepository;

    public PedidoService(IPedidoRepository pedidoRepository)
    {
        this.pedidoRepository = pedidoRepository;
    }


    public void CriarPedido(Pedido pedido)
    {
        pedidoRepository.CriarPedido(pedido);
    }


    public void DefinirSubTotal(int id)
    {
        pedidoRepository.DefinirSubTotal(id);
    }

    public void AdicionarItem(ItemPedido item, Pedido pedido)
    {
        pedidoRepository.AdicionarItem(item, pedido);
    }


    public void FinalizarPedido(int id)
    {
        DefinirSubTotal(id);

        Pedido pedido = BuscarPedido(id);

        pedidoRepository.FinalizarPedido(pedido);
    }


    public void ExcluirPedido(int id)
    {
        pedidoRepository.ExcluirPedido(id);
    }


    public List<Pedido> ListarPedidos()
    {
        return pedidoRepository.ListarPedidos();
    }


    public Pedido BuscarPedido(int id)
    {
        return pedidoRepository.BuscarPedido(id);
    }


    public void AlterarEndereco(Endereco endereco, Pedido pedido)
    {
        pedidoRepository.AlterarEndereco(endereco, pedido);
    }


}
