namespace Domain.Entitities
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }

        private Produto() {}

        public Produto(string nome, decimal preco, int estoqueInicial)
        {
            ValidarNome(nome);
            ValidarPreco(preco);
            ValidarEstoque(estoqueInicial);

            Nome = nome;
            Preco = preco;
            Estoque = estoqueInicial;
        }

        public void AtualizarPreco(decimal novoPreco)
        {
            ValidarPreco(novoPreco);
            Preco = novoPreco;
        }

        public void AdicionarEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade a ser adicionada deve ser maior que zero.");
            
            Estoque += quantidade;
        }

        public void RemoverEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade a ser removida deve ser maior que zero.");
            
            if (Estoque - quantidade < 0)
                throw new InvalidOperationException("Estoque insuficiente para remover a quantidade solicitada.");
        }

        private void ValidarPreco(decimal preco)
        {
            if (preco <= 0)
                throw new ArgumentException("O preço deve ser maior que zero.");
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do produto não pode ser vazio.");
        }

        private void ValidarEstoque(int estoque)
        {
            if (estoque < 0)
                throw new ArgumentException("O estoque inicial não pode ser negativo.");
        }
    }
}