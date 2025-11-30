namespace Application.DTOs
{
    // Usado para receber dados (Input)
    public class CriarProdutoDto
    {
        public string Nome {get; set;}
        public decimal Preco {get; set; }
        public int EstoqueInicial {get; set; }
    }

    // Usado para devolver dados (Output)
    public class ProdutoDto
    {
        public Guid Id {get; set; }
        public string Nome {get; set;}
        public decimal Preco {get; set; }
        public int Estoque {get; set; }
    }
}