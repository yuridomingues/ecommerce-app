namespace Infraestrutucture.Repository;

using Domain;
using Domain.Interface;
using Infraestrutucture.DataBasePedido;


public class PedidoRepository : IPedidoRepository
{

    private Pedido pedido;

    private IDataBasePedido dataBasePedido;

    private static int IdAtual = 1;

    public PedidoRepository(IDataBasePedido databasePedido, Pedido pedido)
    {
        this.dataBasePedido = databasePedido;
        this.pedido = pedido;
    }


    public void CriarPedido(Pedido pedido)
    {
        pedido.DefinirId(IdAtual);
        IdAtual++;
        dataBasePedido.CadastrarPedido(pedido);
    }


    public void DefinirSubTotal(int id)
    {

        Pedido pedido = BuscarPedido(id);
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


    public List<Pedido> ListarPedidos()
    {
        return dataBasePedido.ListarPedidos();
    }


    public Pedido BuscarPedido(int id)
    {
        return dataBasePedido.BuscarPedido(id);
    }


    public void AlterarEndereco(Endereco endereco, Pedido pedido)
    {
        pedido.AlterarEndereco(endereco);
    }

}