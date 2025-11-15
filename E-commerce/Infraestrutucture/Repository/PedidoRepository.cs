namespace Infraestrutucture.Repository;

using Domain;
using Domain.Interface;
using Infraestrutucture.DataBasePedido;


public class PedidoRepository : IPedidoRepository
{
    private static int IdAtual = 1;

    private Pedido pedido;

    private IDataBasePedido dataBasePedido;

    public PedidoRepository(IDataBasePedido databasePedido, Pedido pedido)
    {
        this.dataBasePedido = databasePedido;
        this.pedido = pedido;
    }


    public void CriarPedido(Pedido pedido)
    {
        pedido.DefinirId();
        dataBasePedido.CadastrarPedido(pedido);
    }


    public void DefinirSubTotal(Pedido pedido)
    {
        pedido.DefinirSubTotal();
    }


    public void AdicionarItem(ItemPedido item)
    {
        pedido.AdicionarItem(item);
    }


    public void FinalizarPedido(Pedido pedido)
    {
        pedido.FinalizarPedido(pedido);
    }


    public void ExcluirPedido(int id)
    {
        dataBasePedido.ExcluirPedido(id);
    }


    public void ListarPedidos()
    {
        dataBasePedido.ListarPedidos();
    }


    public void BuscarPedido(int id)
    {
        dataBasePedido.BuscarPedido(id);
    }


    public void AlterarEndereco(Endereco endereco)
    {
        pedido.AlterarEndereco(endereco);
    }

}








//AlterarEndereco()