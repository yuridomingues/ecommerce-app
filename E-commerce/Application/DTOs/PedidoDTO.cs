namespace Domain.DTOs;
using Domain.Entities;

public class PedidoDTO
{
    public Guid Id { get; set; }

    public Guid ClienteId { get; set; }

    public Endereco? Endereco { get; set; }

    public List<ItemPedido>? Itens { get; set; } 

    public decimal ValorFrete { get; set; }

    public decimal SubTotal { get; set; }

    public bool Status { get; set; }

}
