namespace Infraestrutucture.Repository;

using Domain;
using Domain.Interface;
using Infraestrutucture.DataBasePedido;


public class PedidoRepository : IPedidoRepository
{

    private IDataBasePedido dataBasePedido;

    public PedidoRepository(IDataBasePedido databasePedido)
    {
        this.dataBasePedido = databasePedido;
    }


    public void CriarPedido(Pedido pedido)
    {
        pedido.DefinirId();
        dataBasePedido.CadastrarPedido(pedido);
    }


    public void FinalizarPedido(Pedido pedido)
    {
        Pedido pedidoExistente = BuscarPedido(pedido.Id);
        pedidoExistente.FinalizarPedido();
    }


    public void ExcluirPedido(Guid id)
    {
        dataBasePedido.ExcluirPedido(id);
    }


    public List<Pedido> ListarPedidos()
    {
        return dataBasePedido.ListarPedidos();
    }


    public Pedido BuscarPedido(Guid id)
    {
        return dataBasePedido.BuscarPedido(id);
    }


    public void AlterarEndereco(Endereco endereco, Guid id)
    {
        Pedido pedido = BuscarPedido(id);

        pedido.AlterarEndereco(endereco);
    }

}