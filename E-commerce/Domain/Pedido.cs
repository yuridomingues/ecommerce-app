namespace Domain;

public class Pedido
{
    public int Id { get; set; } 

    public int ClienteId { get; set; }

    public Endereco EnderecoEntrega { get; set; }

    public List<ItemPedido> Itens { get; set; }

    public decimal ValorFrete { get; set; }

    public decimal SubTotal { get; set; }

    public bool Status { get; set; }  

}
