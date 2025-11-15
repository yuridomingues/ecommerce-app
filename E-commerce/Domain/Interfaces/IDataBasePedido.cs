namespace Domain.Interface;

public interface IDataBasePedido
{

    public void CadastrarPedido(Pedido pedido);

    public void ExcluirPedido(int id);

    public List<Pedido> ListarPedidos();

    public Pedido BuscarPedido(int id);

    public void AlterarEndereco(Pedido pedidoParaAlterar, Endereco novoEnderco);

}
