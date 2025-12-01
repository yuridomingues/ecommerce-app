namespace Domain.Entities
{
    public class PagamentoCartao : Pagamento
    {
        public string NumeroCartao { get; private set; }
        public int Parcelas { get; private set; }

        public PagamentoCartao(decimal valor, string numeroCartao, int parcelas) : base(valor)
        {
            if (string.IsNullOrWhiteSpace(numeroCartao))
                throw new ArgumentException("O número do cartão não pode ser vazio.");
            
            if (parcelas < 1 || parcelas > 12)
                throw new ArgumentException("O número de parcelas deve ser entre 1 e 12.");
            
            NumeroCartao = numeroCartao;
            Parcelas = parcelas;
        }

        public override string ObterDescricao()
        {
            return $"Cartão de Crédito em {Parcelas}x";
        }

        public override decimal CalcularTaxas()
        {
            // Taxa de 3% sobre o valor
            return ObterValor() * 0.03m;
        }
    }
}
