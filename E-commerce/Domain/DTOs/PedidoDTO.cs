namespace Domain.DTOs;

public class PedidoDTO
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public Endereco? Endereco { get; set; }

    public List<ItemPedido>? Itens { get; set; } 

    public decimal ValorFrete { get; set; }

    public decimal SubTotal { get; set; }

    public bool Status { get; set; }

}
