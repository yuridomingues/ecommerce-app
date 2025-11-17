namespace Domain.Interface;

public interface IPedidoRepository
{
    public void CriarPedido(Pedido pedido);

     public void DefinirSubTotal(int Id);

    public void AdicionarItem(ItemPedido item);

    public void FinalizarPedido(Pedido pedido);

    public void ExcluirPedido(int id);
    
    public List<Pedido> ListarPedidos();

    public Pedido BuscarPedido(int id);
    
    public void AlterarEndereco(Endereco endereco, Pedido pedido);

}
