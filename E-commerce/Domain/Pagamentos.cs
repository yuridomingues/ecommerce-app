namespace Domain;

public class Pagamento
{
    public string NomeCliente { get; set; } = string.Empty;
    public string FormaPagamento { get; set; } = string.Empty; 
    public decimal ValorTotal { get; set; }
    public bool Aprovado { get; set; }

    public Pagamento(string nomeCliente, string formaPagamento, decimal valorTotal)
    {
        NomeCliente = nomeCliente;
        FormaPagamento = formaPagamento;
        ValorTotal = valorTotal;

        
        Aprovado = valorTotal > 0;
    }
}
