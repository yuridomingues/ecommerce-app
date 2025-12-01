namespace Domain.Entities
{
    public class PagamentoPix : Pagamento
    {
        public string ChavePix { get; private set; }

        public PagamentoPix(decimal valor, string chavePix) : base(valor)
        {
            if (string.IsNullOrWhiteSpace(chavePix))
                throw new ArgumentException("A chave PIX não pode ser vazia.");
            
            ChavePix = chavePix;
        }

        public override string ObterDescricao()
        {
            return "Pagamento via PIX";
        }

        public override decimal CalcularTaxas()
        {
            return 0m; // PIX não tem taxas
        }
    }
}
