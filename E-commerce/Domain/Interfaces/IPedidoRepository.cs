namespace Domain.Interface;
using Domain.Entities;

public interface IPedidoRepository
{
    public void CriarPedido(Carrinho carrinho, Endereco endereco);

    public void FinalizarPedido(Pedido pedido);

    public void ExcluirPedido(Guid id);
    
    public List<Pedido> ListarPedidos();

    public Pedido BuscarPedido(Guid id);
    
    public void AlterarEndereco(Endereco endereco, Guid id);

}
