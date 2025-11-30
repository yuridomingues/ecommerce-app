namespace Domain.Interface;
using Domain.Entities;

public interface IDataBasePedido
{

    public void CadastrarPedido(Pedido pedido);

    public void ExcluirPedido(Guid id);

    public List<Pedido> ListarPedidos();

    public Pedido BuscarPedido(Guid id);

    public void AlterarEndereco(Pedido pedidoParaAlterar, Endereco novoEnderco);

}
