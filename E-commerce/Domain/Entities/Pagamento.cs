namespace Domain.Entities
{
    public abstract class Pagamento
    {
        protected Guid Id { get; private set; } = Guid.NewGuid();
        protected decimal Valor { get; private set; }

        protected Pagamento(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do pagamento deve ser maior que zero.");
            
            Valor = valor;
        }

        public abstract string ObterDescricao();

        public abstract decimal CalcularTaxas();

        public decimal ObterValorTotal()
        {
            return Valor + CalcularTaxas();
        }

        public Guid ObterI => Id;
        public decimal ObterValor() => Valor;
    }
}
