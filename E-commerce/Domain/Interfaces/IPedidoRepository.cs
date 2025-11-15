namespace Domain.Interface;

public interface IPedidoRepository
{
    public void CriarPedido(Pedido pedido, int id);

     public void DefinirSubTotal(Pedido pedido);

    public void AdicionarItem(ItemPedido item);

    public void FinalizarPedido(Pedido pedido);

    public void ExcluirPedido(int id);
    
    public void ListarPedidos();

    public void BuscarPedido(int id);
    
    public void AlterarEndereco(Endereco endereco);

}
