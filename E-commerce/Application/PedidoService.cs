namespace Application;
using Domain.Interface;
using Domain;

public class PedidoService
{

    private static int IdAtual = 1;
    private readonly IPedidoRepository pedidoRepository;

    public PedidoService(IPedidoRepository pedidoRepository)
    {
        this.pedidoRepository = pedidoRepository;
    }


    public void CriarPedido(Pedido pedido)
    {
        pedidoRepository.CriarPedido(pedido, IdAtual);
        IdAtual++;
    }


    public void DefinirSubTotal(Pedido pedido)
    {
        pedidoRepository.DefinirSubTotal(pedido);
    }

    public void AdicionarItem(ItemPedido item)
    {
        pedidoRepository.AdicionarItem(item);
    }


    public void FinalizarPedido(Pedido pedido)
    {
        DefinirSubTotal(pedido);
        pedidoRepository.FinalizarPedido(pedido);
    }


    public void ExcluirPedido(int id)
    {
        pedidoRepository.ExcluirPedido(id);
    }


    public void ListarPedidos()
    {
        pedidoRepository.ListarPedidos();
    }


    public void BuscarPedido(int id)
    {
        pedidoRepository.BuscarPedido(id);
    }


    public void AlterarEndereco(Endereco endereco)
    {
        pedidoRepository.AlterarEndereco(endereco);
    }


}
