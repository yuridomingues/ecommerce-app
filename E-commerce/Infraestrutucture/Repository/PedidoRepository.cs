namespace Infraestrutucture.Repository;

using Domain;

using Infraestrutucture.DataBasePedido;


public class PedidoRepository
{
    private static int IdAtual = 1;

    private Pedido pedido;

    private DataBasePedido dataBasePedido;

    public PedidoRepository(DataBasePedido dataBasePedido, Pedido pedido)
    {
        this.dataBasePedido = dataBasePedido;
        this.pedido = pedido;
    }


    public void CriarPedido()
    {
        pedido.DefinirId();
        dataBasePedido.CadastrarPedido(pedido);
    }


    public void DefinirSubTotal()
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


}
