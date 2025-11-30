namespace E_commerce.Models;

public class ItemPagamentoDto
{
    public string NomeProduto { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
}

public class PagamentoRequest
{
    public string NomeCliente { get; set; } = string.Empty;
    public string FormaPagamento { get; set; } = string.Empty;
    public List<ItemPagamentoDto> Itens { get; set; } = new();
}
