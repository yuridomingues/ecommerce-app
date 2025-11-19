namespace Domain;

public class Pedido
{ 

    public Pedido()
    {
        
    } 



    public int Id { get; set; }

    public int ClienteId { get; set; }

    public Endereco? Endereco { get; set; }

    public List<ItemPedido> Itens { get; set; }

    public decimal ValorFrete { get; set; }

    public decimal SubTotal { get; set; }

    public bool Status { get; set; } // true = finalziado e false = aberto


    public Pedido(int clienteId, Endereco endereco)
    {
        ClienteId = clienteId;
        Endereco = endereco;
        Status = false;
        Itens = new List<ItemPedido>();
    }


    public void DefinirId(int id)
    {

        Id = id;

    }


    public void FinalizarPedido()
    {
        
        if(Itens.Count <= 0)
        {
            throw new Exception("Não é possível finalizar um pedido sem itens.");
        }

        Status = true;

    }


    public void AlterarEndereco(Endereco novoEndereco)
    {

        Endereco = novoEndereco;

    }

}
