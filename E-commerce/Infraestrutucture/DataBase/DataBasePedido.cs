using Domain;
using Domain.Interface;

namespace Infraestrutucture.DataBasePedido;

public class DataBasePedido : IDataBasePedido
{

    public List<Pedido> listaPedidos = new List<Pedido>();

    public void CadastrarPedido(Pedido pedido)
    {
        listaPedidos.Add(pedido);
    }


    public void ExcluirPedido(int id)
    {
        Pedido pedido = BuscarPedido(id);

        listaPedidos.Remove(pedido);
    }


    public List<Pedido> ListarPedidos()
    {
        return listaPedidos;
    }


    public Pedido BuscarPedido(int id)
    {
        return listaPedidos.FirstOrDefault(p => p.Id == id);
    }


    public void AlterarEndereco(Pedido pedidoParaAlterar, Endereco novoEnderco)
    {
        pedidoParaAlterar.Endereco = novoEnderco;
    }




}
