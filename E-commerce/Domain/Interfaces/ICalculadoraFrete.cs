namespace Domain.Interfaces
{
    public interface ICalculadoraFrete
    {
        decimal CalcularFrete(decimal pesoTotal, string cepDestino);
    }
}
