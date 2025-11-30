namespace Infraestrutucture.Repository;

using Domain;
using Domain.Interface;
using Domain.Entities;
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

        if(pedido == null)
        {
            throw new Exception("Pedido não pode ser nulo");
        }

        if(pedido.Id != Guid.Empty)
        {
            throw new Exception("Pedido já possui ID definido");
        }

        pedido.DefinirId();
        dataBasePedido.CadastrarPedido(pedido);
    }


    public void FinalizarPedido(Pedido pedido)
    {
        if(pedido == null)
        {
            throw new Exception("Pedido não pode ser nulo");
        }

        Pedido pedidoExistente = BuscarPedido(pedido.Id);
        
        if(pedidoExistente == null)
        {
            throw new Exception("Pedido não encontrado");
        }

        pedidoExistente.FinalizarPedido();
    }


    public void ExcluirPedido(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException("ID inválido");
        }

        dataBasePedido.ExcluirPedido(id);
    }


    public List<Pedido> ListarPedidos()
    {
        List<Pedido> pedidos = dataBasePedido.ListarPedidos();

        return pedidos;
    }


    public Pedido BuscarPedido(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException("ID inválido");
        }

        return dataBasePedido.BuscarPedido(id);
    }


    public void AlterarEndereco(Endereco endereco, Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException("ID inválido");
        }

        Pedido pedido = BuscarPedido(id);

        pedido.AlterarEndereco(endereco);
    }

}