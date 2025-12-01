namespace Domain.Services
{
    using Domain.Interfaces;

    public class DescontoPorcentagem : IDesconto
    {
        private readonly decimal _percentual;

        public DescontoPorcentagem(decimal percentual)
        {
            if (percentual < 0 || percentual > 100)
                throw new ArgumentException("O percentual deve estar entre 0 e 100.");
            
            _percentual = percentual;
        }

        public decimal Aplicar(decimal valorOriginal)
        {
            if (valorOriginal < 0)
                throw new ArgumentException("O valor original não pode ser negativo.");
            
            decimal desconto = valorOriginal * (_percentual / 100);
            return valorOriginal - desconto;
        }
    }
}
