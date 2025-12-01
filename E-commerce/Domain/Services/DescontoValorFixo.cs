namespace Domain.Services
{
    using Domain.Interfaces;

    public class DescontoValorFixo : IDesconto
    {
        private readonly decimal _valor;

        public DescontoValorFixo(decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("O valor do desconto não pode ser negativo.");
            
            _valor = valor;
        }

        public decimal Aplicar(decimal valorOriginal)
        {
            if (valorOriginal < 0)
                throw new ArgumentException("O valor original não pode ser negativo.");
            
            // Garante que o valor final não seja negativo
            return Math.Max(0, valorOriginal - _valor);
        }
    }
}
