namespace Infraestrutucture.Repository;

using Domain;
using Domain.Interface;
using Infraestrutucture.DataBasePedido;


public class PedidoRepository : IPedidoRepository
{

    private IDataBasePedido dataBasePedido;

    private static int IdAtual = 1;

    public PedidoRepository(IDataBasePedido databasePedido)
    {
        this.dataBasePedido = databasePedido;
    }


    public void CriarPedido(Pedido pedido)
    {
        pedido.DefinirId(IdAtual);
        IdAtual++;
        dataBasePedido.CadastrarPedido(pedido);
    }


    public void FinalizarPedido(Pedido pedido)
    {
        Pedido pedidoExistente = BuscarPedido(pedido.Id);
        pedidoExistente.FinalizarPedido();
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


    public void AlterarEndereco(Endereco endereco, int id)
    {
        Pedido pedido = BuscarPedido(id);

        pedido.AlterarEndereco(endereco);
    }

}