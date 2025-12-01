namespace Domain.Services
{
    using Domain.Interfaces;

    public class FreteEconomico : ICalculadoraFrete
    {
        private const decimal TaxaPorKg = 8.0m;

        public decimal CalcularFrete(decimal pesoTotal, string cepDestino)
        {
            if (pesoTotal <= 0)
                throw new ArgumentException("O peso total deve ser maior que zero.");
            
            if (string.IsNullOrWhiteSpace(cepDestino))
                throw new ArgumentException("O CEP de destino não pode ser vazio.");
            
            return pesoTotal * TaxaPorKg;
        }
    }
}
