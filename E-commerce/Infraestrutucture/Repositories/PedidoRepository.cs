namespace Infraestrutucture.Repository;

using Domain;
using Domain.Interface;
using Domain.Entities;
using Infraestrutucture.DataBasePedido;
using Domain.Interfaces;

public class PedidoRepository : IPedidoRepository
{

    private IDataBasePedido dataBasePedido;

    private ICarrinhoRepository carrinhoRepository;

    public PedidoRepository(IDataBasePedido databasePedido, ICarrinhoRepository carrinhoRepository)
    {
        this.dataBasePedido = databasePedido;
        this.carrinhoRepository = carrinhoRepository;
    }


    public void CriarPedido(Carrinho carrinho, Endereco endereco)
    {

        Pedido pedido = new Pedido(carrinho.ClienteId, endereco);
        pedido.DefinirId();

        foreach(var itemCarrinho in carrinho.Item)
        {
            var itemPedido = new ItemPedido(
                itemCarrinho.ProdutoId,
                itemCarrinho.Nome,
                itemCarrinho.Quantidade,
                itemCarrinho.PrecoUnitario
            );
            pedido.Itens.Add(itemPedido);
        }

        pedido.DefinirSubTotal(carrinho.CalcularSubTotal());

        dataBasePedido.CadastrarPedido(pedido);

        carrinho.EsvaziarCarrinho();
        carrinhoRepository.Salvar(carrinho);

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