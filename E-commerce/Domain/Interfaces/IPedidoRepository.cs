namespace Domain.Interface;
using Domain.Entities;

public interface IPedidoRepository
{
    public void CriarPedido(Pedido pedido);

    public void FinalizarPedido(Pedido pedido);

    public void ExcluirPedido(Guid id);
    
    public List<Pedido> ListarPedidos();

    public Pedido BuscarPedido(Guid id);
    
    public void AlterarEndereco(Endereco endereco, Guid id);

}
