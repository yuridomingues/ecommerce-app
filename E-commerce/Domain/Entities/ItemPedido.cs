namespace Domain;

public class ItemPedido
{
    
     public int Id { get; private set; }

    public int PedidoId { get; private set; }

    public int ProdutoId { get; private set; }  

    public string? NomeProduto { get; private set; }

    public int Quantidade { get; private set; } 

    public decimal PrecoUnitario { get; private set; }

    public ItemPedido(int produtoId, string? nomeProduto, int quantidade, decimal precoUnitario)
    {

        if(quantidade <= 0)
        {
            throw new ArgumentException("A quantidade deve ser maior que zero.");
        }

        ProdutoId = produtoId;
        NomeProduto = nomeProduto;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;

    }
    

}
