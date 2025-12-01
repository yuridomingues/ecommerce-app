namespace Domain.DTOs;

public class DefinirPagamentoDTO
{
    public string TipoPagamento { get; set; } = string.Empty; // "pix" ou "cartao"
    public string? ChavePix { get; set; }
    public string? NumeroCartao { get; set; }
    public int? Parcelas { get; set; }
}
