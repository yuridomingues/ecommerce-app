namespace Domain;

public class ItemPedido
{
    
     public Guid Id { get; private set; }

    public Guid PedidoId { get; private set; }

    public Guid ProdutoId { get; private set; }  

    public string? NomeProduto { get; private set; }

    public int Quantidade { get; private set; } 

    public decimal PrecoUnitario { get; private set; }

    public ItemPedido(Guid produtoId, string? nomeProduto, int quantidade, decimal precoUnitario)
    {

        if(quantidade <= 0)
        {
            throw new ArgumentException("A quantidade deve ser maior que zero.");
        }

        ProdutoId = produtoId;
        NomeProduto = nomeProduto;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
        Id = Guid.NewGuid();

    }
    

}
