namespace Domain;

public class ItemPedido
{
    
     public int Id { get; private set; }

    public int PedidoId { get; private set; }

    public int ProdutoId { get; private set; }  

    public string? NomeProduto { get; private set; }

    public int Quantidade { get; private set; } 

    public decimal PrecoUnitario { get; private set; }

}
